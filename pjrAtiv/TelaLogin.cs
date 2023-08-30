using pjrAtiv.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BLL;



namespace pjrAtiv
{
    public partial class TelaLogin : Form
    {
        MethodCall call;
        public TelaLogin()
        {

            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            InitializeComponent();
        }

       
        private void TxtNome_TextChanged(object sender, EventArgs e)
        {

        }

        private void Btn_Login_Click(object sender, EventArgs e)
        {
            call = new MethodCall();

            Conta conta = new Conta();
            Banco f = this.MdiParent as Banco;
            //ParentForm.MainMenuStrip.Items[].Enabled = false;


            //ParentForm.MainMenuStrip.Items.Add("teste");
            call.Controls = this.MdiParent.Controls;
            
            //f.loginToolStripMenuItem.Enabled = false;
            call.MenuStrips("menuStrip1", "loginToolStripMenuItem", false);
            call.MenuStrips("menuStrip1", "logOutToolStripMenuItem", true);
            SqlConnection conexao = new SqlConnection();


        }

        private void Strip_ItemAdded(object? sender, ToolStripItemEventArgs e)
        {
            throw new NotImplementedException();
            
        }

        private void TelaLogin_Load(object sender, EventArgs e)
        {

        }


        private void LoginClose(object sender, FormClosedEventArgs e)
        {
            

            Control[] controls = this.MdiParent.Controls.Find("menuStrip1", true);
            foreach (Control control in controls)
            {
                if (control.Name == "menuStrip1")
                {
                    MenuStrip strip = control as MenuStrip;
                    foreach (ToolStripMenuItem SubMenu in strip.Items)
                    {

                        foreach (ToolStripItem SubmenuItem in SubMenu.DropDownItems)
                        {
                            if (SubmenuItem.Name == "loginToolStripMenuItem")
                            {
                                SubmenuItem.Enabled = true;

                            }

                        }

                    }


                }
            }

        }

    }


}

