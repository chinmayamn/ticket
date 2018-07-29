using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace MyTicket.Models
{
    public class Users
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Username required")]
        public string Username { get; set; }

        [Required(ErrorMessage ="Password required")]
        public string Password { get; set; }

        public string Name { get; set; }
        public string Mobile { get; set; }
        public string AlternativeMobile { get; set; }
        public string Email { get; set; }
        public string ProfilePicture { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string EmployeeId { get; set; }
        public int DepartmentId { get; set; }
        public string Roles { get; set; }
        public int Active { get; set; }
        public string Designation { get; set; }
        public string Level { get; set; }

        string str = ConfigurationManager.ConnectionStrings["cons"].ToString();
        public void AddEmployee(string username, string password, string name, string mobile, string alternativeMobile, string email, string profilePicture, string address, string city, string state, string employeeId, int departmentId, string role, int active, string designation, string level)
        {
            /*
            this.username = username;
            this.password = password;
            this.name = name;
            this.mobile = mobile;
            this.alternativeMobile = alternativeMobile;
            this.email = email;
            this.profilePicture = profilePicture;
            this.address = address;
            this.city = city;
            this.state = state;
            this.employeeId = employeeId;
            this.departmentId = departmentId;
            this.active = active;
            this.role = role;
            this.designation = designation;
            this.level = level;

            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("n_AddEmployee", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@mobile", mobile);
            cmd.Parameters.AddWithValue("@alternativemobile", alternativeMobile);
            cmd.Parameters.AddWithValue("@address", address);
            cmd.Parameters.AddWithValue("@profilepicture", profilePicture);
            cmd.Parameters.AddWithValue("@city", city);
            cmd.Parameters.AddWithValue("@state", state);
            cmd.Parameters.AddWithValue("@designation", designation);
            cmd.Parameters.AddWithValue("@role", role);
            cmd.Parameters.AddWithValue("@active", active);
            cmd.Parameters.AddWithValue("@departmentid", departmentId);
            cmd.Parameters.AddWithValue("@level", level);
            cmd.Parameters.AddWithValue("@employeeid", employeeId);
            cmd.ExecuteNonQuery();
            con.Close();

    */
        }
        public void UpdateEmployee(int id, string username, string password, string name, string mobile, string alternativeMobile, string email, string profilePicture, string address, string city, string state, string employeeId, int departmentId, string role, int active, string designation, string level)
        {
            /*
            this.id = id;
            this.username = username;
            this.password = password;
            this.name = name;
            this.mobile = mobile;
            this.alternativeMobile = alternativeMobile;
            this.email = email;
            this.profilePicture = profilePicture;
            this.address = address;
            this.city = city;
            this.state = state;
            this.employeeId = employeeId;
            this.departmentId = departmentId;
            this.active = active;
            this.role = role;
            this.designation = designation;
            this.level = level;

            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("n_UpdateEmployee", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@mobile", mobile);
            cmd.Parameters.AddWithValue("@alternativemobile", alternativeMobile);
            cmd.Parameters.AddWithValue("@address", address);
            cmd.Parameters.AddWithValue("@profilepicture", profilePicture);
            cmd.Parameters.AddWithValue("@city", city);
            cmd.Parameters.AddWithValue("@state", state);
            cmd.Parameters.AddWithValue("@designation", designation);
            cmd.Parameters.AddWithValue("@role", role);
            cmd.Parameters.AddWithValue("@active", active);
            cmd.Parameters.AddWithValue("@departmentid", departmentId);
            cmd.Parameters.AddWithValue("@level", level);
            cmd.Parameters.AddWithValue("@employeeid", employeeId);
            cmd.ExecuteNonQuery();
            con.Close();
            */
        }

        public string ReturnUser(Users user,ref string userloginid)
        {
            string url = "";
            DataTable dt =  GetUser(user.Username, user.Password);
            if(dt.Rows.Count>0)
            {
                string role = dt.Rows[0]["role"].ToString();
                userloginid = dt.Rows[0]["id"].ToString();
                if (role == "Admin")
                {
                    url = "/admin/admin/index";
                }
                else if (role == "Director")
                {
                    url = "/director/director/index";

                }
                else if (role == "H.R")
                {
                    url = "/hr/hr/index";
                }
                else if (role == "Employee")
                {
                    url = "/employee/employee/index";
                }
                else
                {
                    url = "/login/index";
                }
            }
            else
            {
                url = "/login/index";
            }
            return url;
        }
        public DataTable GetEmployee()
        {
            SqlConnection cnn = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("n_GetEmployee", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }


        public DataTable CheckAvailability(string username)
        {
            SqlConnection cnn = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("n_EmployeeByUsername", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@username", username);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable GetUser(string username, string password)
        {
            SqlConnection cnn = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("n_EmployeeLogin", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable GetUser(int id)
        {
            SqlConnection cnn = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("n_GetUserById", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable GetUserDetailsById(int id)
        {
            SqlConnection cnn = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("n_GetUserDetailsById", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable GetUser(string username)
        {
            SqlConnection cnn = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("n_GetUserByUsername", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@username", username);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable GetNonEmployeeById(int id)
        {
            SqlConnection cnn = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("n_GetNonEmployeeById", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public void UpdateEmployeeUser(int id, string image, string name, string mobile, string alternativemobile, string email, string address, string city, string state)
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("n_UpdateEmployeeUser", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddWithValue("@id", id);

            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@mobile", mobile);
            cmd.Parameters.AddWithValue("@alternativemobile", alternativemobile);
            cmd.Parameters.AddWithValue("@address", address);
            cmd.Parameters.AddWithValue("@profilepicture", image);
            cmd.Parameters.AddWithValue("@city", city);
            cmd.Parameters.AddWithValue("@state", state);

            cmd.ExecuteNonQuery();
            con.Close();
        }
        public void ChangePassword(string password, int id)
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("n_ChangePassword", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@password", password);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public void DeleteEmployee(int id)
        {
            SqlConnection con = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("n_DeleteEmployee", con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            con.Close();
        }


        public DataTable GetUserByDepartmentLevel(int did, string level)
        {
            SqlConnection cnn = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("n_GetUserByDepartmentLevel", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@did", did);
            cmd.Parameters.AddWithValue("@level", level);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public DataTable GetDirector()
        {
            SqlConnection cnn = new SqlConnection(str);
            SqlCommand cmd = new SqlCommand("n_GetDirector", cnn);
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }

}