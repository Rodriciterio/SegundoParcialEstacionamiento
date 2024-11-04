using SegundoParcialEstacionamiento.Entidades;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SegundoParcialEstacionamiento.Datos
{
    public class ManejadorArchivoSecuencial : IArchivo<Vehiculo>
    {
        private string path = Environment.CurrentDirectory;
        private string archivo = "Vehiculos.txt";

        private string nombreArchivo;
        public ManejadorArchivoSecuencial()
        {
            nombreArchivo = Path.Combine(path, archivo);
        }


        public void GuardarDatos(List<Vehiculo> entidades)
        {
            using (var escritor = new StreamWriter(nombreArchivo))
            {
                foreach (var item in entidades)
                {
                    string linea = ConstruirLinea(item);
                    escritor.WriteLine(linea);
                }

            }
        }

        private string ConstruirLinea(Vehiculo item)
        {
            string linea = $"{item.marca}|{item.modelo}|{item.patente}";
            return linea;
        }

        public List<Vehiculo> LeerDatos()
        {
            List<Vehiculo> lista = new List<Vehiculo>();
            if (File.Exists(nombreArchivo))
            {
                using (var lector = new StreamReader(nombreArchivo))
                {
                    while (!lector.EndOfStream)
                    {
                        var lineaLeida = lector.ReadLine();
                        Vehiculo vehiculo = ConstruirVehiculo(lineaLeida);
                        lista.Add(vehiculo);
                    }
                }
            }
            return lista;
        }

        private Vehiculo ConstruirVehiculo(string? lineaLeida)
        {
            var campos = lineaLeida.Split('|');
            var marca = campos[0];
            var modelo = campos[1];
            var patente = campos[2];
            if (campos.Length > 3)
            {
                var cilindrada = int.Parse(campos[3]);
                return new Moto(marca, modelo, patente, cilindrada);

            }
            else if (campos.Length>3)
            {
                var color = ConsoleColor(campos[3]);
                return new Auto(marca, modelo, patente, color);

            }
            var carga = int.Parse(campos[3]);
            return new PickUp(marca, modelo, patente, carga);
        }
    }
}
