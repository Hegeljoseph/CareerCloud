﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CareerCloud.DataAccessLayer;
using CareerCloud.Pocos;

namespace CareerCloud.ADODataAccessLayer
{
    public class ApplicantWorkHistoryRepository : BaseADO, IDataRepository<ApplicantWorkHistoryPoco>
    {
        public IList<ApplicantWorkHistoryPoco> GetAll(params Expression<Func<ApplicantWorkHistoryPoco, object>>[] navigationProperties)
        {
            ApplicantWorkHistoryPoco[] pocos = new ApplicantWorkHistoryPoco[1000];
            SqlConnection conn = new SqlConnection(_connstring);
            ;
            using (conn)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT * FROM Applicant_Work_History";

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                int position = 0;
                while (reader.Read())
                {
                    ApplicantWorkHistoryPoco poco = new ApplicantWorkHistoryPoco();
                    poco.Id = reader.GetGuid(0);
                    poco.Applicant = reader.GetGuid(1);
                    poco.CompanyName = reader.GetString(2);
                    poco.CountryCode = reader.GetString(3);
                    poco.Location = reader.GetString(4);
                    poco.JobTitle = reader.GetString(5);
                    poco.JobDescription = reader.GetString(6);
                    poco.StartMonth = reader.GetInt16(7);
                    poco.StartYear = reader.GetInt32(8);
                    poco.EndMonth = reader.GetInt16(9);
                    poco.EndYear = reader.GetInt32(10);
                    pocos[position++] = poco;
                }

                conn.Close();
            }

            return pocos.Where(p => p != null).ToList();
        }

        public IList<ApplicantWorkHistoryPoco> GetList(Expression<Func<ApplicantWorkHistoryPoco, bool>> @where, params Expression<Func<ApplicantWorkHistoryPoco, object>>[] navigationProperties)
        {
            IQueryable<ApplicantWorkHistoryPoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).ToList();
        }

        public ApplicantWorkHistoryPoco GetSingle(Expression<Func<ApplicantWorkHistoryPoco, bool>> @where, params Expression<Func<ApplicantWorkHistoryPoco, object>>[] navigationProperties)
        {
            IQueryable<ApplicantWorkHistoryPoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Add(params ApplicantWorkHistoryPoco[] items)
        {
            SqlConnection conn = new SqlConnection(_connstring);

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            foreach (ApplicantWorkHistoryPoco poco in items)
            {
                cmd.CommandText = @"INSERT INTO Applicant_Work_History 
                    (Id,Applicant,Company_Name,Country_Code,Location,Job_Title,
                    Job_Description, Start_Month, Start_Year, End_Month, End_Year)
                    VALUES
                    (@Id,@Applicant,@Company_Name,@Country_Code
                    ,@Location, @Job_Title, @Job_Description, 
                    @Start_Month, @Start_Year, @End_Month, @End_Year)";

                cmd.Parameters.AddWithValue("@Id", poco.Id);
                cmd.Parameters.AddWithValue("@Applicant", poco.Applicant);
                cmd.Parameters.AddWithValue("@Company_Name", poco.CompanyName);
                cmd.Parameters.AddWithValue("@Country_Code", poco.CountryCode);
                cmd.Parameters.AddWithValue("@Location", poco.Location);
                cmd.Parameters.AddWithValue("@Job_Title", poco.JobTitle);
                cmd.Parameters.AddWithValue("@Job_Description", poco.JobDescription);
                cmd.Parameters.AddWithValue("@Start_Month", poco.StartMonth);
                cmd.Parameters.AddWithValue("@Start_Year", poco.StartYear);
                cmd.Parameters.AddWithValue("@End_Month", poco.EndMonth);
                cmd.Parameters.AddWithValue("@End_Year", poco.EndYear);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void Update(params ApplicantWorkHistoryPoco[] items)
        {
            SqlConnection conn = new SqlConnection(_connstring);

            using (conn)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (ApplicantWorkHistoryPoco poco in items)
                {
                    cmd.CommandText = @"UPDATE Applicant_Work_History
                        SET Applicant = @Applicant,
                        Company_Name = @Company_Name,
                        Country_Code = @Country_Code,
                        Location = @Location,
                        Job_Title = @Job_Title,
                        Job_Description = @Job_Description,
                        Start_Month = @Start_Month,
                        Start_Year = @Start_Year,
                        End_Month = @End_Month,
                        End_Year = @End_Year
                        WHERE ID = @Id";
                    cmd.Parameters.AddWithValue("@Id", poco.Id);
                    cmd.Parameters.AddWithValue("@Applicant", poco.Applicant);
                    cmd.Parameters.AddWithValue("@Company_Name", poco.CompanyName);
                    cmd.Parameters.AddWithValue("@Country_Code", poco.CountryCode);
                    cmd.Parameters.AddWithValue("@Location", poco.Location);
                    cmd.Parameters.AddWithValue("@Job_Title", poco.JobTitle);
                    cmd.Parameters.AddWithValue("@Job_Description", poco.JobDescription);
                    cmd.Parameters.AddWithValue("@Start_Month", poco.StartMonth);
                    cmd.Parameters.AddWithValue("@Start_Year", poco.StartYear);
                    cmd.Parameters.AddWithValue("@End_Month", poco.EndMonth);
                    cmd.Parameters.AddWithValue("@End_Year", poco.EndYear);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void Remove(params ApplicantWorkHistoryPoco[] items)
        {
            SqlConnection conn = new SqlConnection(_connstring);

            using (conn)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (ApplicantWorkHistoryPoco poco in items)
                {
                    cmd.CommandText = @"DELETE FROM Applicant_Work_History
                        WHERE ID = @Id";
                    cmd.Parameters.AddWithValue("@Id", poco.Id);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void CallStoredProc(string name, params Tuple<string, string>[] parameters)
        {
            throw new NotImplementedException();
        }
    }
}
