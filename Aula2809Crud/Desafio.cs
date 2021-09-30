using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Aula2809Crud
{
    public partial class Desafio : Form
    {
        public Desafio()
        {
            InitializeComponent();
        }

        private void Desafio_Load(object sender, EventArgs e)
        {
            txtNomeDesafio.Enabled = false;
        }

        private void btnNovoDesafio_Click(object sender, EventArgs e)
        {
            txtNomeDesafio.Enabled = true;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            SqlConnection conn = Conexao.obterConexao();

            string nomeDesafio = txtNomeDesafio.Text;

            string strSql = $"INSERT INTO testetb (nome) VALUES ('{nomeDesafio}');";

            SqlCommand objComandoSql = new SqlCommand(strSql, conn);

            objComandoSql.ExecuteNonQuery();
        }
    }
}