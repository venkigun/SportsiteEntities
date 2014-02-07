using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.IO;

namespace SportsiteEntities
{
    public class SEvent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int HostId { get; set; }
        public int TypeId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int HomeTeamId { get; set; }
        public int VisitorTeamId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }


        public int AddOrUpdateEvent()
        {
            try
            {
                string connectionString = ConfigurationManager.AppSettings["DBConStr"];
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("dbo.SaveEvent", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter IdParam = new SqlParameter();
                    IdParam.ParameterName = "@Id";
                    IdParam.SqlDbType = SqlDbType.Int;
                    IdParam.Direction = ParameterDirection.Input;
                    IdParam.Size = 0;
                    IdParam.Value = this.Id;
                    cmd.Parameters.Add(IdParam);

                    SqlParameter NameParam = new SqlParameter();
                    NameParam.ParameterName = "@Name";
                    NameParam.SqlDbType = SqlDbType.VarChar;
                    NameParam.Direction = ParameterDirection.Input;
                    NameParam.Size = 100;
                    if (string.IsNullOrEmpty(this.Name))
                        NameParam.Value = DBNull.Value;
                    else
                        NameParam.Value = this.Name;
                    cmd.Parameters.Add(NameParam);

                    SqlParameter DescriptionParam = new SqlParameter();
                    DescriptionParam.ParameterName = "@Description";
                    DescriptionParam.SqlDbType = SqlDbType.VarChar;
                    DescriptionParam.Direction = ParameterDirection.Input;
                    DescriptionParam.Size = 500;
                    if (string.IsNullOrEmpty(this.Description))
                        DescriptionParam.Value = DBNull.Value;
                    else
                        DescriptionParam.Value = this.Description;
                    cmd.Parameters.Add(DescriptionParam);

                    SqlParameter HostIdParam = new SqlParameter();
                    HostIdParam.ParameterName = "@HostId";
                    HostIdParam.SqlDbType = SqlDbType.Int;
                    HostIdParam.Direction = ParameterDirection.Input;
                    HostIdParam.Size = 0;
                    HostIdParam.Value = this.HostId;
                    cmd.Parameters.Add(HostIdParam);

                    SqlParameter TypeIdParam = new SqlParameter();
                    TypeIdParam.ParameterName = "@TypeId";
                    TypeIdParam.SqlDbType = SqlDbType.Int;
                    TypeIdParam.Direction = ParameterDirection.Input;
                    TypeIdParam.Size = 0;
                    TypeIdParam.Value = this.TypeId;
                    cmd.Parameters.Add(TypeIdParam);

                    SqlParameter StartTimeParam = new SqlParameter();
                    StartTimeParam.ParameterName = "@StartTime";
                    StartTimeParam.SqlDbType = SqlDbType.DateTime;
                    StartTimeParam.Direction = ParameterDirection.Input;
                    StartTimeParam.Size = 0;
                    if (this.StartTime == null || this.StartTime == new DateTime())
                        StartTimeParam.Value = DBNull.Value;
                    else
                        StartTimeParam.Value = this.StartTime;
                    cmd.Parameters.Add(StartTimeParam);

                    SqlParameter EndTimeParam = new SqlParameter();
                    EndTimeParam.ParameterName = "@EndTime";
                    EndTimeParam.SqlDbType = SqlDbType.DateTime;
                    EndTimeParam.Direction = ParameterDirection.Input;
                    EndTimeParam.Size = 0;
                    if (this.EndTime == null || this.EndTime == new DateTime())
                        EndTimeParam.Value = DBNull.Value;
                    else
                        EndTimeParam.Value = this.EndTime;
                    cmd.Parameters.Add(EndTimeParam);

                    SqlParameter HomeTeamIdParam = new SqlParameter();
                    HomeTeamIdParam.ParameterName = "@HomeTeamId";
                    HomeTeamIdParam.SqlDbType = SqlDbType.Int;
                    HomeTeamIdParam.Direction = ParameterDirection.Input;
                    HomeTeamIdParam.Size = 0;
                    HomeTeamIdParam.Value = this.HomeTeamId;
                    cmd.Parameters.Add(HomeTeamIdParam);

                    SqlParameter VisitorTeamIdParam = new SqlParameter();
                    VisitorTeamIdParam.ParameterName = "@VisitorTeamId";
                    VisitorTeamIdParam.SqlDbType = SqlDbType.Int;
                    VisitorTeamIdParam.Direction = ParameterDirection.Input;
                    VisitorTeamIdParam.Size = 0;
                    VisitorTeamIdParam.Value = this.VisitorTeamId;
                    cmd.Parameters.Add(VisitorTeamIdParam);

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
        public SEvent SelectById(int keyId)
        {
            try
            {
                this.Id = keyId;
                string connectionString = ConfigurationManager.AppSettings["DBConStr"];
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("dbo.GetEvent", conn);
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
                        this.Name = Convert.ToString(reader["Name"] == DBNull.Value ? string.Empty : reader["Name"]);
                        this.Description = Convert.ToString(reader["Description"] == DBNull.Value ? string.Empty : reader["Description"]);
                        this.HostId = Convert.ToInt32(reader["HostId"] == DBNull.Value ? "0" : reader["HostId"]);
                        this.TypeId = Convert.ToInt32(reader["TypeId"] == DBNull.Value ? "0" : reader["TypeId"]);
                        this.StartTime = Convert.ToDateTime(reader["StartTime"] == DBNull.Value ? new DateTime() : reader["StartTime"]);
                        this.EndTime = Convert.ToDateTime(reader["EndTime"] == DBNull.Value ? new DateTime() : reader["EndTime"]);
                        this.HomeTeamId = Convert.ToInt32(reader["HomeTeamId"] == DBNull.Value ? "0" : reader["HomeTeamId"]);
                        this.VisitorTeamId = Convert.ToInt32(reader["VisitorTeamId"] == DBNull.Value ? "0" : reader["VisitorTeamId"]);
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

    }
}