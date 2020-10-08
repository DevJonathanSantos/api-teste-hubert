using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using TesteHubert.Entities;
using TesteHubert.Interfaces;
using TesteHubert.Repositories.Extensions;

namespace TesteHubert.Repositories
{
    public class TesteRepository : ITesteRepository
    {
        public async Task<List<string>> BuscarItemA(int id, string data)
        {
            List<string> itensA = new List<string>();

            using (SqlConnection sqlConnection = new SqlConnection(Constantes.SQLSERVER))
            {
                await sqlConnection.OpenAsync();

                using (SqlCommand sqlCommand = new SqlCommand("dbo.BuscarItemA", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@idCliente", id));
                    sqlCommand.Parameters.Add(new SqlParameter("@data", data));
                    using (var reader = await sqlCommand.ExecuteReaderAsync())
                    {
                        while (reader.Read())
                        {
                            itensA.Add(reader.GetNotNullValue<string>("Compra"));
                        }
                    }
                }
                if (sqlConnection != null && sqlConnection.State != ConnectionState.Closed)
                    sqlConnection.Close();
            }
            return itensA;
        }

        public async Task<List<decimal>> BuscarItemB(int id, string dataInicial, string dataFinal)
        {
            List<decimal> itensB = new List<decimal>();

            using (SqlConnection sqlConnection = new SqlConnection(Constantes.SQLSERVER))
            {
                await sqlConnection.OpenAsync();

                using (SqlCommand sqlCommand = new SqlCommand("dbo.BuscarItemB", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@idCliente", id));
                    sqlCommand.Parameters.Add(new SqlParameter("@dataInicial", dataInicial));
                    sqlCommand.Parameters.Add(new SqlParameter("@dataFinal", dataFinal));
                    using (var reader = await sqlCommand.ExecuteReaderAsync())
                    {
                        while (reader.Read())
                        {
                            itensB.Add(reader.GetNotNullValue<decimal>(""));
                        }
                    }
                }
                if (sqlConnection != null && sqlConnection.State != ConnectionState.Closed)
                    sqlConnection.Close();
            }
            return itensB;
        }

        public async Task<int> BuscarItemC(int id, string dataDePagamento, decimal valorPago)
        {
            int itensC = 0;

            using (SqlConnection sqlConnection = new SqlConnection(Constantes.SQLSERVER))
            {
                await sqlConnection.OpenAsync();

                using (SqlCommand sqlCommand = new SqlCommand("dbo.BuscarItemC", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@idCliente", id));
                    sqlCommand.Parameters.Add(new SqlParameter("@dataDePagamento", dataDePagamento));
                    sqlCommand.Parameters.Add(new SqlParameter("@valorPago", valorPago));

                    using (var reader = await sqlCommand.ExecuteReaderAsync())
                    {
                        while (reader.Read())
                        {
                            itensC=(reader.GetNotNullValue<int>("FaturasPagas"));
                        }
                    }
                }
                if (sqlConnection != null && sqlConnection.State != ConnectionState.Closed)
                    sqlConnection.Close();
            }
            return itensC;
        }
        public async Task<ObjetoD> BuscarItemD(int id)
        {
            ObjetoD itensD = null;

            using (SqlConnection sqlConnection = new SqlConnection(Constantes.SQLSERVER))
            {
                await sqlConnection.OpenAsync();

                using (SqlCommand sqlCommand = new SqlCommand("dbo.BuscarItemD", sqlConnection))
                {
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.Add(new SqlParameter("@idCliente", id));

                    using (var reader = await sqlCommand.ExecuteReaderAsync())
                    { var x = "";
                        while (reader.Read())
                        {
                            itensD = new ObjetoD(reader.GetNotNullValue<string>("Nome"),
                                                reader.GetNotNullValue<string>("Logradouro"),
                                                reader.GetNotNullValue<string>("Cidade"),
                                                reader.GetNotNullValue<string>("UF"));
                        }
                    }
                }
                if (sqlConnection != null && sqlConnection.State != ConnectionState.Closed)
                    sqlConnection.Close();
            }
            return itensD;
        }
    }
}
