using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SportsSite
{

    public class CityStateZip
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zipcode { get; set; }


        public int AddOrUpdateCityStateZip()
        {
            try
            {
                string connectionString = ConfigurationManager.AppSettings["DBConStr"];
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("dbo.SaveCityStateZip", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter IdParam = new SqlParameter();
                    IdParam.ParameterName = "@Id";
                    IdParam.SqlDbType = SqlDbType.Int;
                    IdParam.Direction = ParameterDirection.Input;
                    IdParam.Size = 0;
                    IdParam.Value = this.Id;
                    cmd.Parameters.Add(IdParam);

                    SqlParameter CityParam = new SqlParameter();
                    CityParam.ParameterName = "@City";
                    CityParam.SqlDbType = SqlDbType.VarChar;
                    CityParam.Direction = ParameterDirection.Input;
                    CityParam.Size = 50;
                    if (string.IsNullOrEmpty(this.City))
                        CityParam.Value = DBNull.Value;
                    else
                        CityParam.Value = this.City;
                    cmd.Parameters.Add(CityParam);

                    SqlParameter StateParam = new SqlParameter();
                    StateParam.ParameterName = "@State";
                    StateParam.SqlDbType = SqlDbType.VarChar;
                    StateParam.Direction = ParameterDirection.Input;
                    StateParam.Size = 20;
                    if (string.IsNullOrEmpty(this.State))
                        StateParam.Value = DBNull.Value;
                    else
                        StateParam.Value = this.State;
                    cmd.Parameters.Add(StateParam);

                    SqlParameter ZipcodeParam = new SqlParameter();
                    ZipcodeParam.ParameterName = "@Zipcode";
                    ZipcodeParam.SqlDbType = SqlDbType.Int;
                    ZipcodeParam.Direction = ParameterDirection.Input;
                    ZipcodeParam.Size = 0;
                    ZipcodeParam.Value = this.Zipcode;
                    cmd.Parameters.Add(ZipcodeParam);

                    cmd.ExecuteNonQuery();
                }
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        public CityStateZip SelectById(int keyId)
        {
            try
            {
                this.Id = keyId;
                string connectionString = ConfigurationManager.AppSettings["DBConStr"];
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("dbo.GetCityStateZip", conn);
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
                        this.City = Convert.ToString(reader["City"] == DBNull.Value ? string.Empty : reader["City"]);
                        this.State = Convert.ToString(reader["State"] == DBNull.Value ? string.Empty : reader["State"]);
                        this.Zipcode = Convert.ToInt32(reader["Zipcode"] == DBNull.Value ? "0" : reader["Zipcode"]);
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
                    SqlCommand cmd = new SqlCommand("dbo.DeleteCityStateZip", conn);
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