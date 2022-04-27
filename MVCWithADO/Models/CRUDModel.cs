using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MVCWithADO.Models
{
    public class CRUDModel
    {
        string con = System.Configuration.ConfigurationManager.AppSettings["connectionstring"];

        public DataTable GetAllStudents()
        {
            DataTable dt = new DataTable();
            using (SqlConnection sqlcon = new SqlConnection(con))
            {
                sqlcon.Open();
                SqlCommand cmd = new SqlCommand("Select * from Student", sqlcon);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

            }
            return dt;
        }

        public DataTable GetStudentById(int studId)
        {
            DataTable dt = new DataTable();
            //string con = System.Configuration.ConfigurationManager.AppSettings["connectionstring"];
            using(SqlConnection sqlcon=new SqlConnection(con))
            {
                sqlcon.Open();
                SqlCommand cmd = new SqlCommand("Select * from student where student_Id=" + studId,sqlcon);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                sqlcon.Close();
            }
            return dt;
        }

        public int InsertStudent(string StudName,int StudAge,string StudGender)
        {
            using (SqlConnection sqlcon = new SqlConnection(con))
            {
                sqlcon.Open();
                string query = "Insert into Student Values(@StudName,@StudAge,@StudGender)";
                SqlCommand cmd = new SqlCommand(query,sqlcon);
                cmd.Parameters.AddWithValue("@StudName", StudName);
                cmd.Parameters.AddWithValue("@StudAge", StudAge);
                cmd.Parameters.AddWithValue("@StudGender", StudGender);
                return cmd.ExecuteNonQuery();

            }

        }

        public int UpdateStudent(int StudId, string StudName, int StudAge, string StudGender)
        {
            using (SqlConnection sqlcon = new SqlConnection(con))
            {
                sqlcon.Open();
                string query = "Update Student set Student_Name=@StudName,Student_Age=@StudAge, Student_Gender=@StudGender where Student_Id=@StudId";
                SqlCommand cmd = new SqlCommand(query,sqlcon);
                cmd.Parameters.AddWithValue("@StudName", StudName);
                cmd.Parameters.AddWithValue("@StudAge", StudAge);
                cmd.Parameters.AddWithValue("@StudGender", StudGender);
                cmd.Parameters.AddWithValue("@StudId", StudId);
                return cmd.ExecuteNonQuery();

            }


        }

        public int DeleteStudent(int StudId)
        {
            using (SqlConnection sqlcon = new SqlConnection(con))
            {
                sqlcon.Open();
                string query = "Delete from Student where Student_Id=@StudId";
                SqlCommand cmd = new SqlCommand(query, sqlcon);
                cmd.Parameters.AddWithValue("@StudId", StudId);
                return cmd.ExecuteNonQuery();

            }
        }
    }
}