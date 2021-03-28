using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XYZ.Domain.SpModels;

namespace XYZ.Services
{
    public interface IHomeService
    {
        Task<List<SpHabitacionFiltro>> GetSpHabitacionRangoFechas(string fechaInicio,string fechaFinal,Guid hotelId,int numeroPersonas);
        Task<SpTarifaCancelar> GetTarifaCancelar();
    }

    public class HomeService : IHomeService
    {
        #region Miembro
        private readonly string _connectionString;
        private readonly string Key = "BdXYZ";
        #endregion

        #region Constructor
        public HomeService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString(Key);
        }
        #endregion

        #region Metodos

        public async Task<List<SpHabitacionFiltro>> GetSpHabitacionRangoFechas(string fechaInicio, string fechaFinal, Guid hotelId, int numeroPersonas) 
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SpHabitacionFiltro", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@fechaInicio", fechaInicio));
                    cmd.Parameters.Add(new SqlParameter("@fechaFin", fechaFinal));
                    cmd.Parameters.Add(new SqlParameter("@hotelId", hotelId));
                    cmd.Parameters.Add(new SqlParameter("@numeroPersona", numeroPersonas));
                    var response = new List<SpHabitacionFiltro>();
                    await sql.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(MapToSpHabitacionFiltro(reader)); 
                        }
                    }
                    return response;
                }
            }
        }
        public async Task<SpTarifaCancelar> GetTarifaCancelar()
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("sp_TarifaCancelar", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    SpTarifaCancelar response = new SpTarifaCancelar();
                    await sql.OpenAsync();
                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response = MapToValue(reader);
                        }
                    }
                    return response;
                }
            }
        }
        #endregion

        #region Private


        private SpHabitacionFiltro MapToSpHabitacionFiltro(SqlDataReader reader)
        {
            return new SpHabitacionFiltro()
            {
                IdHotel = (Guid)reader["IdHotel"],
                NombreHotel = reader["NombreHotel"].ToString(),
                IdHabitacion = (int)reader["IdHabitacion"],
                NombreHabitacion = reader["NombreHabitacion"].ToString(),
                TemporadaId = (Guid)reader["TemporadaId"],
                NombreTemporada = reader["NombreTemporada"].ToString(),
                Tarifa = (int)reader["Tarifa"],
                Capacidad = (int)reader["Capacidad"],
                DescripcionHabitacion = reader["DescripcionHabitacion"].ToString(),
                IdTipoHabitacion = (Guid)reader["IdTipoHabitacion"],
                FechaEntrega = reader["FechaEntrega"].ToString(),
                FechaSalida = reader["FechaSalida"].ToString()
            };
        }


        private SpTarifaCancelar MapToValue(SqlDataReader reader)
        {
            return new SpTarifaCancelar()
            {
                Nombre = reader["Nombre"].ToString()
            };
        }


        #endregion
    }
}
