using SegundoParcialEstacionamiento.Entidades;

namespace SegundoParcialEstacionamiento.Windows
{
    public partial class frmEstacionamiento : Form
    {
        public frmEstacionamiento()
        {
            InitializeComponent();
        }

        Estacionamiento estacionamiento = new Estacionamiento("Parcial");
        List<Movimiento> movimientos;

        private void frmEstacionamiento_Load(object sender, EventArgs e)
        {
            movimientos = estacionamiento.Movimientos;
        }


        private void btnIngresar_Click(object sender, EventArgs e)
        {
            frmVehiculosAE frm = new frmVehiculosAE() { Text = "Ingresar Vehículo" };
            frm.ShowDialog();
        }

        private void btnRetirar_Click(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            estacionamiento.GuardarDatos();
            Application.Exit();
        }

    }
}
