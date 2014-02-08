using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SportsSite
{

    public class EventAddress
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public int CityId { get; set; }


        public int AddOrUpdateEventAddress()
        {
            try
            {
                string connectionString = ConfigurationManager.AppSettings["DBConStr"];
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("dbo.SaveEventAddress", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter IdParam = new SqlParameter();
                    IdParam.ParameterName = "@Id";
                    IdParam.SqlDbType = SqlDbType.Int;
                    IdParam.Direction = ParameterDirection.Input;
                    IdParam.Size = 0;
                    IdParam.Value = this.Id;
                    cmd.Parameters.Add(IdParam);

                    SqlParameter EventIdParam = new SqlParameter();
                    EventIdParam.ParameterName = "@EventId";
                    EventIdParam.SqlDbType = SqlDbType.Int;
                    EventIdParam.Direction = ParameterDirection.Input;
                    EventIdParam.Size = 0;
                    EventIdParam.Value = this.EventId;
                    cmd.Parameters.Add(EventIdParam);

                    SqlParameter Street1Param = new SqlParameter();
                    Street1Param.ParameterName = "@Street1";
                    Street1Param.SqlDbType = SqlDbType.VarChar;
                    Street1Param.Direction = ParameterDirection.Input;
                    Street1Param.Size = 50;
                    if (string.IsNullOrEmpty(this.Street1))
                        Street1Param.Value = DBNull.Value;
                    else
                        Street1Param.Value = this.Street1;
                    cmd.Parameters.Add(Street1Param);

                    SqlParameter Street2Param = new SqlParameter();
                    Street2Param.ParameterName = "@Street2";
                    Street2Param.SqlDbType = SqlDbType.VarChar;
                    Street2Param.Direction = ParameterDirection.Input;
                    Street2Param.Size = 50;
                    if (string.IsNullOrEmpty(this.Street2))
                        Street2Param.Value = DBNull.Value;
                    else
                        Street2Param.Value = this.Street2;
                    cmd.Parameters.Add(Street2Param);

                    SqlParameter CityIdParam = new SqlParameter();
                    CityIdParam.ParameterName = "@CityId";
                    CityIdParam.SqlDbType = SqlDbType.Int;
                    CityIdParam.Direction = ParameterDirection.Input;
                    CityIdParam.Size = 0;
                    CityIdParam.Value = this.CityId;
                    cmd.Parameters.Add(CityIdParam);

                    cmd.ExecuteNonQuery();
                }
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        public EventAddress SelectById(int keyId)
        {
            try
            {
                this.Id = keyId;
                string connectionString = ConfigurationManager.AppSettings["DBConStr"];
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("dbo.GetEventAddress", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter IdParam = new SqlParameter();
                    IdParam.ParameterName = "@Id";
                    IdParam.SqlDbType = SqlDbType.Int;
                    IdParam.Value = keyId;
                    IdParam.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(IdParam);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {

                        this.Id = Convert.ToInt32(reader["Id"] == DBNull.Value ? "0" : reader["Id"]);
                        this.EventId = Convert.ToInt32(reader["EventId"] == DBNull.Value ? "0" : reader["EventId"]);
                        this.Street1 = Convert.ToString(reader["Street1"] == DBNull.Value ? string.Empty : reader["Street1"]);
                        this.Street2 = Convert.ToString(reader["Street2"] == DBNull.Value ? string.Empty : reader["Street2"]);
                        this.CityId = Convert.ToInt32(reader["CityId"] == DBNull.Value ? "0" : reader["CityId"]);
                    }
                    return this;
                }
            }
            catch
            {
                return null;
            }
        }

        public int DeleteById(int keyId)
        {
            try
            {
                this.Id = keyId;
                string connectionString = ConfigurationManager.AppSettings["DBConStr"];
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("dbo.DeleteEventAddress", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter IdParam = new SqlParameter();
                    IdParam.ParameterName = "@Id";
                    IdParam.SqlDbType = SqlDbType.Int;
                    IdParam.Value = keyId;
                    IdParam.Direction = ParameterDirection.Input;
                    cmd.Parameters.Add(IdParam);
                    int result = cmd.ExecuteNonQuery();
                    return result;
                }
            }
            catch
            {
                return -1;
            }
        }

    }
}