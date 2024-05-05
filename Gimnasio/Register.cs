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
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            OpAccionesSQL opAccionesSQL = new OpAccionesSQL();

            if(opAccionesSQL.RegistrarClientes(tbNombre.Text, tbApellidos.Text, Convert.ToInt32(tbEdad.Text), tbTelefono.Text, 
                tbDirección.Text, dateTimePickerFechaInicio.Value, dateTimePickerFechaFinal.Value, Convert.ToInt32(tbMesesPagados.Text)))
            {
                MessageBox.Show("Registrado correctamente.");
                Limpiar();
            }
            else
            {
                MessageBox.Show($"Ha ocurrido un error al registrar: {opAccionesSQL.sLastError}");
                Limpiar();
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
