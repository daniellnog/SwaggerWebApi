using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SwaggerWebAPI.Models
{
    public class ParametroValorRepositorio : IParametroValorRepositorio
    {
        private string ConnectionString = "Data Source=10.43.6.160;User Id=teste;Password=teste;Initial Catalog=TDM.Db";
        //private List<Produto> produtos = new List<Produto>();

        public ParametroValorRepositorio()
        {
            //Add(new Produto { Nome = "Guaraná Antartica", Categoria = "Refrigerantes", Preco = 4.59M });
            //Add(new Produto { Nome = "Suco de Laranja Prats", Categoria = "Sucos", Preco = 5.75M });
            //Add(new Produto { Nome = "Mostarda Hammer", Categoria = "Condimentos", Preco = 3.90M });
            //Add(new Produto { Nome = "Molho de Tomate Cepera", Categoria = "Condimentos", Preco = 2.99M });
            //Add(new Produto { Nome = "Suco de Uva Aurora", Categoria = "Sucos", Preco = 6.50M });
            //Add(new Produto { Nome = "Pepsi-Cola", Categoria = "Refrigerantes", Preco = 4.25M });
        }

        public Produto Add(Produto item)
        {
            //if (item == null)
            //{
            //    throw new ArgumentNullException("item");
            //}
            //item.Id = _nextId++;
            //produtos.Add(item);
            return item;
        }

        public ParametroValor Get(int IdTestData)
        {
            ParametroValor pv = new ParametroValor();

            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT pv.Id, pv.IdTestData, pv.Valor, p.ColunaTecnicaTosca, p.Id IdParametro FROM[TDM.Db].[dbo].[ParametroValor] pv INNER JOIN[TDM.Db].[dbo].[ParametroScript] ps on pv.IdParametroScript = ps.Id INNER JOIN[TDM.Db].[dbo].[Parametro] p on ps.IdParametro = p.Id WHERE pv.IdTestData = " + IdTestData + " AND ps.IdTipoParametro = 1";

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        pv = new ParametroValor
                        {
                            Id = reader["Id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["id"]),
                            IdTestData = Convert.ToInt32(reader["IdTestData"]),
                            IdParametro = Convert.ToInt32(reader["IdParametro"]),
                            DescricaoParametro = reader["ColunaTecnicaTosca"].ToString(),
                            Valor = reader["Valor"].ToString()
                        };
                        //pv.Add(ob);
                    }
                }
                connection.Close();
            }
            return pv;
        }

        public IEnumerable<ParametroValor> GetAll()
        {
            List<ParametroValor> parametrosValores = new List<ParametroValor>();

            using (SqlConnection connection = new SqlConnection(this.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT pv.Id, pv.IdTestData, pv.Valor, p.ColunaTecnicaTosca, p.Id IdParametro FROM[TDM.Db].[dbo].[ParametroValor] pv INNER JOIN[TDM.Db].[dbo].[ParametroScript] ps on pv.IdParametroScript = ps.Id INNER JOIN[TDM.Db].[dbo].[Parametro] p on ps.IdParametro = p.Id";

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        ParametroValor pv = new ParametroValor
                        {
                            Id = reader["Id"] == DBNull.Value ? 0 : Convert.ToInt32(reader["id"]),
                            IdTestData = Convert.ToInt32(reader["IdTestData"]),
                            IdParametro = Convert.ToInt32(reader["IdParametro"]),
                            DescricaoParametro = reader["ColunaTecnicaTosca"].ToString(),
                            Valor = reader["Valor"].ToString()
                        };
                        parametrosValores.Add(pv);
                    }
                }
                connection.Close();
            }
            return parametrosValores;
        }
        //return produtos;

        public void Remove(int id)
        {
            //produtos.RemoveAll(p => p.Id == id);
        }

        public bool Update(Produto item)
        {
            //if (item == null)
            //{
            //    throw new ArgumentNullException("item");
            //}

            ////int index = produtos.FindIndex(p => p.Id == item.Id);

            //if (index == -1)
            //{
            //    return false;
            //}
            ////produtos.RemoveAt(index);
            ////produtos.Add(item);
            return true;
        }
    }
}