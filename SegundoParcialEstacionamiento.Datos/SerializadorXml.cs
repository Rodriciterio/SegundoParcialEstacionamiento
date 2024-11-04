using SegundoParcialEstacionamiento.Entidades;
using System.Xml.Serialization;

namespace SegundoParcialEstacionamiento.Datos
{
    public class SerializadorXml : IArchivo<Movimiento>
    {
        private string path = Environment.CurrentDirectory;
        private string archivo = "Vehiculos.Xml";

        private string nombreArchivo;

        public SerializadorXml()
        {
            nombreArchivo = Path.Combine(path, archivo);
        }

        public void GuardarDatos(List<Movimiento> movimiento)
        {
            using (var escritor = new StreamWriter(nombreArchivo))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<Movimiento>));
                serializer.Serialize(escritor, movimiento);
            }
        }

        public List<Movimiento> LeerDatos()
        {
            if (File.Exists(nombreArchivo))
            {
                using (var lector = new StreamReader(nombreArchivo))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Movimiento>));
                    return serializer.Deserialize(lector) as List<Movimiento>;
                }

            }
            return new List<Movimiento>();
        }
    }
}

