using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SportsSite
{

    public class User
    {
        public int Id { get; set; }
        public int UserTypeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string EmailId { get; set; }
        public int ParentId { get; set; }


        public int AddOrUpdateUser()
        {
            try
            {
                string connectionString = ConfigurationManager.AppSettings["DBConStr"];
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("dbo.SaveUser", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter IdParam = new SqlParameter();
                    IdParam.ParameterName = "@Id";
                    IdParam.SqlDbType = SqlDbType.Int;
                    IdParam.Direction = ParameterDirection.Input;
                    IdParam.Size = 0;
                    IdParam.Value = this.Id;
                    cmd.Parameters.Add(IdParam);

                    SqlParameter UserTypeIdParam = new SqlParameter();
                    UserTypeIdParam.ParameterName = "@UserTypeId";
                    UserTypeIdParam.SqlDbType = SqlDbType.Int;
                    UserTypeIdParam.Direction = ParameterDirection.Input;
                    UserTypeIdParam.Size = 0;
                    UserTypeIdParam.Value = this.UserTypeId;
                    cmd.Parameters.Add(UserTypeIdParam);

                    SqlParameter FirstNameParam = new SqlParameter();
                    FirstNameParam.ParameterName = "@FirstName";
                    FirstNameParam.SqlDbType = SqlDbType.VarChar;
                    FirstNameParam.Direction = ParameterDirection.Input;
                    FirstNameParam.Size = 100;
                    if (string.IsNullOrEmpty(this.FirstName))
                        FirstNameParam.Value = DBNull.Value;
                    else
                        FirstNameParam.Value = this.FirstName;
                    cmd.Parameters.Add(FirstNameParam);

                    SqlParameter LastNameParam = new SqlParameter();
                    LastNameParam.ParameterName = "@LastName";
                    LastNameParam.SqlDbType = SqlDbType.VarChar;
                    LastNameParam.Direction = ParameterDirection.Input;
                    LastNameParam.Size = 100;
                    if (string.IsNullOrEmpty(this.LastName))
                        LastNameParam.Value = DBNull.Value;
                    else
                        LastNameParam.Value = this.LastName;
                    cmd.Parameters.Add(LastNameParam);

                    SqlParameter UserNameParam = new SqlParameter();
                    UserNameParam.ParameterName = "@UserName";
                    UserNameParam.SqlDbType = SqlDbType.VarChar;
                    UserNameParam.Direction = ParameterDirection.Input;
                    UserNameParam.Size = 100;
                    if (string.IsNullOrEmpty(this.UserName))
                        UserNameParam.Value = DBNull.Value;
                    else
                        UserNameParam.Value = this.UserName;
                    cmd.Parameters.Add(UserNameParam);

                    SqlParameter PasswordParam = new SqlParameter();
                    PasswordParam.ParameterName = "@Password";
                    PasswordParam.SqlDbType = SqlDbType.VarChar;
                    PasswordParam.Direction = ParameterDirection.Input;
                    PasswordParam.Size = 10;
                    if (string.IsNullOrEmpty(this.Password))
                        PasswordParam.Value = DBNull.Value;
                    else
                        PasswordParam.Value = this.Password;
                    cmd.Parameters.Add(PasswordParam);

                    SqlParameter EmailIdParam = new SqlParameter();
                    EmailIdParam.ParameterName = "@EmailId";
                    EmailIdParam.SqlDbType = SqlDbType.VarChar;
                    EmailIdParam.Direction = ParameterDirection.Input;
                    EmailIdParam.Size = 50;
                    if (string.IsNullOrEmpty(this.EmailId))
                        EmailIdParam.Value = DBNull.Value;
                    else
                        EmailIdParam.Value = this.EmailId;
                    cmd.Parameters.Add(EmailIdParam);

                    SqlParameter ParentIdParam = new SqlParameter();
                    ParentIdParam.ParameterName = "@ParentId";
                    ParentIdParam.SqlDbType = SqlDbType.Int;
                    ParentIdParam.Direction = ParameterDirection.Input;
                    ParentIdParam.Size = 0;
                    ParentIdParam.Value = this.ParentId;
                    cmd.Parameters.Add(ParentIdParam);

                    cmd.ExecuteNonQuery();
                }
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        public User SelectById(int keyId)
        {
            try
            {
                this.Id = keyId;
                string connectionString = ConfigurationManager.AppSettings["DBConStr"];
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("dbo.GetUser", conn);
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
                        this.UserTypeId = Convert.ToInt32(reader["UserTypeId"] == DBNull.Value ? "0" : reader["UserTypeId"]);
                        this.FirstName = Convert.ToString(reader["FirstName"] == DBNull.Value ? string.Empty : reader["FirstName"]);
                        this.LastName = Convert.ToString(reader["LastName"] == DBNull.Value ? string.Empty : reader["LastName"]);
                        this.UserName = Convert.ToString(reader["UserName"] == DBNull.Value ? string.Empty : reader["UserName"]);
                        this.Password = Convert.ToString(reader["Password"] == DBNull.Value ? string.Empty : reader["Password"]);
                        this.EmailId = Convert.ToString(reader["EmailId"] == DBNull.Value ? string.Empty : reader["EmailId"]);
                        this.ParentId = Convert.ToInt32(reader["ParentId"] == DBNull.Value ? "0" : reader["ParentId"]);
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
                    SqlCommand cmd = new SqlCommand("dbo.DeleteUser", conn);
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