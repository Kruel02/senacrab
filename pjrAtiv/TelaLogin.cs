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
using System.Security.Cryptography;

namespace pjrAtiv
{
    public partial class TelaLogin : Form
    {
        MethodCall call;
        Conta conta;
        Cliente cliente;
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

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "ValidarLogin48";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = "workstation id=JukabankMOISES.mssql.somee.com;packet size=4096;user id=Moises90_SQLLogin_1;pwd=tjnwoa1ips;data source=JukabankMOISES.mssql.somee.com;persist security info=False;initial catalog=JukabankMOISES";

            cmd.Connection = conexao;
            conexao.Open();

            //limpando parametros
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("cpf", TxtNome.Text);
            cmd.Parameters.AddWithValue("senha", TxtSenha.Text);

            SqlDataReader leitor = cmd.ExecuteReader();

            if (leitor.HasRows) 
            {
                leitor.Read();

                TxtNome.Text = leitor.GetString("ClienteCPF");
                TxtSenha.Text = leitor.GetString("ClienteSenha");

                MessageBox.Show("bem vindo"  + "" + leitor.GetString(1));



            }
            else
            {
                MessageBox.Show("Não logou.");
            }
            conexao.Close();
            leitor.Close();
          

           
          
           


            
            

                    //verificar se há linhas retornadas do leitor
                   

            //f.loginToolStripMenuItem.Enabled = false;
            call.MenuStrips("menuStrip1", "loginToolStripMenuItem", false);
            call.MenuStrips("menuStrip1", "logOutToolStripMenuItem", true);


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
                                if(SubMenu.Name == "logOutToolStripMenuItem") 
                                {
                                    SubMenu.Enabled = false;
                                }
                                
                            }

                        }

                    }


                }
            }

        }

    }


}

