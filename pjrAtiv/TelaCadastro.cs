using pjrAtiv.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using DAL;
using BLL;

namespace pjrAtiv
{

    public partial class TelaCadastro : Form
    {
        MethodCall metodo = new MethodCall();
        public TelaCadastro()
        {
            InitializeComponent();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void TelaCadastro_Load(object sender, EventArgs e)
        {
            MethodCall Metodo = new MethodCall();
        }

        private void CbTipoConta_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void BtnLimpar_Click(object sender, EventArgs e)
        {
            metodo.Controls = this.Controls;
            metodo.LimparTextBoxes();
        }



        private void TxtSenha_TextChanged(object sender, EventArgs e)
        {

        }

        private void BtnCadastrar_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            conn.ConnectionString = "workstation id=JukabankMOISES.mssql.somee.com;packet size=4096;user id=Moises90_SQLLogin_1;pwd=tjnwoa1ips;data source=JukabankMOISES.mssql.somee.com;persist security info=False;initial catalog=JukabankMOISES";
            SqlDataAdapter da;

            cmd.CommandText = "CadastrarCliente";
            cmd.CommandType = CommandType.StoredProcedure;
            conn.Open();
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@nomeCliente", TxtNome.Text);
            cmd.Parameters.AddWithValue("@EnderecoCliente", TxtEndereco.Text);
            cmd.Parameters.AddWithValue("@ClienteNascimento", Convert.ToDateTime(DtNascimento.Text));
            cmd.Parameters.AddWithValue("@CidadeCliente", TxtCidade.Text);
            cmd.Parameters.AddWithValue("@EstadoCliente", CbEstado.Text);
            cmd.Parameters.AddWithValue("@ClienteEmail", TxtEmail.Text);
            cmd.Parameters.AddWithValue("@TelefoneCliente", TxtTelefone.Text);
            cmd.Parameters.AddWithValue("@ClienteRG", TxtRG.Text);
            cmd.Parameters.AddWithValue("@ClienteCPF", TxtCPF.Text);
            cmd.Parameters.AddWithValue("@ClienteSenha", TxtSenha.Text);
            cmd.Parameters.AddWithValue("@DataCriacao", DateTime.Now);
            cmd.Parameters.AddWithValue("@EstadoCivil", CbEstadoCivil.Text);
            cmd.Parameters.AddWithValue("@UltimoLogin", DateTime.Now);

            Int32 rowsAffected = cmd.ExecuteNonQuery();

            if (rowsAffected == -1)
            {
                MessageBox.Show("Não cadastrado" + rowsAffected);


            }
            else
            {
                MessageBox.Show("Usuario Cadastrado");
            }




            conn.Close();

        }

        private void CbEstadoCivil_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TxtRG_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void TxtTelefone_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
