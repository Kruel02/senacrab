﻿using pjrAtiv.Classes;
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
using DTO;
using DAL;
using System.Security.Cryptography.X509Certificates;
using System.Data.SqlClient;

namespace pjrAtiv
{

    public partial class Banco : Form
    {
        public Banco()
        {
            InitializeComponent();
            this.MinimizeBox = false;
            this.MaximizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Height = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height / 2;
            this.Width = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width / 2;
            logOutToolStripMenuItem.Enabled = false;



        }
        MethodCall call;
        SqlCommand cmd = new SqlCommand();




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
            cmd.CommandText = "UpdateTime";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = "workstation id=JukabankMOISES.mssql.somee.com;packet size=4096;user id=Moises90_SQLLogin_1;pwd=tjnwoa1ips;data source=JukabankMOISES.mssql.somee.com;persist security info=False;initial catalog=JukabankMOISES";

            cmd.Connection = conexao;
            conexao.Open();

            //limpando parametros
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("UltimoLogin", DateTime.Now);
            cmd.Parameters.AddWithValue("idCliente", UsuarioLogado.Id);



            Int32 rowsAffected = cmd.ExecuteNonQuery();



            if (rowsAffected == -1)
            {
                MessageBox.Show("Não Atualizou, mas deslogou" + rowsAffected);


            }
            else
            {
                MessageBox.Show(rowsAffected.ToString() + UsuarioLogado.CPF);
            }
            conexao.Close();
            UsuarioLogado.Deslogar();


        }

        private void fecharToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cmd.CommandText = "UpdateTime";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = "workstation id=JukabankMOISES.mssql.somee.com;packet size=4096;user id=Moises90_SQLLogin_1;pwd=tjnwoa1ips;data source=JukabankMOISES.mssql.somee.com;persist security info=False;initial catalog=JukabankMOISES";

            cmd.Connection = conexao;
            conexao.Open();

            //limpando parametros
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("UltimoLogin", DateTime.Now);
            cmd.Parameters.AddWithValue("idCliente", UsuarioLogado.Id);



            Int32 rowsAffected = cmd.ExecuteNonQuery();
            conexao.Close();

            Application.Exit();
        }

        private void Fechar(object sender, FormClosingEventArgs e)
        {
            cmd.CommandText = "UpdateTime";
            cmd.CommandType = CommandType.StoredProcedure;
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = "workstation id=JukabankMOISES.mssql.somee.com;packet size=4096;user id=Moises90_SQLLogin_1;pwd=tjnwoa1ips;data source=JukabankMOISES.mssql.somee.com;persist security info=False;initial catalog=JukabankMOISES";

            cmd.Connection = conexao;
            conexao.Open();

            //limpando parametros
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("UltimoLogin", DateTime.Now);
            cmd.Parameters.AddWithValue("idCliente", UsuarioLogado.Id);



            Int32 rowsAffected = cmd.ExecuteNonQuery();
            conexao.Close();
            Application.Exit();

        }

        private void criarContaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CriarConta CadastrarConta;
            CadastrarConta = new CriarConta();
            CadastrarConta.MdiParent = this;
            CadastrarConta.Show();
        }

        private void alterarDadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AtualizarCadastro Atualizar = new AtualizarCadastro();

            Atualizar.MdiParent = this;
            Atualizar.Show();

        }

        private void depositoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}

