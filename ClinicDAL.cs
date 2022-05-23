using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using CMS.Models;

namespace CMS.CDAL
{
    public class ClinicDAL
    {
        public string cnn = "";


        public ClinicDAL()
        {
            var builder = new ConfigurationBuilder().SetBasePath
                (Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            cnn = builder.GetSection("ConnectionStrings:Conn").Value;
        }
        public int Loginuser(Login lo)
        {
            SqlConnection con = new SqlConnection(cnn);

            SqlCommand cmd = new SqlCommand("UserLogin", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Username", lo.UserName);
            cmd.Parameters.AddWithValue("@Password", lo.Password);
            
            con.Open();
            IDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
                return (1);

            con.Close();
            return (0);
        }

    
        public int doctor1(Doctor d)
        {
            SqlConnection con = new SqlConnection(cnn);

            SqlCommand cmd = new SqlCommand("AddDoc", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("fname", d.FirstName);
            cmd.Parameters.AddWithValue("@lname", d.LastName);
            cmd.Parameters.AddWithValue("@sex", d.Sex);
            cmd.Parameters.AddWithValue("@special", d.Specialization);
            cmd.Parameters.AddWithValue("@visithrs", d.VisitingHours);


            con.Open();
            int result = cmd.ExecuteNonQuery();

            con.Close();
            return result;
        }
        public int patient1(Patient p)
        {
            SqlConnection con = new SqlConnection(cnn);

            SqlCommand cmd = new SqlCommand("AddPat", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@fname", p.FirstName);
            cmd.Parameters.AddWithValue("@lname", p.LastName);
            cmd.Parameters.AddWithValue("@sex", p.Sex);
            cmd.Parameters.AddWithValue("@age", p.Age);
            cmd.Parameters.AddWithValue("@dob", p.DateofBirth);
            

            con.Open();
            int result = cmd.ExecuteNonQuery();

            con.Close();
            return result;
        }
        public int AppointSch(Schedule s)
        {
            SqlConnection con = new SqlConnection(cnn);

            SqlCommand cmd = new SqlCommand("ProSchedule", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("id", s.Patientid);
            cmd.Parameters.AddWithValue("@spec", s.Specialization);
            cmd.Parameters.AddWithValue("@doc", s.Doctor);
            cmd.Parameters.AddWithValue("@vis", s.VisitDate);
            cmd.Parameters.AddWithValue("@apnt", s.AppointmentTime); 


            con.Open();
            int result = cmd.ExecuteNonQuery();

            con.Close();
            return result;
        }

        public List<Schedule> Scheduledelete()
        {
            List<Schedule> listSchedule = new List<Schedule>();
            using (SqlConnection con = new SqlConnection(cnn))
            {
                using (SqlCommand cmd = new SqlCommand("AppointmentDelete", con))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    IDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        listSchedule.Add(new Schedule()
                        {
                            Patientid = int.Parse(reader["PatientId"].ToString()),
                            Specialization = reader["Specialization"].ToString(),
                            Doctor = reader["Doctor"].ToString(),
                            VisitDate = reader["VisitDate"].ToString()
                            
                        }); 
                    }

                }
            }
            return listSchedule;
        }

        public int CancelAppointSch(int id)
        {
            SqlConnection con = new SqlConnection(cnn);

            SqlCommand cmd = new SqlCommand("Deleschd", con);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id",id);
            con.Open();
            int result = cmd.ExecuteNonQuery();

            con.Close();
            return result;
        }

    }
}
