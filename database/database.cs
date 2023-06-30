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

        /// <summary>
        /// customer registration 
        /// </summary>

        public void Add_record(customer customers)
        {
            try
            {
                SqlCommand command = new SqlCommand("customerregistration_Add", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@firstname", customers.firstname);
                command.Parameters.AddWithValue("@lastname", customers.lastname);
                command.Parameters.AddWithValue("@dateofbirth", customers.dateofbirth);
                command.Parameters.AddWithValue("@gender", customers.gender);
                command.Parameters.AddWithValue("@phonenumber", customers.phonenumber);
                command.Parameters.AddWithValue("@email", customers.email);
                command.Parameters.AddWithValue("@address", customers.address);
                command.Parameters.AddWithValue("@state", customers.state);
                command.Parameters.AddWithValue("@city", customers.city);
                command.Parameters.AddWithValue("@username", customers.username);
                command.Parameters.AddWithValue("@password", customers.password);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception exception)
            {
                // Handle the exception here
                Console.WriteLine("An error occurred: " + exception.Message);
            }
        }

        /// <summary>
        /// update customer registration 
        /// </summary>

        public void update_record(customer customers)
        {
            try
            {
                SqlCommand command = new SqlCommand("customerregistration_update", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id", customers.Id);
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
            catch (Exception exception)
            {
                // Handle the exception here
                Console.WriteLine("An error occurred: " + exception.Message);
            }
        }

        /// <summary>
        /// customer registration record view in admin panel
        /// </summary>
        
        public DataSet Show_record (int id)
        {
            try
            {
                SqlCommand command = new SqlCommand("customerregistration_id", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id", id);
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
            catch (Exception exception)
            {
                // Handle the exception here, for example:
                Console.WriteLine("An error occurred: " + exception.Message);
                return null; // or any other appropriate action
            }
        }

        public DataSet Show_data()
        {
            try
            {
                SqlCommand command = new SqlCommand("customerregistration_All", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
            catch (Exception exception)
            {
                // Handle the exception here, for example:
                Console.WriteLine("An error occurred: " + exception.Message);
                return null; // or any other appropriate action
            }
        }

        /// <summary>
        /// customer registration record delete in admin panel
        /// </summary>
        
        public void delete_record(int id)
        {
            try
            {
                SqlCommand command = new SqlCommand("customerregistration_delete", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@id", id);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception exception)
            {
                // Handle the exception here
                Console.WriteLine("An error occurred: " + exception.Message);
            }

        }

        /// <summary>
        /// admin can add movies in admin panel
        /// </summary>
        
        public void addmovies(movies movies)
        {
            try
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
            catch (Exception exception)
            {
                // Handle the exception here
                Console.WriteLine("An error occurred: " + exception.Message);
            }
        }

        /// <summary>
        /// admin can view added  movies in admin panel
        /// </summary>
        
        public DataSet viewmovie()
        {
            try
            {
                SqlCommand command = new SqlCommand("sp_movies", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@choice", "view");
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
            catch (Exception exception)
            {
                // Handle the exception here, for example:
                Console.WriteLine("An error occurred: " + exception.Message);
                return null; // or any other appropriate action
            }
        }

        /// <summary>
        /// admin can delete movie in admin panel
        /// </summary>
        
        public void deletemovie(int id)
        {
            try
            {
                SqlCommand com = new SqlCommand("sp_movies", connection);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@choice", "delete");
                com.Parameters.AddWithValue("@id", id);
                connection.Open();
                com.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception exception)
            {
                // Handle the exception here
                Console.WriteLine("An error occurred: " + exception.Message);
            }
        }
        /// <summary>
        /// admin can update movies in admin panel 
        /// </summary>
        
        public void updatemovie(movies movie)
        {
            try
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
            catch (Exception exception)
            {
                // Handle the exception here
                Console.WriteLine("An error occurred: " + exception.Message);
            }
        }

        /// <summary>
        /// show movies in webite
        /// </summary>
        
        public DataSet Showmoviebyid(int id)
        {
            try
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
            catch (Exception exception)
            {
                // Handle the exception here, for example:
                Console.WriteLine("An error occurred: " + exception.Message);
                return null; // or any other appropriate action
            }


        }

        /// <summary>
        /// customer login in the website
        /// </summary>
        
        public DataSet Login(customer customers)
        {
            try
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
            catch (Exception exception)
            {
                // Handle the exception here, for example:
                Console.WriteLine("An error occurred: " + exception.Message);
                return null; // or any other appropriate action
            }


        }
        /// <summary>
        /// customer can book movie 
        /// </summary>
        public DataSet bookmovie()
        {
            try
            {
                SqlCommand command = new SqlCommand("sp_movies", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@choice", "view");
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataSet ds = new DataSet();
                da.Fill(ds);
                return ds;
            }
            catch (Exception exception)
            {
                // Handle the exception here, for example:
                Console.WriteLine("An error occurred: " + exception.Message);
                return null; // or any other appropriate action
            }
        }


        /// <summary>
        /// customer can view profile
        /// </summary>
        public DataSet userprofile(string username)
        {
            try
            {
                SqlCommand com = new SqlCommand("sp_movies", connection);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@username", username);
                com.Parameters.AddWithValue("@choice", "userprofile");
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataSet dataset = new DataSet();
                da.Fill(dataset);
                return dataset;
            }
            catch (Exception ex)
            {
                // Handle the exception here, for example:
                Console.WriteLine("An error occurred: " + ex.Message);
                return null; // or any other appropriate action
            }
        }



        /// <summary>
        /// customer can book movie in the website
        /// </summary>

        public void book_movie(booking booking)
        {
            try
            {
                SqlCommand com = new SqlCommand("sp_booking", connection);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@userid", booking.userid);
                com.Parameters.AddWithValue("@movieid", booking.movieid);
                com.Parameters.AddWithValue("@choice", "insert");
                connection.Open();
                com.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception exception)
            {
                // Handle the exception here
                Console.WriteLine("An error occurred: " + exception.Message);
            }
        }
        /// <summary>
        /// customer can visible booking movies
        /// </summary>
        /// <param name="booking"></param>
        /// <returns></returns>
        public DataSet Show_Bokking_movie(booking booking)
        {
            try
            {
                SqlCommand com = new SqlCommand("sp_booking", connection);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@userid", booking.userid);
                com.Parameters.AddWithValue("@choice", "view");
                SqlDataAdapter sqldataadapter = new SqlDataAdapter(com);
                DataSet dataset = new DataSet();
                sqldataadapter.Fill(dataset);
                return dataset;
            }
            catch (Exception exception)
            {
                // Handle the exception here, for example:
                Console.WriteLine("An error occurred: " + exception.Message);
                return null; // or any other appropriate action
            }
        }
        /// <summary>
        /// customer can visible booked movie
        /// </summary>
        /// <returns></returns>
        public DataSet Show_booking()
        {
            try
            {
                SqlCommand com = new SqlCommand("sp_movies", connection);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@choice", "view");
                SqlDataAdapter sqldataadapter = new SqlDataAdapter(com);
                DataSet dataset = new DataSet();
                sqldataadapter.Fill(dataset);
                return dataset;
            }
            catch (Exception exception)
            {
                // Handle the exception here, for example:
                Console.WriteLine("An error occurred: " + exception.Message);
                return null; // or any other appropriate action
            }

        }
        /// <summary>
        /// visible booking movie
        /// </summary>
        /// <returns></returns>
        public DataSet Show_booked_move()
        {
            try
            {
                SqlCommand com = new SqlCommand("sp_booking", connection);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@choice", "select");
                SqlDataAdapter sqldataadapter = new SqlDataAdapter(com);
                DataSet dataset = new DataSet();
                sqldataadapter.Fill(dataset);
                return dataset;
            }
            catch (Exception exception)
            {
                // Handle the exception here, for example:
                Console.WriteLine("An error occurred: " + exception.Message);
                return null; // or any other appropriate action
            }

        }
        /// <summary>
        /// customer can delete booked movie
        /// </summary>
        /// <param name="bookingid"></param>
        public void delete_book_movie(int bookingid)
        {
            try
            {
                SqlCommand com = new SqlCommand("sp_booking", connection);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@bookingid", bookingid);
                com.Parameters.AddWithValue("@choice", "cancel");

                connection.Open();
                com.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception exception)
            {
                // Handle the exception here
                Console.WriteLine("An error occurred: " + exception.Message);
            }
        }

    }
}
