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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnShowPassword_Click(object sender, EventArgs e)
        {
            if(tbPassword.UseSystemPasswordChar == true)
            {
                tbPassword.UseSystemPasswordChar = false;
            }
            else
            {
                tbPassword.UseSystemPasswordChar = true;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            OpAccionesSQL opAccionesSQL = new OpAccionesSQL();

            if (opAccionesSQL.ExisteUsuario(tbUser.Text, tbPassword.Text))
            {
                MessageBox.Show("Conectado correctamente.");
                Home home = new Home();
                this.Hide();
                home.ShowDialog();
            }

            else
            {
                MessageBox.Show($"Usuario y/o contraseña incorrecta, por favor intentelo de nuevo.");
            }
        }
    }
}
