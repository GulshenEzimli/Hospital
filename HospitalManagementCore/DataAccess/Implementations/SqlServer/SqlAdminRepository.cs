using HospitalManagementCore.DataAccess.Interfaces;
using HospitalManagementCore.Domain.Entities;
using HospitalManagementCore.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net.Http.Headers;
using System.Text;

namespace HospitalManagementCore.DataAccess.Implementations.SqlServer
{
    public class SqlAdminRepository : IAdminRepository
    {
        private string _connectionString;
        public SqlAdminRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public bool Delete(int id)
        {
            using (SqlConnection connection= new SqlConnection(_connectionString))
            {
                connection.Open();
                string cmdText = @"delete * from Admins where Id=@id";

                using (SqlCommand command = new SqlCommand(cmdText,connection))
                {
                    command.Parameters.AddWithValue("id", id);
                    return command.ExecuteNonQuery() == 1;
                }
            }
        }

        public List<Admin> Get()
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.Open();
                string cmdText = @"";

                using (SqlCommand command= new SqlCommand(cmdText, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    List<Admin> admins = new List<Admin>();

                    while (reader.Read())
                    {
                        Admin admin = new Admin();
                        admins.Add(admin);
                    }
                    return admins;
                }
            }
        }

        public Admin GetById(int id)
        {
            using (SqlConnection  connection = new SqlConnection())
            {
                connection.Open();

                string cmdText = @"";

                using (SqlCommand command= new SqlCommand(cmdText, connection))
                {
                    command.Parameters
                        .AddWithValue("id", id);
                    SqlDataReader reader = command.ExecuteReader();
                    Admin admin = GetAdmin(reader);
                    return admin;
                }
            }
        }

        public int Insert(Admin admin)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                connection.Open();
                string cmdText = @"";
                using (SqlCommand command= new SqlCommand(cmdText,connection))
                {
                    AddParameters(command, admin);
                    return (int)command.ExecuteScalar();
                }
            }
        }

        public bool Update(Admin admin)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                string cmdText = @"";

                using (SqlCommand command = new SqlCommand(cmdText, connection))
                {
                    command.Parameters .AddWithValue("id", admin.Id);
                    AddParameters(command, admin);
                    return command.ExecuteNonQuery() == 1;

                }
            }
        }

        private Admin GetAdmin(SqlDataReader reader)
        {
            Admin admin = new Admin();

            admin.Id = reader.GetInt32("AdminId");
            admin.UserName=reader.GetString("UserName");
            admin.Password=reader.GetString("Password");
           
            return admin;
        }

        private  void AddParameters(SqlCommand command, Admin admin)
        {
            command.Parameters.AddWithValue("id", admin.Id);
            command.Parameters.AddWithValue ("username", admin.UserName);
            command.Parameters.AddWithValue("password",admin.Password);
        }
    }
}
