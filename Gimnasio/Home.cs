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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            btnHome.Focus();
            btnHome.BackColor = Color.SteelBlue;
            AbrirFormHijo(new Inicio());
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            
            btnRegister.BackColor = Color.SteelBlue;
            btnHome.BackColor = Color.Gainsboro;
            btnShowRegisters.BackColor = Color.Gainsboro;
            btnConfig.BackColor = Color.Gainsboro;
            btnEditar.BackColor = Color.Gainsboro;


            AbrirFormHijo(new Register());
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            btnHome.BackColor = Color.SteelBlue;
            btnRegister.BackColor = Color.Gainsboro;
            btnShowRegisters.BackColor = Color.Gainsboro;
            btnConfig.BackColor = Color.Gainsboro;

            AbrirFormHijo(new Inicio());
        }

        private void btnShowRegisters_Click(object sender, EventArgs e)
        {
            btnShowRegisters.BackColor = Color.SteelBlue;
            btnHome.BackColor = Color.Gainsboro;
            btnRegister.BackColor = Color.Gainsboro;
            btnConfig.BackColor = Color.Gainsboro;
            btnEditar.BackColor = Color.Gainsboro;


            AbrirFormHijo(new ShowRegisters());
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            btnConfig.BackColor = Color.SteelBlue;
            btnShowRegisters.BackColor = Color.Gainsboro;
            btnHome.BackColor = Color.Gainsboro;
            btnRegister.BackColor = Color.Gainsboro;
            btnEditar.BackColor = Color.Gainsboro;


            AbrirFormHijo(new Config());
        }


        private void AbrirFormHijo(object formhijo)
        {
            if (this.panelContenedor.Controls.Count > 0)
            {
                this.panelContenedor.Controls.RemoveAt(0);
            }

            Form fh = formhijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(fh);
            this.panelContenedor.Tag = fh;
            fh.Show();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            btnEditar.BackColor = Color.SteelBlue;
            btnShowRegisters.BackColor = Color.Gainsboro;
            btnHome.BackColor = Color.Gainsboro;
            btnRegister.BackColor = Color.Gainsboro;
            btnConfig.BackColor = Color.Gainsboro;


            AbrirFormHijo(new Update());
        }
    }
}
