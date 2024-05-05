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
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void Register_Load(object sender, EventArgs e)
        {
            tbNombre.Focus();
            LlenarDGVRegistro();


        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            OpAccionesSQL opAccionesSQL = new OpAccionesSQL();

            if(opAccionesSQL.RegistrarClientes(tbNombre.Text, tbApellidos.Text, Convert.ToInt32(tbEdad.Text), tbTelefono.Text, 
                tbDirección.Text, dateTimePickerFechaInicio.Value, dateTimePickerFechaFinal.Value, Convert.ToInt32(tbMesesPagados.Text)))
            {
                MessageBox.Show("Registrado correctamente.");
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

        void LlenarDGVRegistro()
        {
            OpAccionesSQL opAccionesSQL = new OpAccionesSQL();

            

            DataTable dt = new DataTable();

            dt = opAccionesSQL.MostrarRegistradosEnDGV();

            dataGridView1.DataSource = dt;

            dataGridView1.Columns[0].Width = 40;
            dataGridView1.Columns[1].Width = 130;
            dataGridView1.Columns[2].Width = 130;
            dataGridView1.Columns[3].Width = 70;
            dataGridView1.Columns[4].Width = 100;
            dataGridView1.Columns[5].Width = 220;
            dataGridView1.Columns[6].Width = 90;
            dataGridView1.Columns[7].Width = 90;
            dataGridView1.Columns[8].Width = 90;
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
