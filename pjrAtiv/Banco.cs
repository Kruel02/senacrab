using pjrAtiv.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pjrAtiv
{

    public partial class Banco : Form
    {
        public Banco()
        {
            InitializeComponent();
            this.Height = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
            this.Width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            logOutToolStripMenuItem.Enabled = false;

        }
        MethodCall call;

        private void cadastroToolStripMenuItem_Click(object sender, EventArgs e)
        {

            TelaCadastro cadastro = new TelaCadastro();



            if (Application.OpenForms.OfType<TelaCadastro>().Any())
            {
                Application.OpenForms.OfType<TelaCadastro>().First().Close();



            }
            cadastro.MdiParent = this;
            cadastro.Show();
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {


            TelaLogin login = new TelaLogin();
            login.StartPosition = FormStartPosition.WindowsDefaultLocation;


            if (Application.OpenForms.OfType<TelaLogin>().Any())
            {

                Application.OpenForms.OfType<TelaLogin>().First().Close();


            }


            login.MdiParent = this;


            login.Show();



        }

        private void Banco_Load(object sender, EventArgs e)
        {

        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            call = new MethodCall();

            call.Controls = this.Controls;
            call.MenuStrips("menuStrip1", "logOutToolStripMenuItem", false);
            call.MenuStrips("menuStrip1", "loginToolStripMenuItem", true);



        }

        private void fecharToolStripMenuItem_Click(object sender, EventArgs e)
        {   
            Application.Exit();
        }
    }
}

