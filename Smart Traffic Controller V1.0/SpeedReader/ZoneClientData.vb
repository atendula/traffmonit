Public Class ZoneClientData

    ' similar to DataPacker with the exception of missing an ID object
    Public Property Velocidade As Double
    Public Property Tempo As DateTime
    Public Sub New(speedMeasurement As Double, time As DateTime)
        Velocidade = speedMeasurement
        Tempo = time
    End Sub
End Class
