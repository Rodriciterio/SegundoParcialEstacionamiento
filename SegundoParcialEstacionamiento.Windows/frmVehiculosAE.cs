using SegundoParcialEstacionamiento.Datos;
using SegundoParcialEstacionamiento.Entidades;
using System.Data;

namespace SegundoParcialEstacionamiento.Windows
{
    public partial class frmVehiculosAE : Form
    {
        private TipoVehiculo tipoVehiculo;
        public frmVehiculosAE()
        {
            InitializeComponent();
        }


        private void CargarDatosComboColores()
        {
            List<ConsoleColor> colors = new List<ConsoleColor>();
            for (int i = 0; i < 10; i++)
            {
                colors.Add((ConsoleColor)i);
            }
            cboColores.DataSource = colors;
            cboColores.SelectedIndex = 0;
        }

        private void CargarDatosComboVehiculos()
        {
            var lista = Enum.GetValues(typeof(TipoVehiculo)).Cast<TipoVehiculo>().ToList();
            cboTipoVehiculo.DataSource = lista;
            cboTipoVehiculo.SelectedIndex = 0;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }


        private void btnBuscar_Click(object sender, EventArgs e)
        {
            string patente = txtPatente.Text.Trim();

            if (!Vehiculo.ValidarPatente(patente))
            {
                MessageBox.Show("La patente ingresada no es válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }



            ManejadorArchivoSecuencial manejadorArchivo = new ManejadorArchivoSecuencial();
            var vehiculosRegistrados = manejadorArchivo.LeerDatos();

            if (vehiculosRegistrados.Contains(patente))
            {
                Vehiculo vehiculo = vehiculosRegistrados[patente];
                txtMarca.Text = vehiculo.marca;
                txtModelo.Text = vehiculo.modelo;

                if (vehiculo is Moto moto)
                {
                    nudCarga.Text = moto.Cilindrada.ToString();
                }
                else if (vehiculo is Auto auto)
                {
                    cboColores.SelectedItem = auto.Color;
                }
                else if (vehiculo is PickUp pickup)
                {
                    nudCarga.Text = pickup.Carga.ToString();
                }

                MessageBox.Show("Vehículo encontrado y datos cargados.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Vehículo no encontrado. Ingrese los datos para un nuevo vehículo.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
            }
        }


        private void ManejarTextos(bool v)
        {
            txtMarca.Enabled = v;
            txtModelo.Enabled = v;
            nudCarga.Enabled = v;
            nudCilindrada.Enabled = v;
            cboColores.Enabled = v;
            cboTipoVehiculo.Enabled = v;
        }

        private void LimpiarTextos()
        {
            txtMarca.Clear();
            txtModelo.Clear();
            nudCarga.Value = 300;
            nudCilindrada.Value = 50;
            cboColores.SelectedIndex = 0;
            cboTipoVehiculo.SelectedIndex = 0;
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void cboTipoVehiculo_SelectedIndexChanged(object sender, EventArgs e)
        {
            tipoVehiculo = (TipoVehiculo)cboTipoVehiculo.SelectedItem!;
            if (tipoVehiculo is TipoVehiculo.Auto)
            {
                nudCarga.Visible = false;
                nudCilindrada.Visible = false;
                cboColores.Visible = true;
            }
            else if (tipoVehiculo is TipoVehiculo.Moto)
            {
                nudCarga.Visible = false;
                cboColores.Visible = false;
                nudCilindrada.Visible = true;
            }
            else if (tipoVehiculo is TipoVehiculo.PickUp)
            {
                nudCilindrada.Visible = false;
                cboColores.Visible = false;
                nudCarga.Visible = true;
            }

        }

        private void frmVehiculosAE_Load(object sender, EventArgs e)
        {
            CargarDatosComboVehiculos();
            CargarDatosComboColores();
            ManejarTextos(false);

        }
    }
}
