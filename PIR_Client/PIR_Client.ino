#include <Dhcp.h>
#include <Dns.h>
#include <Ethernet.h>
#include <EthernetClient.h>
#include <EthernetServer.h>
#include <EthernetUdp.h>
#include <SPI.h>
#include <stdlib.h>
#include <stdio.h>
//#include <eeprom.h>

// IO variables 
#define pIR1 7 // Motion Sensor 1 PIN
#define pIR2 8 // motion sensor 2 PIN
#define redPin 3 //red led pin
#define yelPin 5 // yellow led pin
#define grePin 6 //green led pin
#define TIMEOUT 15000 //maximum time 

//Configuracao de Placa de Rede
byte mac[] = { 0xDE, 0xAD, 0xBE, 0xEF, 0xFE, 0xED }; //client local mac address
IPAddress serverIP(192, 168, 1, 142);// Server IP Address
IPAddress staticIP(192,168,1,200); // client local IP 
int port = 11050; // Porta
EthernetClient cliente; //tcp client
String message = ""; //String that stores the message to be sent through the network

//program variables
int pir1Read = 0, pir2Read = 0;// PIR sensor 2 status
int redTime = 0, yellowTime = 0, greenTime = 0; // traffic light time variables
float lowTresh = 0, highTresh = 0; // speed limit variables
volatile int firstDetectTime = 0, secondDetectTime = 0; // Contadores
float totalDetectTime, calculatedSpeed; // velocity calculation variables
int baseTimer = 1;//basic timer value = 1 second
int mode = 0;
bool isPIR1active = false, isPIR2active = false; // speed reading variables
char messagex[25];
//Metro sensorRead = Metro(6000);

void setup() {
  // IO Setup
  Serial.begin(9600);
  pinMode(13, OUTPUT); // debugging led
  pinMode(pIR1, INPUT);//PIR sensor 1
  pinMode(pIR2, INPUT);// PIR sensor 2
  pinMode(redPin, OUTPUT);//RED LED
  pinMode(yelPin, OUTPUT); // YELLOW LED
  pinMode(grePin, OUTPUT); // GREEN LED

  //Network Setup
  if (Ethernet.begin(mac) == 0) { //tries to connect using dhcp
    Serial.println("$ DHCP Falhou! Atribuindo IP estático : 192.168.1.200 ");
    Ethernet.begin(mac, staticIP);
  }
  else
  {
    Serial.print("DHCP IP: ");
    Serial.println(Ethernet.localIP());
    if (cliente.connect(serverIP, port)) {
      Serial.println("Conectado!");
	  //delay(15000);
	  while (cliente.available() == 0)
	  {
		  // creates a delay because of power consumption : going through  lot of while loops will consume a lot of power (yet to be measured in this project)
		  delay(100);
		  // waits until coniguration is received from the server
	  }
	  if ((cliente.connected())&&(cliente.available()))
	  {
		  //reads configuration from server and defines configurations
		  if (startVerifier(message))
		  {
			  Serial.println("Configurações recebidas! Começando programa!");
			  //clears buffer
			  cliente.flush();
		  }else{
			  Serial.println("Falha ao receber configurações! Usando valores padrões!");
			  //loads program with default values
			  redTime = 5; yellowTime = 5; greenTime = 10; lowTresh = 0.5; highTresh = 1.5;
		  }
	  }
    }
    else
    {
      Serial.println("Conexão ao servidor falhou! Entrando em modo offline");
	  redTime = 5; yellowTime = 5; greenTime = 10; lowTresh = 0.5; highTresh = 1.5;
    }
  }

  Serial.println("Program Start!");
  cliente.flush();
}

void loop() {
	if (cliente.connected())
	{
		if (cliente.available()) // checks for server instructions  
		{
			message = cliente.readString();
			Serial.println("$");
			Serial.println(message);
			//cada clausula IF responsável por verificar uma instrução
			codeRuntimeCheck(message);
		}
		else
		{
			cycleGreenYellow(greenTime, grePin, redPin, yelPin);
			cycleGreenYellow(yellowTime, yelPin, grePin, redPin);
			turnRed(redTime);
		}
	}
	else
	{
		Serial.println(">");
		cycleGreenYellow(greenTime, grePin, redPin, yelPin);		
		cycleGreenYellow(yellowTime, yelPin, grePin, redPin);
		turnRed(redTime);
	}
}

