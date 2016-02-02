using DomainModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DescricaoDA
    {
        public static string addDescricao(Descricao d)
        {
            LigacaoDB l = new LigacaoDB();
            l.ligacaoBD();
            SqlCommand cmmd = l.Ligacao.CreateCommand();
            cmmd.Parameters.Add(new SqlParameter("@descricao", d.Descricao1));
            cmmd.Parameters.Add(new SqlParameter("@observacao", d.Observacao));

            cmmd.CommandText = "INSERT INTO [Teste] (descricao, observacao) VALUES (@descricao, @observacao)";
            cmmd.ExecuteNonQuery();

            string command = cmmd.Parameters["@descricao"].Value.ToString() + " " + cmmd.Parameters["@observacao"].Value.ToString();

            l.desligarDB();

            return command;

        }



        public static List<Descricao> getDescricao()
        {
            LigacaoDB l = new LigacaoDB();
            l.ligacaoBD();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM dbo.Teste ", l.Ligacao);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Teste");

            List<Descricao> listDescricao = new List<Descricao>();
            foreach (DataRow row in ds.Tables["Teste"].Rows)
            {
                Descricao desc = new Descricao();
                desc.Id = Convert.ToInt32(row["Id"]);
                desc.Descricao1 = row["descricao"].ToString().Trim();
                desc.Observacao = row["observacao"].ToString().Trim();

                listDescricao.Add(desc);

            }
            return listDescricao;
        }

        public static string updateDescricao(Descricao desc, int idD)
        {
            LigacaoDB l = new LigacaoDB();
            l.ligacaoBD();

            SqlCommand cmmd = l.Ligacao.CreateCommand();
            desc.Id = idD;
            cmmd.Parameters.Add(new SqlParameter("@descricao", desc.Descricao1));
            cmmd.Parameters.Add(new SqlParameter("@observacao", desc.Observacao));


            cmmd.CommandText = "UPDATE Teste SET  descricao= @descricao, observacao=@observacao WHERE Id = " + idD;
            cmmd.ExecuteNonQuery();

            string command =  cmmd.Parameters["@descricao"].Value.ToString() + " " + cmmd.Parameters["@observacao"].Value.ToString();

            l.desligarDB();

            return command;
        }

        public static List<Descricao> getDescricaoEsp(int id)
        {
            
            LigacaoDB l = new LigacaoDB();
            l.ligacaoBD();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM dbo.Teste Where id="+ id, l.Ligacao);
            DataSet ds = new DataSet();
            adapter.Fill(ds, "Teste");

            List<Descricao> listDescricao = new List<Descricao>();
            foreach (DataRow row in ds.Tables["Teste"].Rows)
            {
                Descricao desc = new Descricao();
                desc.Id = Convert.ToInt32(row["Id"]);
                desc.Descricao1 = row["descricao"].ToString().Trim();
                desc.Observacao = row["observacao"].ToString().Trim();

                listDescricao.Add(desc);

            }
            return listDescricao;
        }

        public static string deleteDescricao(Descricao desc, int idD)
        {
            LigacaoDB l = new LigacaoDB();
            l.ligacaoBD();

            SqlCommand cmmd = l.Ligacao.CreateCommand();
            desc.Id = idD;
            cmmd.Parameters.Add(new SqlParameter("@descricao", desc.Descricao1));
            cmmd.Parameters.Add(new SqlParameter("@observacao", desc.Observacao));


            cmmd.CommandText = "DELETE Teste  FROM Teste WHERE Id = " + idD;
            cmmd.ExecuteNonQuery();

            string command = cmmd.Parameters["@descricao"].Value.ToString() + " " + cmmd.Parameters["@observacao"].Value.ToString();

            l.desligarDB();

            return command;
        }
    }
}
