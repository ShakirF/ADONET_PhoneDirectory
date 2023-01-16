using ADONET_PhoneDirectory.Interfaces;
using ADONET_PhoneDirectory.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADONET_PhoneDirectory
{
    public class PersonRepository : IPerson
    {
        public bool Insert(Person person)
        {
            SqlConnection sqlConnection = new SqlConnection("Server=DESKTOP-DUE6JJJ;Database=PhonBook;Trusted_Connection=true;TrustServerCertificate=True");
            SqlCommand command = new SqlCommand();
            command.Connection = sqlConnection;
            command.CommandText = "INSERT INTO People VALUES ( @FirstName, @LastName, @Phone, @Email)";
            command.Parameters.Add("@FirstName", SqlDbType.NVarChar).Value = person.FirstName;
            command.Parameters.Add("@LastName", SqlDbType.NVarChar).Value = person.LastName;
            command.Parameters.Add("@Phone", SqlDbType.NVarChar).Value = person.Phone;
            command.Parameters.Add("@Email", SqlDbType.NVarChar).Value = person.Email;

            if (sqlConnection.State == ConnectionState.Closed) sqlConnection.Open();

            bool result = command.ExecuteNonQuery() > 0;

            sqlConnection.Close();
            return result;
        }

        public void Listed()
        {
            SqlConnection connection = new SqlConnection("Server=DESKTOP-DUE6JJJ;Database=PhonBook;Trusted_Connection=true;TrustServerCertificate=True");
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "SELECT * FROM People";
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(table);
            for (int i = 0; i < table.Columns.Count; i++)
            {
                Console.Write(table.Columns[i]);
                Console.Write($"{new String(' ', 30 - table.Columns[i].ToString().Length)}");
            }
            Console.WriteLine();
            foreach (DataRow row in table.Rows)
            {
                foreach (var item in row.ItemArray)
                {
                    Console.Write(item);
                    Console.Write($"{new String(' ', 30 - item.ToString().Length)}");
                }
                Console.WriteLine();
            }
            if (connection.State == ConnectionState.Closed) connection.Open();
        }

        public void Searcing(string search)
        {
            SqlConnection connection = new SqlConnection("Server=DESKTOP-DUE6JJJ;Database=PhonBook;Trusted_Connection=true;TrustServerCertificate=True");
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "Select * from People where  Firstname =@search or LastName = @search or Phone = @search or Email = @search";
            command.Parameters.Add("@search", SqlDbType.NVarChar).Value = search;
            DataTable table = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            adapter.Fill(table);
            for (int i = 0; i < table.Columns.Count; i++)
            {

                Console.Write(table.Columns[i]);
                Console.Write($"{new String(' ', 30 - table.Columns[i].ToString().Length)}");
            }
            Console.WriteLine();
            foreach (DataRow row in table.Rows)
            {
                foreach (var item in row.ItemArray)
                {
                    Console.Write(item);
                    Console.Write($"{new String(' ', 30 - item.ToString().Length)}");
                }
                Console.WriteLine();
            }
            if (connection.State == ConnectionState.Closed) connection.Open();
        }

        public void Deleted(string inputId)
        {
            SqlConnection connection = new SqlConnection("Server=DESKTOP-DUE6JJJ;Database=PhonBook;Trusted_Connection=true;TrustServerCertificate=True");
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = $"Delete FROM People where Id = @inputId";
            command.Parameters.Add("@inputId", SqlDbType.NVarChar).Value = inputId;
            if (connection.State == ConnectionState.Closed) connection.Open();
            command.ExecuteReader();
            Console.WriteLine($"Id-isi {inputId} olan melumat silinmisdir");
        }
    }
}
