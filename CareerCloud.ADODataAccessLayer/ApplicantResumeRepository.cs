using System;
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
    public class ApplicantResumeRepository : BaseADO, IDataRepository<ApplicantResumePoco>
    {
        public IList<ApplicantResumePoco> GetAll(params Expression<Func<ApplicantResumePoco, object>>[] navigationProperties)
        {
            ApplicantResumePoco[] pocos = new ApplicantResumePoco[1000];
            SqlConnection conn = new SqlConnection(_connstring);
            ;
            using (conn)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT * FROM Applicant_Resumes";

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                int position = 0;
                while (reader.Read())
                {
                    ApplicantResumePoco poco = new ApplicantResumePoco();
                    poco.Id = reader.GetGuid(0);
                    poco.Applicant = reader.GetGuid(1);
                    poco.Resume = reader.GetString(2);
                    poco.LastUpdated = reader.IsDBNull(3) ? (DateTime?)null : (DateTime)reader[3];
                    pocos[position++] = poco;
                }

                conn.Close();
            }

            return pocos.Where(p => p != null).ToList();
        }

        public IList<ApplicantResumePoco> GetList(Expression<Func<ApplicantResumePoco, bool>> @where, params Expression<Func<ApplicantResumePoco, object>>[] navigationProperties)
        {
            throw new NotImplementedException();
        }

        public ApplicantResumePoco GetSingle(Expression<Func<ApplicantResumePoco, bool>> @where, params Expression<Func<ApplicantResumePoco, object>>[] navigationProperties)
        {
            IQueryable<ApplicantResumePoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Add(params ApplicantResumePoco[] items)
        {
            SqlConnection conn = new SqlConnection(_connstring);

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            foreach (ApplicantResumePoco poco in items)
            {
                cmd.CommandText = @"INSERT INTO Applicant_Resumes 
                    (Id,Applicant,Resume,Last_Updated)
                    VALUES
                    (@Id,@Applicant,@Resume,@Last_Updated)";

                cmd.Parameters.AddWithValue("@Id", poco.Id);
                cmd.Parameters.AddWithValue("@Applicant", poco.Applicant);
                cmd.Parameters.AddWithValue("@Resume", poco.Resume);
                cmd.Parameters.AddWithValue("@Last_Updated", poco.LastUpdated);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void Update(params ApplicantResumePoco[] items)
        {
            SqlConnection conn = new SqlConnection(_connstring);

            using (conn)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (ApplicantResumePoco poco in items)
                {
                    cmd.CommandText = @"UPDATE Applicant_Resumes
                        SET Applicant = @Applicant,
                        Resume = @Resume,
                        Last_Updated=@Last_Updated
                        WHERE ID = @Id";
                    cmd.Parameters.AddWithValue("@Applicant", poco.Applicant);
                    cmd.Parameters.AddWithValue("@Resume", poco.Resume);
                    cmd.Parameters.AddWithValue("@Last_Updated", poco.LastUpdated);
                    cmd.Parameters.AddWithValue("@Id", poco.Id);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void Remove(params ApplicantResumePoco[] items)
        {
            SqlConnection conn = new SqlConnection(_connstring);

            using (conn)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (ApplicantResumePoco poco in items)
                {
                    cmd.CommandText = @"DELETE FROM Applicant_Resumes
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
