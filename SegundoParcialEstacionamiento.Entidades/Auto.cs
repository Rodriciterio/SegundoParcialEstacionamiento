using System.Drawing;

namespace SegundoParcialEstacionamiento.Entidades
{
    public class Auto : Vehiculo
    {
        public int ValorHora { get; set; }
        public ConsoleColor Color { get; set; }


        public Auto()
        {
        }

        public Auto(string Marca, string Modelo, string Patente, ConsoleColor Color) : base(Marca, Modelo, Patente)
        {
            ValorHora = 1800;
            this.Color = Color;
        }


    }
}
