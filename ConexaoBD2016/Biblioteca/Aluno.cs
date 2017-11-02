using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Aluno
    {
        private int matricula;

        public int Matricula
        {
            get { return matricula; }
            set { matricula = value; }
        }

        private string nome;

        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }
    }
}
