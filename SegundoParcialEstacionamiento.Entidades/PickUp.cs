namespace SegundoParcialEstacionamiento.Entidades
{
    public class PickUp : Vehiculo 
    {
        private int ValorHora;
        public int Carga { get; set; }


        public PickUp()
        {
        }

        public PickUp(string Marca, string Modelo, string Patente, int Carga) : base(Marca, Modelo, Patente)
        {
            ValorHora = 2000;
            this.Carga = Carga;
        }
    }
}
