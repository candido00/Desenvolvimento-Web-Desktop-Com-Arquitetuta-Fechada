using Biblioteca;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AplicacaoForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                
                //as validações deverão estar antes deste bloco de código, viu alunos!!!
                AlunoBDSqlServerParametros conn = new AlunoBDSqlServerParametros();
                Aluno a = new Aluno();
                a.Matricula = Int32.Parse(textBoxMatricula.Text);
                a.Nome = textBoxNome.Text;
                conn.Insert(a);
                MessageBox.Show("Cadastrou");
                textBoxMatricula.Clear();
                textBoxNome.Clear();
                textBoxMatricula.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problema: " + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Aluno a = new Aluno();
                List<Aluno> retorno;
                AlunoBDSqlServerParametros conn = new AlunoBDSqlServerParametros();
                retorno = conn.Select(a);
                for (int i = 0; i < retorno.Count; i++)
                {
                    Aluno a2 = retorno.ElementAt(i);
                    listBox1.Items.Add(a2.Matricula + " - "+a2.Nome);
                }

            }
            catch (Exception ex)
            {

            }
        }
    }
}
