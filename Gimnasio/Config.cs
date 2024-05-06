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
    public partial class Config : Form
    {
        public Config()
        {
            InitializeComponent();
        }

        private void Config_Load(object sender, EventArgs e)
        {
            LlenarDGVRegistro();
        }

        void LlenarDGVRegistro()
        {
            OpAccionesSQL opAccionesSQL = new OpAccionesSQL();



            DataTable dt = new DataTable();

            dt = opAccionesSQL.MostrarLoginsEnDGV();


            if(dt.Rows.Count > 0)
            {
                dataGridView1.DataSource = dt;

                dataGridView1.Columns[0].Width = 50;
                dataGridView1.Columns[1].Width = 200;
                dataGridView1.Columns[2].Width = 200;
            }
            else
            {
                dataGridView1.DataSource = null;
            }


        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            OpAccionesSQL opAccionesSQL = new OpAccionesSQL();

            if (tbUser.Text == "")
            {
                MessageBox.Show("Debe de llenar el campo Usuario.");
            }
            else
            {
                if (opAccionesSQL.RegistrarLogins(tbUser.Text, tbPassword.Text))
                {
                    MessageBox.Show("Guardado correctamente.");
                    Limpiar();
                    LlenarDGVRegistro();
                }

                else
                {
                    MessageBox.Show($"Ha ocurrido un error al Guardar: {opAccionesSQL.sLastError}");
                    Limpiar();
                    LlenarDGVRegistro();
                }
            }
        }

        void Limpiar()
        {
            tbUser.Clear();
            tbPassword.Clear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            OpAccionesSQL opAccionesSQL = new OpAccionesSQL();

            if (opAccionesSQL.EliminarLogins(tbUser.Text, tbPassword.Text))
            {
                MessageBox.Show("Eliminado correctamente.");
                Limpiar();
                LlenarDGVRegistro();
            }

            else
            {
                MessageBox.Show($"Ha ocurrido un error al eliminar: {opAccionesSQL.sLastError}");
                Limpiar();
                LlenarDGVRegistro();
            }
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow filaSeleccionada = dataGridView1.Rows[e.RowIndex];

                tbUser.Text = filaSeleccionada.Cells["Usuario"].Value.ToString();
                tbPassword.Text = filaSeleccionada.Cells["Contraseña"].Value.ToString();
            }
        }
    }
}
