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
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            tbNombre.Text = dataGridView1.Rows[0].Cells[1].Value.ToString();
            tbApellidos.Text = dataGridView1.Rows[0].Cells[2].Value.ToString();
            tbEdad.Text = dataGridView1.Rows[0].Cells[3].Value.ToString();
            tbTelefono.Text = dataGridView1.Rows[0].Cells[4].Value.ToString();
            tbDirección.Text = dataGridView1.Rows[0].Cells[5].Value.ToString();
            dateTimePickerFechaInicio.Value = (DateTime)dataGridView1.Rows[0].Cells[6].Value;
            dateTimePickerFechaFinal.Value = (DateTime)dataGridView1.Rows[0].Cells[7].Value;
            tbMesesPagados.Text = dataGridView1.Rows[0].Cells[8].Value.ToString();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            OpAccionesSQL opAccionesSQL = new OpAccionesSQL();

            if(opAccionesSQL.ActualizarClientes(tbNombre.Text, tbApellidos.Text, Convert.ToInt32(tbEdad.Text), tbTelefono.Text,
                tbDirección.Text, dateTimePickerFechaInicio.Value, dateTimePickerFechaFinal.Value, Convert.ToInt32(tbMesesPagados.Text)))
            {
                MessageBox.Show("Actualizado correctamente.");
                Limpiar();
                LlenarDGVRegistro();
            }

            else
            {
                MessageBox.Show($"Ha ocurrido un error al registrar: {opAccionesSQL.sLastError}");
                Limpiar();
                LlenarDGVRegistro();
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
    }
}
