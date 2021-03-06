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
    public class SystemLanguageCodeRepository : BaseADO, IDataRepository<SystemLanguageCodePoco>
    {
        public IList<SystemLanguageCodePoco> GetAll(params Expression<Func<SystemLanguageCodePoco, object>>[] navigationProperties)
        {
            SystemLanguageCodePoco[] pocos = new SystemLanguageCodePoco[1000];
            SqlConnection conn = new SqlConnection(_connstring);

            using (conn)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "SELECT * FROM System_Language_Codes";

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                int position = 0;
                while (reader.Read())
                {
                    SystemLanguageCodePoco poco = new SystemLanguageCodePoco();
                    poco.LanguageID = reader.GetString(0);
                    poco.Name = reader.GetString(1);
                    poco.NativeName = reader.GetString(2);
                    pocos[position++] = poco;
                }

                conn.Close();
            }

            return pocos.Where(p => p != null).ToList();
        }

        public IList<SystemLanguageCodePoco> GetList(Expression<Func<SystemLanguageCodePoco, bool>> @where, params Expression<Func<SystemLanguageCodePoco, object>>[] navigationProperties)
        {
            IQueryable<SystemLanguageCodePoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).ToList();
        }

        public SystemLanguageCodePoco GetSingle(Expression<Func<SystemLanguageCodePoco, bool>> @where, params Expression<Func<SystemLanguageCodePoco, object>>[] navigationProperties)
        {
            IQueryable<SystemLanguageCodePoco> pocos = GetAll().AsQueryable();
            return pocos.Where(where).FirstOrDefault();
        }

        public void Add(params SystemLanguageCodePoco[] items)
        {
            SqlConnection conn = new SqlConnection(_connstring);

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            foreach (SystemLanguageCodePoco poco in items)
            {
                cmd.CommandText = @"INSERT INTO System_Language_Codes
                    (LanguageId,Name,Native_Name)
                    VALUES
                    (@LanguageId,@Name,@Native_Name)";

                cmd.Parameters.AddWithValue("@LanguageId", poco.LanguageID);
                cmd.Parameters.AddWithValue("@Name", poco.Name);
                cmd.Parameters.AddWithValue("@Native_Name", poco.NativeName);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }

        public void Update(params SystemLanguageCodePoco[] items)
        {
            SqlConnection conn = new SqlConnection(_connstring);

            using (conn)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (SystemLanguageCodePoco poco in items)
                {
                    cmd.CommandText = @"UPDATE System_Language_Codes
                        SET Name = @Name,
                        Native_Name = @Native_Name
                        WHERE LanguageId = @LanguageId";

                    cmd.Parameters.AddWithValue("@LanguageId", poco.LanguageID);
                    cmd.Parameters.AddWithValue("@Name", poco.Name);
                    cmd.Parameters.AddWithValue("@Native_Name", poco.NativeName);


                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }
        }

        public void Remove(params SystemLanguageCodePoco[] items)
        {
            SqlConnection conn = new SqlConnection(_connstring);

            using (conn)
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                foreach (SystemLanguageCodePoco poco in items)
                {
                    cmd.CommandText = @"DELETE FROM System_Language_Codes
                        WHERE LanguageId = @LanguageId";
                    cmd.Parameters.AddWithValue("@LanguageId", poco.LanguageID);

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
