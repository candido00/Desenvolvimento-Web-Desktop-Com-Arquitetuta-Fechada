using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    //esta classe herda da classe de conexão e implementa suas respectivas funcionalidades
    public class AlunoBDSqlServer :ConexaoSqlServer
    {
        public void Insert(Aluno aluno)
        {
            try
            {
                //abrir a conexão
                this.abrirConexao();
                string sql = "insert into aluno (matricula,nome) values(" + aluno.Matricula + ",'" + aluno.Nome + "')";
                //instrucao a ser executada
                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);
                //executando a instrucao 
                cmd.ExecuteNonQuery();
                //liberando a memoria 
                cmd.Dispose();
                //fechando a conexao
                this.fecharConexao();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao conecar e inserir " + ex.Message);
            }
        }

        public void Update(Aluno aluno)
        {
            try
            {
                //abrir a conexão
                this.abrirConexao();
                string sql = "update aluno set matricula = " + aluno.Matricula + ",nome = '" + aluno.Nome + "' where matricula = " + aluno.Matricula;
                //instrucao a ser executada
                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);
                //executando a instrucao 
                cmd.ExecuteNonQuery();
                //liberando a memoria 
                cmd.Dispose();
                //fechando a conexao
                this.fecharConexao();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao conecar e atualizar " + ex.Message);
            }
        }

        public void Delete(Aluno aluno)
        {
            try
            {
                //abrir a conexão
                this.abrirConexao();
                string sql = "delete from aluno where matricula = " + aluno.Matricula;
                //instrucao a ser executada
                SqlCommand cmd = new SqlCommand(sql, this.sqlConn);
                //executando a instrucao 
                cmd.ExecuteNonQuery();
                //liberando a memoria 
                cmd.Dispose();
                //fechando a conexao
                this.fecharConexao();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao conecar e remover " + ex.Message);
            }
        }

        public bool VerificaDuplicidade(Aluno aluno)
        {
            bool retorno = false;
            try
            {
                this.abrirConexao();
                //instrucao a ser executada
                string sql = "SELECT matricula,nome FROM aluno where matricula = " + aluno.Matricula;
                SqlCommand cmd = new SqlCommand(sql, sqlConn);
                //executando a instrucao e colocando o resultado em um leitor
                SqlDataReader DbReader = cmd.ExecuteReader();
                //lendo o resultado da consulta
                while (DbReader.Read())
                {
                    retorno = true;
                    break;
                }
                //fechando o leitor de resultados
                DbReader.Close();
                //liberando a memoria 
                cmd.Dispose();
                //fechando a conexao
                this.fecharConexao();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao conecar e selecionar " + ex.Message);
            }
            return retorno;
        }

        public List<Aluno> Select(Aluno filtro)
        {
            List<Aluno> retorno = new List<Aluno>();
            try
            {
                this.abrirConexao();
                //instrucao a ser executada
                string sql = "SELECT matricula,nome FROM aluno where matricula = matricula ";
                //se foi passada uma matricula válida, esta matricula entrará como critério de filtro
                if (filtro.Matricula > 0)
                {
                    sql += " and matricula = " + filtro.Matricula;
                }
                //se foi passada um nome válido, este nome entrará como critério de filtro
                if (filtro.Nome != null && filtro.Nome.Trim().Equals("") == false)
                {
                    sql += " and nome like '%" + filtro.Nome + "%'";
                }
                SqlCommand cmd = new SqlCommand(sql, sqlConn);
                //executando a instrucao e colocando o resultado em um leitor
                SqlDataReader DbReader = cmd.ExecuteReader();
                //lendo o resultado da consulta
                while (DbReader.Read())
                {
                    Aluno aluno = new Aluno();
                    //acessando os valores das colunas do resultado
                    aluno.Matricula = DbReader.GetInt32(DbReader.GetOrdinal("matricula"));
                    aluno.Nome = DbReader.GetString(DbReader.GetOrdinal("nome"));
                    retorno.Add(aluno);
                }
                //fechando o leitor de resultados
                DbReader.Close();
                //liberando a memoria 
                cmd.Dispose();
                //fechando a conexao
                this.fecharConexao();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao conecar e selecionar " + ex.Message);
            }
            return retorno;
        }
    }
}
