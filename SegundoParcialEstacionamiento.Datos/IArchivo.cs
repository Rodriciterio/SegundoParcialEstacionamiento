using SegundoParcialEstacionamiento.Entidades;

namespace SegundoParcialEstacionamiento.Datos
{
    public interface IArchivo<T> where T : class
    {
        List<T> LeerDatos();
        void GuardarDatos(List<T> entidades);
    }
}