void pirAverage() {// calculates the speed and sends it to the server

	pir1Read = digitalRead(pIR1);
	pir2Read = digitalRead(pIR2);

	if ((pir1Read) && (!pir2Read) && (isPIR1active == false) && (mode == 0))//first reading is only valid when there is no movement detected already on the second sensor
	{
		firstDetectTime = millis();
		isPIR1active = true;
		mode = 1;
		//Serial.println(firstDetectTime);
		//Serial.println(mode);
	}

	if ((isPIR1active) && (isPIR2active == false) && (mode == 1)) // for when sensor one has already been triggered and system must change lights
	{
		digitalWrite(13, HIGH);
		mode = 2;
		//delay(100);
		//Serial.println(mode);
		//thi routine is mostly for troubleshooting purposes, when the first sensor has been triggered, the building arduino
		//LED will be on
	}
	// second sensor triggering is only valid when system detects that the first sensor is aleady trigggered by checking the state of isPIR1active
	if ((isPIR1active == true) && (pir2Read == true) && (mode == 2))
	{
		isPIR2active = true;
		secondDetectTime = millis();
		//Serial.println(secondDetectTime);
		mode = 3;
	}

	//after detecting valid inputs, it calculates the speed and resets the system to waiting for the first sensor to be triggered
	if ((isPIR1active) && (isPIR2active) && (mode == 3)) { 
		digitalWrite(13, LOW);//turns off debugg LED
		totalDetectTime = (secondDetectTime - firstDetectTime);
		//Serial.print("Total Time :");
		//Serial.println(totalTime);
		calculatedSpeed = 0.303 / (totalDetectTime * 0.001);//converts the reading into velocity 	
		Serial.print("Velocidade Detectada: ");
		Serial.print(calculatedSpeed);
		Serial.println();
		//resets all values
		isPIR1active = false;
		isPIR2active = false;
		mode = 0;
		//sends data to server
		if ((calculatedSpeed>0)&& (calculatedSpeed<50)) // prevents incorrect readings from being sent
		{
			//if (calculatedSpeed<lowTresh)
			//{
			//	Serial.println("Velocidade abaixo dos limites");
			//}
			//else if ((calculatedSpeed>lowTresh) && (calculatedSpeed<highTresh))
			//{
			//	Serial.println("Velocidade dentro dos limites");
			//}
			//else {
			//	Serial.println("Velocidade acima dos limites");
			//}
			////sends velocity measurement to server
			if (cliente.connected()) {
				//cliente.print(velocity);
				message = String(calculatedSpeed, 2);
				cliente.print(message);
				Serial.println("Enviado para servidor!");
			}
		}
		else
		{
			Serial.println("Velocidade inválida e descartada!");
		}

	}
}

void turnRed(int time) { // controla somente o a duração da luz vermelha
  int exTime = time * 1000;
  digitalWrite(redPin, HIGH);
  digitalWrite(yelPin, LOW);
  digitalWrite(grePin, LOW);
  float begin = millis();
  float end = 0;
  while (exTime>=(end - begin))
  {
    end = millis();
  }
  //resets all values and discards pending calculations
  mode = 0;
  isPIR1active = false;
  isPIR2active = false;
  firstDetectTime = 0;
  secondDetectTime = 0;
  calculatedSpeed = 0;
  //Serial.println("Counter Reset!");
}

//Unsyncronized Operation mode -----------------------------------------------------------------------------------------
void cycleGreenYellow(int time, int on1, int off1, int off2){ // controle da duração das luzes amarela e verde
	int exTime = time * 1000;//converte segundo para milisegundo
	digitalWrite(on1, HIGH);
	digitalWrite(off1, LOW);
	digitalWrite(off2, LOW);
	float begin = millis();
	float end = 0;
	//Serial.println(begin, DEC);
	while (exTime > (end - begin))
	{
		pirAverage();
		end = millis();
	}
}

bool startVerifier(String datarec) { // somente para verificação de instruções recebidas durante startup
	datarec = cliente.readString();
	//Serial.println(datarec);

	if (datarec.startsWith("TTV"))
	{
		datarec.toCharArray(messagex, 30); //converts the String to a Char[] to facilitate the extraction of values
		Serial.println(messagex);//prints the message for confirmation purposes
		int x, y;
		sscanf(messagex, "TTV %d,%d,%d,%d,%d", &greenTime, &yellowTime, &redTime, &x, &y);
		lowTresh = x*0.01;
		highTresh = y*0.01;
		showConf();
		Serial.flush();
		return true;		
	}
	else
	{
		Serial.println("Durações não recebidas! Usando valores padrões");
		redTime = 5; yellowTime = 5; greenTime = 10; lowTresh = 0.5; highTresh = 1.5; // all treshold values are send at the same time
		showConf();
		return false;
	}
}

void codeRuntimeCheck(String message) { // checks for server instructions during runtime
	//use if - else and message.startsWith("Instruction") to check for specific instructions
	if (message.startsWith("CDE")) //Codigo teste
	{
		Serial.println("CDE Request received");
	}
	if (message.startsWith("UPDT"))// instrução para actualizar configurações
	{
		message.toCharArray(messagex, 30); //converts the String to a Char[] to facilitate the extraction of values
		Serial.println(messagex);//prints the message for confirmation purposes
		int x, y;
		sscanf(messagex, "UPDT %d,%d,%d,%d,%d", &greenTime, &yellowTime, &redTime, &x, &y);
		lowTresh = x*0.01; 
		highTresh = y*0.01;
		showConf();
		Serial.println("Actualização feita com sucesso!");
		Serial.flush();
	}
}

void showConf() { //shows current configuration values
	Serial.print("\n------------Intervalos(em segundos)------------------\n ");
	Serial.print("Vermelho: ");
	Serial.print(redTime);
	Serial.print(", Amarelo: ");
	Serial.print(yellowTime);
	Serial.print(", Verde: ");
	Serial.print(greenTime);
	Serial.print("\n------------Limites de Velocidade (em m/s)------------------ \n");
	Serial.print("Minima : ");
	Serial.print(lowTresh);
	Serial.print(", Máxima : ");
	Serial.println(highTresh);
	Serial.println("\n------------Fim------------------ ");
}

// Sync Mode instructions ------------------------------------------------------------------------------------------

void syncOperation() {






}