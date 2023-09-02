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

            if (TxtSenha.Text == UsuarioLogado.Senha || textBox1.Text == TxtSenha.Text)
            {
                SqlCommand cmd;
                SqlConnection conexao;
                Conta cliente;
                cmd = new SqlCommand();
                conexao = new SqlConnection();
                cliente = new Conta();
                conexao.ConnectionString = "workstation id=JukabankMOISES.mssql.somee.com;packet size=4096;user id=Moises90_SQLLogin_1;pwd=tjnwoa1ips;data source=JukabankMOISES.mssql.somee.com;persist security info=False;initial catalog=JukabankMOISES";
                cmd.Connection = conexao;
                cmd.CommandText = "CadastrarConta";
                cmd.CommandType = CommandType.StoredProcedure;
                conexao.Open();
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("idCliente", UsuarioLogado.Id);
                cmd.Parameters.AddWithValue("TipoConta", CBTipoConta.Text);
                cmd.Parameters.AddWithValue("SaldoConta", Convert.ToDecimal(TxtSalario.Text));
                cmd.Parameters.AddWithValue("statusConta", "Ativa");
                cmd.Parameters.AddWithValue("UltimoLogin", Convert.ToDateTime(DateTime.UtcNow));
                cmd.Parameters.AddWithValue("DataCriacao", Convert.ToDateTime(DateTime.UtcNow));
               // cliente.IdConta = Convert.ToInt32(cmd.ExecuteScalar());
                


                Int32 rowsAffected = cmd.ExecuteNonQuery();


                if (rowsAffected == -1)
                {
                    MessageBox.Show("Não cadastrado" + rowsAffected);
                    conexao.Close();

                }
                else
                {
                    MessageBox.Show("Usuario Cadastrado");
                    conexao.Close();




                }



            }
            


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
