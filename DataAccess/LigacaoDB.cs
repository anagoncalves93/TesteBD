using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class LigacaoDB
    {

        private SqlConnection ligacao;

        public SqlConnection Ligacao
        {
            get { return this.ligacao; }
            set { }
        }

        public string lerConnectionString()
        {
            string connection = "";
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\connectionString.txt";
            if (File.Exists(path))
            {
                string connectionString = File.ReadAllText(path);

                connection = connectionString.ToString();

            }

            return connection;
        }

        public LigacaoDB()
        {
            string connectionS = lerConnectionString();


            ligacao = new SqlConnection(connectionS);
        }

        public void ligacaoBD()
        {
            try
            {
                if (!this.ligacao.State.Equals(ConnectionState.Open))
                {
                    this.ligacao.Open();
                    System.Diagnostics.Debug.WriteLine("Ligado com sucesso");
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("Já existe uma ligação activa");
                }
            }
            catch (SqlException)
            {
                System.Diagnostics.Debug.WriteLine("Falhou a estabelecer a ligação!");
                if (this.ligacao != null)
                    this.ligacao.Dispose();
            }
            catch (Exception)
            {
                System.Diagnostics.Debug.WriteLine("Falhou a estabelecer a ligação!");
                if (this.ligacao != null)
                    this.ligacao.Dispose();
            }
        }

        public ConnectionState Estado
        {
            get { return this.ligacao.State; }
            set { }
        }

        public void desligarDB()
        {
            try
            {
                if (this.ligacao.State.Equals(ConnectionState.Open))
                {
                    this.ligacao.Close();
                    System.Diagnostics.Debug.WriteLine("Desligado com sucesso");
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("Não existe ligação activa");
                }
            }
            catch (SqlException)
            {
                System.Diagnostics.Debug.WriteLine("Falhou ao terminar a ligação!");
                if (this.ligacao != null)
                    this.ligacao.Dispose();
            }
            catch (Exception)
            {
                System.Diagnostics.Debug.WriteLine("Falhou ao terminar a ligação!");
                if (this.ligacao != null)
                    this.ligacao.Dispose();
            }
        }

    }
}
