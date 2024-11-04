using System.Text;

namespace SegundoParcialEstacionamiento.Entidades
{
    public abstract class Vehiculo
    {
        protected string? Marca { get; } = null!;
        protected string? Modelo { get; } = null!;
        protected string? Patente { get; } = null!;


        public string marca
        {
            get
            {
                return Marca;
            }
            set
            {
                if (value == "")
                {
                    new ArgumentException("Vacia");
                }
            }
        }

        public string modelo
        {
            get
            {
                return Modelo;
            }
            set
            {
                if (value == "")
                {
                    new ArgumentException("Vacio");
                }
            }
        }

        public string patente
        {
            get
            {
                return Patente;
            }
            set
            {
                if (value == "")
                {
                    new ArgumentException("Vacia");
                }
            }
        }


        public bool ValidarPatente(string patente)
        {
            patente = patente.ToUpper();

            if (EsFormatoNuevo())
            {
                return true;
            }
            else if (EsFormatoAntiguo())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool EsFormatoAntiguo()
        {
            return Patente.Length == 6;
        }

        private bool EsFormatoNuevo()
        {
            return Patente.Length == 7;
        }


        protected Vehiculo()
        {

        }

        protected Vehiculo(string Marca, string Modelo, string Patente)
        {
            this.Marca = Marca;
            this.Modelo = Modelo;
            this.Patente = Patente;
        }

        public string ObtenerInformacion()
        {

            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendFormat($"Marca: {Marca} ");
            stringBuilder.Append($"Modelo: {Modelo} ");
            stringBuilder.Append($"Patente: {Patente} ");

            return stringBuilder.ToString();
        }
    }
}
