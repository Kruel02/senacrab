using pjrAtiv.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Timers;

namespace pjrAtiv
{
    public partial class CriarConta : Form
    {


        
        public CriarConta()
        {
            InitializeComponent();
            TxtSenha.Text = 123.ToString();
            textBox1.Text = 123.ToString();
            CBTipoConta.Text = "Correntista";
            TxtSalario.Text = 10000.ToString();





        }

        private void CriarConta_Load(object sender, EventArgs e)
        {


        }

        private void BtnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                if (TxtSenha.Text == UsuarioLogado.Senha || textBox1.Text == TxtSenha.Text)
                {

                    SqlCommand cmd;
                    SqlConnection conexao;
                    Conta cliente;
                    cmd = new SqlCommand();
                    conexao = new SqlConnection();
                    cliente = new Conta(UsuarioLogado.Id, Convert.ToDecimal(TxtSalario.Text), "Ativa");

                    conexao.ConnectionString = "workstation id=JukabankMOISES.mssql.somee.com;packet size=4096;user id=Moises90_SQLLogin_1;pwd=tjnwoa1ips;data source=JukabankMOISES.mssql.somee.com;persist security info=False;initial catalog=JukabankMOISES";
                    cmd.Connection = conexao;
                    cmd.CommandText = "pi_Conta_48";
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("idCorrentista", UsuarioLogado.Id);
                    cmd.Parameters.AddWithValue("TipoConta", CBTipoConta.Text);
                    cmd.Parameters.AddWithValue("saldo", Convert.ToDecimal(TxtSalario.Text));
                    cmd.Parameters.AddWithValue("statusConta", "Ativa");


                    conexao.Open();
                    cliente.IdConta = Convert.ToInt32(cmd.ExecuteScalar());

                    MessageBox.Show(cliente.IdConta.ToString());

                   
                    conexao.Close();

                }
             }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           




            
          


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
