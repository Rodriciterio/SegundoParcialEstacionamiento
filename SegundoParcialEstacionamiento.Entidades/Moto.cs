using System.Reflection;
using System.Text.RegularExpressions;
using System.Text;

namespace SegundoParcialEstacionamiento.Entidades
{
    public class Moto : Vehiculo
    {
        public int Cilindrada { get; set; }
        private int ValorHora;

        public Moto()
        {

        }

        public Moto(string Marca, string Modelo, string Patente, int cilindrada)
            : base(Marca, Modelo, Patente)
        {
            ValorHora = 1000;
            this.Cilindrada = Cilindrada;
        }
    }
}
