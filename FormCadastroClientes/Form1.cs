using Biblioteca;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormCadastroClientes
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonCadastrar_Click(object sender, EventArgs e)
        {
            
            try

            {
                ClienteBDSqlServer conn = new ClienteBDSqlServer();
                Cliente cli = new Cliente();
                
                cli.Nome = textBoxNome.Text;
                cli.Cpf = maskedTextBoxCpf.Text;
                this.maskedTextBoxCpf.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                cli.Rg = maskedTextBoxRg.Text;
                this.maskedTextBoxRg.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                cli.Nascimento = maskedTextBoxNascimento.Text;
                this.maskedTextBoxNascimento.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                cli.Fone = maskedTextBoxFone.Text;
                this.maskedTextBoxFone.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                cli.Email = textBoxEmail.Text;
                cli.Cep = maskedTextBoxCep.Text;
                this.maskedTextBoxCep.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                cli.Logradouro = textBoxLogradouro.Text;
                cli.Numero = textBoxNumero.Text;
                cli.Bairro = textBoxBairro.Text;
                cli.Cidade = textBoxCidade.Text;
                cli.Uf = comboBoxUf.GetItemText(comboBoxUf.SelectedItem);
                cli.Pai = textBoxPai.Text;
                cli.Mae = textBoxMae.Text;
                
                conn.Insert(cli);
                
                MessageBox.Show("Cadastro efetuado com sucesso!!");


            }
            catch (Exception ex)
            {
                MessageBox.Show("Problema : "+ ex.Message);

            }
            // Creates and initializes a new ArrayList.
             
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBoxUf.DataSource = uf;
        }
        private static ArrayList uf = new ArrayList
        {
            "AC","AL","AP","AM","BA","CE","DF","ES","GO","MA","MT","MS","MG","PA",
            "PB","PR","PE","PI","RJ","RN","RS","RO","RR","SC","SP","SE","TO"
        };
    }
}

