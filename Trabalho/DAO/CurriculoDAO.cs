using Trabalho.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Trabalho.DAO
{
    public class CurriculoDAO
    {
        public void Inserir1(CurriculoViewModel curriculo)
        {
            string sql =
            "insert into CadastroCurriculo(cpf, nome, celular, email, cep, rua, numeroEnd,bairro," +
            "complementoEnd, estado,cargoPretendido)" +
            "values ( @cpf, @nome, @celular, @email, @cep, @rua, @numeroEnd, @bairro," +
            "@complementoEnd, @estado, @cargoPretendido)";
            HelperDAO.ExecutaSQL(sql, CriaParametros1(curriculo));
        }
        public void Inserir2(CurriculoViewModel curriculo)
        {
            string sql =
            "update CadastroCurriculo set formacao = @formacao, " +
            "curso1 = @curso1, "+
            "curso2 = @curso2, "+
            "curso3 = @curso3, "+
            "curso4 = @curso4, "+
            "curso5 = @curso5  where cpf = @cpf";
            HelperDAO.ExecutaSQL(sql, CriaParametros2(curriculo));
        }
        public void Inserir3(CurriculoViewModel curriculo)
        {
            string sql =
            "update CadastroCurriculo set experiencia1 = @experiencia1, " +
            "experiencia1Desde = @experiencia1Desde, " +
            "experiencia2 = @experiencia2," +
            "experiencia2Desde = @experiencia2Desde " +
            "experiencia2Ate = @experiencia2Ate" +
            "experiencia3 = @experiencia3" +
            "experiencia3Desde = @experiencia3Desde" +
            "experiencia3Ate = @experiencia3Ate " +
            "where cpf = @cpf";

            HelperDAO.ExecutaSQL(sql, CriaParametros3(curriculo));
        }
        public void Inserir4(CurriculoViewModel curriculo)
        {
            string sql =
            "update CadastroCurriculo set idioma1 = @idioma1, " +
            "idioma2 = @idioma2, " +
            "idioma3 = @idioma3 " +
            "where cpf = @cpf";
            HelperDAO.ExecutaSQL(sql, CriaParametros4(curriculo));
        }
        /*public void Alterar(CurriculoViewModel curriculo)
        {
            string sql =
            "update CadastroCurriculo set descricao = @descricao, " +
            "valor_locacao = @valor_locacao, " +
            "categoriaid = @categoriaID," +
            "data_aquisicao = @data_aquisicao where id = @id";
            HelperDAO.ExecutaSQL(sql, CriaParametros(curriculo));
        }*/
        private SqlParameter[] CriaParametros1(CurriculoViewModel curriculo)
        {
            SqlParameter[] parametros = new SqlParameter[11];
            parametros[0] = new SqlParameter("cpf", curriculo.cpf);
            parametros[1] = new SqlParameter("nome", curriculo.nome);
            parametros[2] = new SqlParameter("email", curriculo.email);
            parametros[3] = new SqlParameter("cep", curriculo.cep);
            parametros[4] = new SqlParameter("rua", curriculo.rua);
            parametros[5] = new SqlParameter("bairro", curriculo.bairro);
            parametros[6] = new SqlParameter("complementoEnd", curriculo.complementoEnd);
            parametros[7] = new SqlParameter("estado", curriculo.estado);
            parametros[8] = new SqlParameter("cargoPretendido", curriculo.cargoPretendido);
            parametros[9] = new SqlParameter("celular", curriculo.celular);
            parametros[10] = new SqlParameter("numeroEnd", curriculo.numeroEnd);
            return parametros;
        }
        private SqlParameter[] CriaParametros2(CurriculoViewModel curriculo)
        {
            SqlParameter[] parametros = new SqlParameter[7];
            parametros[0] = new SqlParameter("formacao", curriculo.formacao);
            parametros[1] = new SqlParameter("curso1", curriculo.curso1);
            parametros[2] = new SqlParameter("curso2", curriculo.curso2);
            parametros[3] = new SqlParameter("curso3", curriculo.curso3);
            parametros[4] = new SqlParameter("curso4", curriculo.curso4);
            parametros[5] = new SqlParameter("curso5", curriculo.curso5);
            parametros[6] = new SqlParameter("cpf", curriculo.cpf);
            return parametros;
        }
        private SqlParameter[] CriaParametros3(CurriculoViewModel curriculo)
        {
            SqlParameter[] parametros = new SqlParameter[10];
            parametros[0] = new SqlParameter("cpf", curriculo.cpf);
            parametros[1] = new SqlParameter("experiencia1", curriculo.experiencia1);
            parametros[2] = new SqlParameter("experiencia1Desde", curriculo.experiencia1Desde);
            parametros[3] = new SqlParameter("experiencia1Ate", curriculo.experiencia1Ate);
            parametros[4] = new SqlParameter("experiencia2", curriculo.experiencia2);
            parametros[5] = new SqlParameter("experiencia2Desde", curriculo.experiencia2Desde);
            parametros[6] = new SqlParameter("experiencia2Ate", curriculo.experiencia2Ate);
            parametros[7] = new SqlParameter("experiencia3", curriculo.experiencia3);
            parametros[8] = new SqlParameter("experiencia3Desde", curriculo.experiencia3Desde);
            parametros[9] = new SqlParameter("experiencia3Ate", curriculo.experiencia3Ate);
            return parametros;
        }
        private SqlParameter[] CriaParametros4(CurriculoViewModel curriculo)
        {
            SqlParameter[] parametros = new SqlParameter[4];
            parametros[0] = new SqlParameter("cpf", curriculo.cpf);
            parametros[1] = new SqlParameter("idioma1", curriculo.idioma1);
            parametros[2] = new SqlParameter("idioma2", curriculo.idioma2);
            parametros[3] = new SqlParameter("idioma3", curriculo.idioma3);
            return parametros;
        }
        public void Excluir(string cpf)
        {
            string sql = "delete CadastroCurriculo where cpf =" + cpf;
            HelperDAO.ExecutaSQL(sql, null);
        }
        private CurriculoViewModel MontaCurriculo(DataRow registro)
        {
            CurriculoViewModel a = new CurriculoViewModel();
            a.cpf = registro["cpf"].ToString();
            a.nome = registro["nome"].ToString();
            a.rua = registro["rua"].ToString();
            a.cep = Convert.ToInt32(registro["cep"]);
            return a;
        }

        public CurriculoViewModel Consulta(string cpf)
        {
            string sql = "select cpf, nome, rua, cep from CadastroCurriculo where cpf = " + cpf;
            DataTable tabela = HelperDAO.ExecutaSelect(sql, null);
            if (tabela.Rows.Count == 0)
                return null;
            else
                return MontaCurriculo(tabela.Rows[0]);
        }
        public List<CurriculoViewModel> Listagem()
        {
            List<CurriculoViewModel> lista = new List<CurriculoViewModel>();
            string sql = "select * from CadastroCurriculo order by nome";
            DataTable tabela = HelperDAO.ExecutaSelect(sql, null);
            foreach (DataRow registro in tabela.Rows)
                lista.Add(MontaCurriculo(registro));
            return lista;
        }
    }
}