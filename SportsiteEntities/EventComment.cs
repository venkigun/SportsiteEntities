using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace SportsSite
{

    public class EventComment
    {
        public int Id { get; set; }
        public string EventComments { get; set; }
        public int UserId { get; set; }
        public int EventId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }


        public int AddOrUpdateEventComment()
        {
            try
            {
                string connectionString = ConfigurationManager.AppSettings["DBConStr"];
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("dbo.SaveEventComment", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter IdParam = new SqlParameter();
                    IdParam.ParameterName = "@Id";
                    IdParam.SqlDbType = SqlDbType.Int;
                    IdParam.Direction = ParameterDirection.Input;
                    IdParam.Size = 0;
                    IdParam.Value = this.Id;
                    cmd.Parameters.Add(IdParam);

                    SqlParameter EventCommentsParam = new SqlParameter();
                    EventCommentsParam.ParameterName = "@EventComments";
                    EventCommentsParam.SqlDbType = SqlDbType.NVarChar;
                    EventCommentsParam.Direction = ParameterDirection.Input;
                    EventCommentsParam.Size = 500;
                    if (string.IsNullOrEmpty(this.EventComments))
                        EventCommentsParam.Value = DBNull.Value;
                    else
                        EventCommentsParam.Value = this.EventComments;
                    cmd.Parameters.Add(EventCommentsParam);

                    SqlParameter UserIdParam = new SqlParameter();
                    UserIdParam.ParameterName = "@UserId";
                    UserIdParam.SqlDbType = SqlDbType.Int;
                    UserIdParam.Direction = ParameterDirection.Input;
                    UserIdParam.Size = 0;
                    UserIdParam.Value = this.UserId;
                    cmd.Parameters.Add(UserIdParam);

                    SqlParameter EventIdParam = new SqlParameter();
                    EventIdParam.ParameterName = "@EventId";
                    EventIdParam.SqlDbType = SqlDbType.Int;
                    EventIdParam.Direction = ParameterDirection.Input;
                    EventIdParam.Size = 0;
                    EventIdParam.Value = this.EventId;
                    cmd.Parameters.Add(EventIdParam);

                    SqlParameter CreatedByParam = new SqlParameter();
                    CreatedByParam.ParameterName = "@CreatedBy";
                    CreatedByParam.SqlDbType = SqlDbType.Int;
                    CreatedByParam.Direction = ParameterDirection.Input;
                    CreatedByParam.Size = 0;
                    CreatedByParam.Value = this.CreatedBy;
                    cmd.Parameters.Add(CreatedByParam);

                    SqlParameter CreatedOnParam = new SqlParameter();
                    CreatedOnParam.ParameterName = "@CreatedOn";
                    CreatedOnParam.SqlDbType = SqlDbType.DateTime;
                    CreatedOnParam.Direction = ParameterDirection.Input;
                    CreatedOnParam.Size = 0;
                    if (this.CreatedOn == null || this.CreatedOn == new DateTime())
                        CreatedOnParam.Value = DBNull.Value;
                    else
                        CreatedOnParam.Value = this.CreatedOn;
                    cmd.Parameters.Add(CreatedOnParam);

                    SqlParameter ModifiedByParam = new SqlParameter();
                    ModifiedByParam.ParameterName = "@ModifiedBy";
                    ModifiedByParam.SqlDbType = SqlDbType.Int;
                    ModifiedByParam.Direction = ParameterDirection.Input;
                    ModifiedByParam.Size = 0;
                    ModifiedByParam.Value = this.ModifiedBy;
                    cmd.Parameters.Add(ModifiedByParam);

                    SqlParameter ModifiedOnParam = new SqlParameter();
                    ModifiedOnParam.ParameterName = "@ModifiedOn";
                    ModifiedOnParam.SqlDbType = SqlDbType.DateTime;
                    ModifiedOnParam.Direction = ParameterDirection.Input;
                    ModifiedOnParam.Size = 0;
                    if (this.ModifiedOn == null || this.ModifiedOn == new DateTime())
                        ModifiedOnParam.Value = DBNull.Value;
                    else
                        ModifiedOnParam.Value = this.ModifiedOn;
                    cmd.Parameters.Add(ModifiedOnParam);

                    cmd.ExecuteNonQuery();
                }
                return 1;
            }
            catch
            {
                return 0;
            }
        }
        public EventComment SelectById(int keyId)
        {
            try
            {
                this.Id = keyId;
                string connectionString = ConfigurationManager.AppSettings["DBConStr"];
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("dbo.GetEventComment", conn);
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
                        this.EventComments = Convert.ToString(reader["EventComments"] == DBNull.Value ? string.Empty : reader["EventComments"]);
                        this.UserId = Convert.ToInt32(reader["UserId"] == DBNull.Value ? "0" : reader["UserId"]);
                        this.EventId = Convert.ToInt32(reader["EventId"] == DBNull.Value ? "0" : reader["EventId"]);
                        this.CreatedBy = Convert.ToInt32(reader["CreatedBy"] == DBNull.Value ? "0" : reader["CreatedBy"]);
                        this.CreatedOn = Convert.ToDateTime(reader["CreatedOn"] == DBNull.Value ? new DateTime() : reader["CreatedOn"]);
                        this.ModifiedBy = Convert.ToInt32(reader["ModifiedBy"] == DBNull.Value ? "0" : reader["ModifiedBy"]);
                        this.ModifiedOn = Convert.ToDateTime(reader["ModifiedOn"] == DBNull.Value ? new DateTime() : reader["ModifiedOn"]);
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
                    SqlCommand cmd = new SqlCommand("dbo.DeleteEventComment", conn);
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