﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dataPersistence;

namespace sqlAccess
{
    public class SqlAccess : ISqlAccess
    {
        private string connectionString = @"Data Source=(local)\\sqlexpress;Initial Catalog=client;Integrated Security=True;";

        public void sqlConnect ()
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source=(local)\sqlexpress;Initial Catalog=client;Integrated Security=True;");
        }

        public User[] getAllUser()
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source=(local)\sqlexpress;Initial Catalog=client;Integrated Security=True;");
            List<User> users = new List<User>();
            SqlDataAdapter sqlda = new SqlDataAdapter("Select * from [client]", sqlCon);
            DataTable dtbl = new DataTable();

            sqlda.Fill(dtbl);
            foreach (DataRow row in dtbl.Rows)
            {
                User tempUser = new User();
                tempUser.id = (int)row["Id_user"];
                tempUser.login = row["login"].ToString();
                tempUser.password = row["password"].ToString();
                users.Add(tempUser);
            }
            return users.ToArray();
        }

        public User[] getUserByParameterValue(string parameter, string value )
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source=(local)\sqlexpress;Initial Catalog=client;Integrated Security=True;");
            List<User> users = new List<User>();
            SqlDataAdapter sqlda = new SqlDataAdapter("Select * from [client] WHERE "+ parameter+ "= '"+ value+"'" , sqlCon);
            DataTable dtbl = new DataTable();

            sqlda.Fill(dtbl);
            foreach (DataRow row in dtbl.Rows)
            {
                User tempUser = new User();
                tempUser.id = (int)row["Id_user"];
                tempUser.login = row["login"].ToString();
                tempUser.password = row["password"].ToString() ;
                users.Add(tempUser);
            }
            return users.ToArray();
        }

        public User[] getUserBy2ParametersValue(string parameter, string value, string parameter2, string value2)
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source=(local)\sqlexpress;Initial Catalog=client;Integrated Security=True;");
            List<User> users = new List<User>();
            SqlDataAdapter sqlda = new SqlDataAdapter("Select * from [user] WHERE " + parameter + "= '" + value + "' AND " + parameter2 + "= '" + value2 + "'", sqlCon);
            DataTable dtbl = new DataTable();

            sqlda.Fill(dtbl);
            foreach (DataRow row in dtbl.Rows)
            {
                User tempUser = new User();
                tempUser.id = (int)row["Id_user"];
                tempUser.login = row["login"].ToString();
                tempUser.password = row["password"].ToString();
                users.Add(tempUser);
            }
            return users.ToArray();
        }

        public void createLog(dataPersistence.log log)
        {
            SqlConnection sqlCon = new SqlConnection(@"Data Source=(local)\sqlexpress;Initial Catalog=client;Integrated Security=True;");
            string sql = "INSERT INTO log (LogType,Data,LogDate) VALUES ('" + log.type + "','" + log.data + "','"+ log.date.ToString("yyyy-MM-dd HH:mm:ss") +"')";
            sqlCon.Open();
            SqlDataAdapter sqlda = new SqlDataAdapter();
            SqlCommand command = new SqlCommand(sql, sqlCon);
            sqlda.InsertCommand = new SqlCommand(sql, sqlCon);
            sqlda.InsertCommand.ExecuteNonQuery();
            command.Dispose();
            sqlCon.Close();
        }
    }
}
