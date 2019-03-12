
Public Class DataPacket
    Public Property ID As String
    Public Property Velocidade As Double
    Public Property Tempo As DateTime
    Public Sub New(deviceID As String, speedMeasurement As Double, time As DateTime)
        ID = deviceID
        Velocidade = speedMeasurement
        Tempo = time
    End Sub


End Class
