using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using ticket_booking_system.Models;
using System.Net;
using System.Web.Helpers;


namespace ticket_booking_system.database
{
    public class database
    {
       SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);

        public void Add_record(customer customers)
        {
            SqlCommand command = new SqlCommand("customerregistration_Add", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@firstname",customers.firstname);
            command.Parameters.AddWithValue("@lastname",customers.lastname);
            command.Parameters.AddWithValue("@dateofbirth",customers.dateofbirth);
            command.Parameters.AddWithValue("@gender",customers.gender);
            command.Parameters.AddWithValue("@phonenumber",customers.phonenumber);
            command.Parameters.AddWithValue("@email",customers.email);
            command.Parameters.AddWithValue("@address",customers.address);
            command.Parameters.AddWithValue("@state",customers.state);
            command.Parameters.AddWithValue("@city", customers.city);

            command.Parameters.AddWithValue("@username",customers.username);
            command.Parameters.AddWithValue("@password", customers.password);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
        public void update_record(customer customers)
        {
            SqlCommand command = new SqlCommand("customerregistration_update", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id",customers.Id);
            command.Parameters.AddWithValue("@firstname", customers.firstname);
            command.Parameters.AddWithValue("@lastname", customers.lastname);
            command.Parameters.AddWithValue("@dateofbirth", customers.dateofbirth);
            command.Parameters.AddWithValue("@gender", customers.gender);
            command.Parameters.AddWithValue("@phonenumber", customers.phonenumber);
            command.Parameters.AddWithValue("@email", customers.email);
            command.Parameters.AddWithValue("@address", customers.address);
            command.Parameters.AddWithValue("@city", customers.city);
            command.Parameters.AddWithValue("@username", customers.username);
            command.Parameters.AddWithValue("@password", customers.password);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public DataSet Show_record (int id)
        {
            SqlCommand command = new SqlCommand("customerregistration_id", connection);
            command.CommandType= CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id",id);
            SqlDataAdapter da= new SqlDataAdapter(command);
            DataSet ds=new DataSet();
            da.Fill(ds);
            return ds;
        }

        public DataSet Show_data()
        {
            SqlCommand command = new SqlCommand("customerregistration_All", connection);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }


        public void delete_record(int id)
        {
            SqlCommand command = new SqlCommand("customerregistration_delete", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id", id);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            
        }


        public void addmovies(movies movies)
        {
            SqlCommand command = new SqlCommand("sp_movies", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@movie_name", movies.movie_name);
            command.Parameters.AddWithValue("@movie_description", movies.description);
            command.Parameters.AddWithValue("@movie_image", movies.movie_image);
            command.Parameters.AddWithValue("@streaming_date", movies.streaming_date);
            command.Parameters.AddWithValue("@movie_genre", movies.genre);
            command.Parameters.AddWithValue("@movie_duration", movies.duration);
            command.Parameters.AddWithValue("@movie_language", movies.language);
            command.Parameters.AddWithValue("@choice", "insert");

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
        public DataSet viewmovie()
        {
            SqlCommand command = new SqlCommand("sp_movies", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@choice", "view");
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

        public void deletemovie(int id)
        {
            SqlCommand com = new SqlCommand("sp_movies", connection);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@choice", "delete");
            com.Parameters.AddWithValue("@id", id);
            connection.Open();
            com.ExecuteNonQuery();
            connection.Close();
        }

        public void updatemovie(movies movie)
        {
            SqlCommand command = new SqlCommand("sp_movies", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@id", movie.Id);
            command.Parameters.AddWithValue("@movie_name", movie.movie_name);
            command.Parameters.AddWithValue("@movie_description", movie.description);
            command.Parameters.AddWithValue("@streaming_date", movie.streaming_date);
            command.Parameters.AddWithValue("@movie_genre", movie.genre);
            command.Parameters.AddWithValue("@movie_duration", movie.duration);
            command.Parameters.AddWithValue("@movie_language", movie.language);
            command.Parameters.AddWithValue("@choice", "update");

            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public DataSet Showmoviebyid(int id)
        {
            SqlCommand com = new SqlCommand("sp_movies", connection);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@id", id);
            com.Parameters.AddWithValue("@choice", "viewbyid");
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet dataset = new DataSet();
            da.Fill(dataset);
            return dataset;

        }

        public DataSet Login(customer customers)
        {
            SqlCommand com = new SqlCommand("sp_movies", connection);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@username", customers.username);
            com.Parameters.AddWithValue("@password", customers.password);
            com.Parameters.AddWithValue("@choice", "login");
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;


        }
        public DataSet bookmovie()
        {
            SqlCommand command = new SqlCommand("sp_movies", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@choice", "view");
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }

    }
}
