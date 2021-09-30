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
    public partial class frmCadAtendente : Form
    {
        public frmCadAtendente()
        {
            InitializeComponent();
        }

        private void limparTextBoxes(Control.ControlCollection controles)
        {
            //Faz um laço para todos os controles passados no parâmetro
            foreach (Control ctrl in controles)
            {
                //Se o contorle for um TextBox...
                if (ctrl is TextBox)
                {
                    ((TextBox)(ctrl)).Text = String.Empty;
                }
            }
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            habilitarCampos();
            btnNovo.Enabled = false;
            btnSalvar.Enabled = true;

        }

        private void habilitarCampos()
        {
            txtNome.Enabled = true;
            txtLogin.Enabled = true;
            txtSenha.Enabled = true;
            txtNome.Focus();

        }

        private void desabilitaCampos()
        {
            txtNome.Enabled = false;
            txtLogin.Enabled = false;
            txtSenha.Enabled = false;
            btnAlterar.Enabled = false;
            btnCancelar.Enabled = false;
            btnRemover.Enabled = false;
            btnSalvar.Enabled = false;
        }

        private void btnTestaCon_Click(object sender, EventArgs e)
        {
            // vamos obter a conexão com o banco de dados
            SqlConnection conn = Conexao.obterConexao();

            // a conexão foi efetuada com sucesso?
            if (conn == null)
            {
                MessageBox.Show("Não foi possível obter a conexão. Veja o log de erros.");
            }
            else
            {
                MessageBox.Show("A conexão foi obtida com sucesso.");
            }

            // não precisamos mais da conexão? vamos fechá-la
            Conexao.fecharConexao();
        }

        private void carregarAtendente()
        {
            lblCodigo.Text = dgvfunc.SelectedRows[0].Cells[0].Value.ToString();
            txtLogin.Text = dgvfunc.SelectedRows[0].Cells[1].Value.ToString();
            txtNome.Text = dgvfunc.SelectedRows[0].Cells[3].Value.ToString();
            txtSenha.Text = dgvfunc.SelectedRows[0].Cells[2].Value.ToString();
            habilitarCampos();
            btnNovo.Enabled = false;
            btnSalvar.Enabled = false;
            btnAlterar.Enabled = true;
            btnRemover.Enabled = true;
            btnCancelar.Enabled = true;
            btnLimpar.Enabled = false;
        }

        private void frmCadAtendente_Load(object sender, EventArgs e)
        {
            desabilitaCampos();
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            limparTextBoxes(this.Controls);
        }

        private void btnSalvar_Click_1(object sender, EventArgs e)
        {
        SqlConnection conn = Conexao.obterConexao();
        SqlCommand objComandoSql = new SqlCommand();

        objComandoSql.Connection = conn;

        btnNovo.Enabled = false;
            if (txtNome.Text == "")
            {
                MessageBox.Show("Obrigatório campos NOME");
                txtNome.Focus();
            }
            else if (txtLogin.Text == "")
            {
                MessageBox.Show("Obrigatório campo Login");
                txtLogin.Focus();
            }
            else if (txtSenha.Text == "")
            {
                MessageBox.Show("Obrigatório campo Senha");
                txtSenha.Focus();
            }
            else
            {
                try
                {
                    string login = txtLogin.Text;
                    string nome = txtNome.Text;
                    string senha = txtSenha.Text;

                    string strSql = $"insert into tbl_atendente (login_atendente,senha_atendente,nome_atendente)" +
                        $" values ('{login}','{senha}','{nome}')";

                    objComandoSql = new SqlCommand(strSql, conn);
                    //conn.Open();
                    objComandoSql.ExecuteNonQuery();

                    
                    //limpar após salvar (ainda não está funcionando, preciso revisar)
                    //foreach (Control con in Controls.OfType<TextBox>())
                    //{
                    //    con.Text = "";
                    //}

                }
                
                catch (Exception erro)
                {
                    MessageBox.Show("" + erro);
                    conn.Close();
                }
                
                finally
                {
                    conn.Close();
                }
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            SqlConnection conn = Conexao.obterConexao();
            SqlCommand objComandoSql = new SqlCommand();

            btnRemover.Enabled = true;

            objComandoSql.Connection = conn;
            if (txtBuscar.Text != "")
            {
                try
                {
                    objComandoSql.CommandText = $"Select * from tbl_atendente where nome_atendente like '%{txtBuscar.Text}%' or login_atendente like '%{txtBuscar.Text}%';";
                    objComandoSql.Connection = conn;


                    //recebe os dados de uma tabela apos a execução de uma select
                    SqlDataAdapter da = new SqlDataAdapter();

                    DataTable dt = new DataTable();


                    //recebe os dados da instrução select
                    da.SelectCommand = objComandoSql;
                    da.Fill(dt); //preenche o data table

                    dgvfunc.DataSource = dt;

                }
                catch (Exception erro)
                {

                    MessageBox.Show("\n" + erro);
                    conn.Close();
                }
            }
            else
            {
                dgvfunc.DataSource = null;
                conn.Close();
            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            SqlConnection conn = Conexao.obterConexao();
            SqlCommand objComandoSql = new SqlCommand();

            if (txtNome.Text == "")
            {
                MessageBox.Show("Obrigatório campos NOME");
                txtNome.Focus();
            }
            else if (txtLogin.Text == "")
            {
                MessageBox.Show("LOGIN  Vazio");
                txtLogin.Focus();
            }
            else if (txtSenha.Text == "" && txtSenha.Text.Length < 8)
            {
                MessageBox.Show("Senha Vazia / menos de 8 caractres");
                txtSenha.Focus();
            }
            else
            {
                try
                {
                    string login = txtLogin.Text;
                    string senha = txtSenha.Text;
                    string nome = txtNome.Text;
                    int cd = Convert.ToInt32(lblCodigo.Text);

                    string strSql = "update tbl_atendente set login_atendente = @login,senha_atendente=@senha,nome_atendente=@nome where id_atendente=@cd";

                    objComandoSql.CommandText = strSql;
                    objComandoSql.Connection = conn;

                    objComandoSql.Parameters.Add("@login", SqlDbType.VarChar).Value = login;
                    objComandoSql.Parameters.Add("@senha", SqlDbType.Char).Value = senha;
                    objComandoSql.Parameters.Add("@nome", SqlDbType.VarChar).Value = nome;
                    objComandoSql.Parameters.Add("@cd", SqlDbType.Int).Value = cd;

                    objComandoSql.ExecuteNonQuery();
                    objComandoSql.Parameters.Clear();


                    MessageBox.Show("Dados alterados com sucesso");

                    dgvfunc.Refresh();

                    //limparCampos();

                }
                catch (Exception erro)
                {
                    MessageBox.Show("Algo deu Ruim\n" + erro.Message);
                    conn.Close();
                }
                finally
                {
                    conn.Close();
                }



            }
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            SqlConnection conn = Conexao.obterConexao();
            SqlCommand objComandoSql = new SqlCommand();

            try
            {   
                if (DialogResult.OK == MessageBox.Show("Tem certeza que deseja apagar?", "Atenção",
               MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
                {
                    int cd = Convert.ToInt32(lblCodigo.Text);
                    string strSql = $"delete from tbl_atendente where id_atendente = {cd};";

                    objComandoSql.CommandText = strSql;
                    objComandoSql.Connection = conn;

                    //string strSql = $"delete from tbl_atendente where cd_atendente={cd}";
                    //objComandoSql.Parameters.Add("@cd", SqlDbType.Int).Value = cd;

                    objComandoSql.ExecuteNonQuery();

                }
            }

            catch (Exception erro)
            {
                MessageBox.Show("Algo deu Ruim\n" + erro.Message);
                conn.Close();
            }
            finally
            {
                conn.Close();
            }

        }

        private void dgvfunc_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            carregarAtendente();
        }
    }
}