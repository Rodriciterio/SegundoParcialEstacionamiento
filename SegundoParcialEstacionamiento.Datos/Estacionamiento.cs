using SegundoParcialEstacionamiento.Datos;
using SegundoParcialEstacionamiento.Entidades;

public class Estacionamiento
{
    public string Nombre { get; set; }
    public int Capacidad { get; set; }
    public List<Movimiento> Movimientos { get; private set; }
    private SerializadorXml Serializador { get; }

    public Estacionamiento(string nombre)
    {
        nombre = nombre.Trim();
    }

    private Estacionamiento()
    {
        Movimientos = new List<Movimiento>();
        Serializador = new SerializadorXml();
        Movimientos = Serializador.LeerDatos();
    }

    public (bool, string) IngresarVehiculo(Vehiculo vehiculo)
    {
        return (true, "Vehículo ingresado.");
    }

    public (bool, string) RetirarVehiculo(string patente)
    {
        return (true, "Vehículo retirado.");
    }

    public bool HayLugaresDisponibles()
    {
        return Movimientos.Count < Capacidad;
    }

    public void GuardarDatos()
    {
        Serializador.GuardarDatos(Movimientos);
    }
}
