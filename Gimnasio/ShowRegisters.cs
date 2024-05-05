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
    public partial class ShowRegisters : Form
    {
        public ShowRegisters()
        {
            InitializeComponent();
        }

        private void ShowRegisters_Load(object sender, EventArgs e)
        {
            LlenarDGVRegistro();
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
    }
}
