using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace Registration.Models
{
    public class registration
    {
        public string FName { get; set; }
        public string LName { get; set; }
        public string Gender { get; set; }
        public string city { get; set; }
        public string State { get; set; }
        public string mail { get; set; }
        public string DOB { get; set; }
        public string Address { get; set; }

        SqlConnection sqlconnect = new SqlConnection("Data Source =.\\SQLEXPRESS;Database=registration;User Id=sa;pwd=123;Encrypt=False;TrustServerCertificate=False;");
        
        public int Insert(string Fname,string LName,string Gender,string city,string State,string mail, string DOB,string Address)
        {
            SqlCommand command = new SqlCommand("insert into [dbo].[Users](Fname,LName,Gender,city,State,mail,DOB,Address)values('" + Fname + "','" + LName + "','" + Gender + "','" + city + "','" + State + "','" + mail + "','" + DOB + "','" + Address + "')", sqlconnect);
            sqlconnect.Open();
            return command.ExecuteNonQuery();
        }

        public DataSet Select()
        {
            SqlCommand command = new SqlCommand("select * from [dbo].[Users]", sqlconnect);
            SqlDataAdapter dataAdap = new SqlDataAdapter(command);
            DataSet dataset = new DataSet();
            dataAdap.Fill(dataset);
            return dataset;
        }
        public int Delete(int id)
        {
            SqlCommand command = new SqlCommand("delete from [dbo].[Users] where id=" + id, sqlconnect);
            sqlconnect.Open();
            return command.ExecuteNonQuery();
        }
        public DataSet update(int id)
        {
            SqlCommand command = new SqlCommand("select * from [dbo].[Users] where id=" + id, sqlconnect);
            SqlDataAdapter dataAdap = new SqlDataAdapter(command);
            DataSet dataset = new DataSet();
            dataAdap.Fill(dataset);
            return dataset;
        }

    }
}
