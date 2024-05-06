using ReglasDeNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Gimnasio
{
    public partial class Update : Form
    {
        public Update()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            BuscarClientesPorNombre();
        }

        void BuscarClientesPorNombre()
        {
            OpAccionesSQL opAccionesSQL = new OpAccionesSQL();



            DataTable dt = new DataTable();

            dt = opAccionesSQL.BuscarPorNombre(tbSearch.Text);

            dataGridView1.DataSource = dt;

            dataGridView1.Columns[0].Width = 40;
            dataGridView1.Columns[1].Width = 130;
            dataGridView1.Columns[2].Width = 130;
            dataGridView1.Columns[3].Width = 60;
            dataGridView1.Columns[4].Width = 70;
            dataGridView1.Columns[5].Width = 220;
            dataGridView1.Columns[6].Width = 75;
            dataGridView1.Columns[7].Width = 75;
            dataGridView1.Columns[8].Width = 90;
            dataGridView1.Columns[9].Width = 70;
        }

        void LlenarDGVRegistro()
        {
            OpAccionesSQL opAccionesSQL = new OpAccionesSQL();



            DataTable dt = new DataTable();

            dt = opAccionesSQL.MostrarRegistradosEstatusEnDGV();


            dataGridView1.DataSource = dt;

            dataGridView1.Columns[0].Width = 40;
            dataGridView1.Columns[1].Width = 130;
            dataGridView1.Columns[2].Width = 130;
            dataGridView1.Columns[3].Width = 60;
            dataGridView1.Columns[4].Width = 70;
            dataGridView1.Columns[5].Width = 220;
            dataGridView1.Columns[6].Width = 75;
            dataGridView1.Columns[7].Width = 75;
            dataGridView1.Columns[8].Width = 90;
            dataGridView1.Columns[9].Width = 70;
        }

        private void Update_Load(object sender, EventArgs e)
        {
            LlenarDGVRegistro();
            ActualizarId();
        }

        void ActualizarId()
        {
            OpAccionesSQL opAccionesSQL = new OpAccionesSQL();
            int ID = opAccionesSQL.ObtenerUltimoID();

            tbID.Text = ID.ToString();
        }


        private void btnActualizar_Click(object sender, EventArgs e)
        {
            OpAccionesSQL opAccionesSQL = new OpAccionesSQL();

            if (tbNombre.Text == "" || tbApellidos.Text == "" || tbEdad.Text == "" ||
                tbTelefono.Text == "" || tbDirección.Text == "" || tbMesesPagados.Text == "")
            {
                MessageBox.Show("Debe de llenar todos los campos.");
            }
            else
            {
                if (opAccionesSQL.ActualizarClientes(Convert.ToInt32(tbID.Text), tbNombre.Text, tbApellidos.Text, Convert.ToInt32(tbEdad.Text), tbTelefono.Text,
                    tbDirección.Text, dateTimePickerFechaInicio.Value, dateTimePickerFechaFinal.Value, Convert.ToInt32(tbMesesPagados.Text)))
                {
                    MessageBox.Show("Actualizado correctamente.");
                    Limpiar();
                    LlenarDGVRegistro();
                    ActualizarId();

                    tbNombre.Enabled = false;
                    tbApellidos.Enabled = false;
                    tbEdad.Enabled = false;
                    tbDirección.Enabled = false;
                    tbTelefono.Enabled = false;
                    dateTimePickerFechaInicio.Enabled = false;
                    dateTimePickerFechaFinal.Enabled = false;
                    tbMesesPagados.Enabled = false;
                }

                else
                {
                    MessageBox.Show($"Ha ocurrido un error al registrar: {opAccionesSQL.sLastError}");
                    Limpiar();
                    LlenarDGVRegistro();
                    ActualizarId();
                }
            }
        }


        void Limpiar()
        {
            tbNombre.Clear();
            tbApellidos.Clear();
            tbEdad.Clear();
            tbTelefono.Clear();
            tbDirección.Clear();
            tbMesesPagados.Clear();
        }

        private void dateTimePickerFechaFinal_ValueChanged(object sender, EventArgs e)
        {
            DateTime fechaFinal = dateTimePickerFechaFinal.Value;
            DateTime fechaInicio = dateTimePickerFechaInicio.Value;

            if (fechaFinal < fechaInicio)
            {
                MessageBox.Show("La fecha tiene que ser mayor a la fecha de inicio.");
                dateTimePickerFechaFinal.Value = fechaInicio;
            }
            else
            {

                if (fechaFinal.Year > fechaInicio.Year && fechaFinal.Month >= fechaInicio.Month)
                {
                    int meses = fechaFinal.Month - fechaInicio.Month;
                    int Resultado3 = meses + 12;
                    tbMesesPagados.Text = Resultado3.ToString();
                }

                if (fechaFinal.Year > fechaInicio.Year && fechaFinal.Month < fechaInicio.Month)
                {
                    int meses = fechaInicio.Month - fechaFinal.Month;
                    int Resultado3 = 12 - meses;
                    tbMesesPagados.Text = Resultado3.ToString();
                }
                else if (fechaFinal.Year == fechaInicio.Year)
                {
                    int Resultado = fechaFinal.Month - fechaInicio.Month;
                    tbMesesPagados.Text = Resultado.ToString();
                }
                else if (fechaFinal.Year > fechaInicio.Year)
                {
                    int Resultadoo = fechaFinal.Month + 12;
                    tbMesesPagados.Text = Resultadoo.ToString();
                }
                else
                {
                    MessageBox.Show("El año tiene que ser mayor o igual al año actual.");
                    dateTimePickerFechaFinal.Value = fechaInicio;
                }

            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            OpAccionesSQL opAccionesSQL = new OpAccionesSQL();

            if (tbNombre.Text == "" || tbApellidos.Text == "" || tbEdad.Text == "" ||
                tbTelefono.Text == "" || tbDirección.Text == "" || tbMesesPagados.Text == "")
            {
                MessageBox.Show("Debe de llenar todos los campos.");
            }
            else
            {
                if (opAccionesSQL.EliminarClientes(Convert.ToInt32(tbID.Text)))
                {
                    MessageBox.Show("Eliminado correctamente.");
                    Limpiar();
                    LlenarDGVRegistro();
                    ActualizarId();

                    tbNombre.Enabled = false;
                    tbApellidos.Enabled = false;
                    tbEdad.Enabled = false;
                    tbDirección.Enabled = false;
                    tbTelefono.Enabled = false;
                    dateTimePickerFechaInicio.Enabled = false;
                    dateTimePickerFechaFinal.Enabled = false;
                    tbMesesPagados.Enabled = false;
                }

                else
                {
                    MessageBox.Show($"Ha ocurrido un error al eliminar: {opAccionesSQL.sLastError}");
                    Limpiar();
                    LlenarDGVRegistro();
                    ActualizarId();
                }
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow filaSeleccionada = dataGridView1.Rows[e.RowIndex];

                tbID.Text = filaSeleccionada.Cells["Id"].Value.ToString();
                tbNombre.Text = filaSeleccionada.Cells["Nombre"].Value.ToString();
                tbApellidos.Text = filaSeleccionada.Cells["Apellidos"].Value.ToString();
                tbEdad.Text = filaSeleccionada.Cells["Edad"].Value.ToString();
                tbTelefono.Text = filaSeleccionada.Cells["Telefono"].Value.ToString();
                tbDirección.Text = filaSeleccionada.Cells["Direccion"].Value.ToString();
                dateTimePickerFechaInicio.Value = (DateTime)filaSeleccionada.Cells["FechaInicio"].Value;
                dateTimePickerFechaFinal.Value = (DateTime)filaSeleccionada.Cells["FechaFinal"].Value;
                tbMesesPagados.Text = filaSeleccionada.Cells["MesesPagados"].Value.ToString();

                tbNombre.Enabled = true;
                tbApellidos.Enabled = true;
                tbEdad.Enabled = true;
                tbDirección.Enabled = true;
                tbTelefono.Enabled = true;
                dateTimePickerFechaInicio.Enabled = true;
                dateTimePickerFechaFinal.Enabled = true;
                tbMesesPagados.Enabled = true;
            }
        }

        private void tbEdad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsDigit(e.KeyChar) && e.KeyChar != 8))
            {
                e.Handled = true;
            }
        }
    }
}
