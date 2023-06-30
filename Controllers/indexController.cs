using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using ticket_booking_system.Models;
using System.IO;
using System.Data.SqlClient;
using System.Reflection;
using System.Security.Cryptography;

namespace ticket_booking_system.Controllers
{
    public class indexController : Controller
    {
        /// <summary>
        /// when it is used to database connection
        /// </summary>
        database.database databaselayer = new database.database();
        public ActionResult show_data()
        {
          try {
                
            string username = Session["username"].ToString();
            DataSet dataSet = databaselayer.Show_data();
            ViewBag.customer = dataSet.Tables[0];
            return View();
            }
          catch (Exception exception) 
            { 
              return RedirectToAction("customerlogin", "index");

            }

        }



        public ActionResult Add_record()
        {
            return View();


        }

        /// <summary>
        /// customer registration 
        /// </summary>

        [HttpPost]

        public ActionResult Add_record(FormCollection formcollection)
        {
            try {
                string password, encriptedpassword;
                customer customers = new customer();
                customers.firstname = formcollection["firstname"];
                customers.lastname = formcollection["lastname"];
                customers.dateofbirth = formcollection["dateofbirth"];
                customers.gender = formcollection["gender"];
                customers.phonenumber = formcollection["phone"];
                customers.email = formcollection["email"];
                customers.address = formcollection["address"];
                customers.state = formcollection["state"];
                customers.city = formcollection["city"];
                customers.username = formcollection["username"];
                password = formcollection["password"];
                encriptedpassword = Encrypt(password);
                customers.password = encriptedpassword;
                databaselayer.Add_record(customers);
                TempData["msg"] = "inserted";
                return View(customers);
             }
            catch(Exception exception)
            {
                string errorMessage = $" {exception.Message}";
                LogErrorToFile(errorMessage);
                return RedirectToAction("customerlogin", "index");

            }

        }

        /// <summary>
        /// when it is used to add movies
        /// </summary>
        /// <returns></returns>

        public ActionResult addmovies()
        {
            return View();


        }
        /// <summary>
        /// admin can add movies
        /// </summary>
        [HttpPost]

        public ActionResult addmovies( FormCollection formcollection, HttpPostedFileBase image)
        {
            try
            {
                string username = Session["username"].ToString();
                ViewBag.Username = username;
                movies moviess = new movies();
                moviess.movie_name = formcollection["movie_name"];
                moviess.description = formcollection["description"];
                moviess.streaming_date = formcollection["streaming_date"];
                moviess.genre = formcollection["genre"];
                moviess.duration = formcollection["duration"];
                moviess.language = formcollection["language"];
                if (image != null && image.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(image.FileName);
                    var path = Path.Combine(Server.MapPath("~/images/"), fileName);
                    image.SaveAs(path);
                    moviess.movie_image = "~/images/" + fileName;
                }
                databaselayer.addmovies(moviess);
                TempData["msg"] = "inserted";

                return View();
            }
            catch (Exception exception)
            {
                return RedirectToAction("customerlogin", "index");

            }



        }

        /// <summary>
        /// delete admin user details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult deletecustomer(int id)
        {
            try
            {
                databaselayer.delete_record(id);
                return RedirectToAction("show_data");
            }
            catch (Exception exception)
            {
                return RedirectToAction("customerlogin", "index");

            }


        }
        /// <summary>
        /// admin can view their added movies
        /// </summary>

        public ActionResult viewmovie()
        {
            try
            {
                DataSet dataSet = databaselayer.viewmovie();
                ViewBag.movies = dataSet.Tables[0];
                return View();
            }
            catch (Exception exception)
            {
                return RedirectToAction("customerlogin", "index");

            }
        }
        /// <summary>
        /// up date movies in admin
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult updatemovie(int id)
        {
            try
            {
                DataSet dataset = databaselayer.Showmoviebyid(id);
                ViewBag.jobrecord = dataset.Tables[0];
                return View();
            }
            catch (Exception exception)
            {
                return RedirectToAction("customerlogin", "index");

            }
        }

        /// <summary>
        /// admin usually have the ability to update movies
        /// </summary>

        [HttpPost]
        public ActionResult updatemovie(int id, FormCollection formcollection, HttpPostedFileBase image)
        {
            try
            {
                string username = Session["username"].ToString();
                ViewBag.Username = username;
                movies movie = new movies();
                movie.Id = id;
                movie.movie_name = formcollection["movie_name"];
                movie.description = formcollection["description"];
                movie.streaming_date = formcollection["streaming_date"];
                movie.genre = formcollection["genre"];
                movie.duration = formcollection["duration"];
                movie.language = formcollection["language"];

                databaselayer.updatemovie(movie);
                TempData["msg"] = "Updated";
                return RedirectToAction("viewmovie");

            }
            catch (Exception exception)
            {
                return RedirectToAction("customerlogin", "index");

            }


        }



        /// <summary>
        /// admins usually have the ability to delete movie
        /// </summary>

        public ActionResult deletemovie(int id)
        {
            try
            {

                string username = Session["username"].ToString();
                ViewBag.Username = username;
                databaselayer.deletemovie(id);
                TempData["msg"] = "movie deleted";
                return RedirectToAction("viewmovie");

            }
            catch (Exception exception)
            {
                return RedirectToAction("customerlogin", "index");

            }

        }
        /// <summary>
        /// customer login in the website
        /// </summary>
        public ActionResult customerlogin()
        {
             return View();

        }
        [HttpPost]
        public ActionResult customerlogin(FormCollection formcollection)
        {
            string password, encriptedpassword;
            customer movie = new customer();
            movie.username = formcollection["username"];
            password = formcollection["password"];
            encriptedpassword = Encrypt(password);
            movie.password = encriptedpassword;
            int count;
            Session["Username"] = null;
            
            DataSet dataset = databaselayer.Login(movie);
            count = dataset.Tables[0].Rows.Count;

            ViewBag.login = dataset.Tables[0];


            if (count == 1)
            {
                Session["username"] = dataset.Tables[0].Rows[0]["username"];
                Session["id"] = dataset.Tables[0].Rows[0]["id"];
                TempData["msg"] = " login Successfully";
                if (Session["username"].ToString() == "admin")
                {
                    return RedirectToAction("adminhome", "Home");
                }
                else
                {
                    return RedirectToAction("userhome", "index");
                }
            }
            else
            {
                TempData["msg"] = "Invalid username or password";
                return View();
            }


        }
        /// <summary>
        /// customer can logout
        /// </summary>
        public ActionResult Logout()
        {
            try
            {
                Session["username"] = null;
                return RedirectToAction("Index", "Home");
            }
            catch (Exception exception)
            {
                return RedirectToAction("customerlogin", "index");

            }
        }
        /// <summary>
        /// customer home page 
        /// </summary>
        /// <returns></returns>
        public ActionResult userhome()
        {
            try
            {
                string username = Session["username"].ToString();
                ViewBag.Username = username;
                return View();
            }
            catch (Exception exception)
            {
                return RedirectToAction("customerlogin", "index");

            }




        }
        /// <summary>
        /// contact page of the website for customer can contact for the company
        /// </summary>
        public ActionResult contactinformation()
        {
            return View();


        }
        /// <summary>
        /// user profile user can view their profile
        /// </summary>
        public ActionResult userprofile()
        {
            try
            {
                string username = Session["username"].ToString();
                ViewBag.Username = username;
                DataSet dataSet = databaselayer.userprofile(username);
                ViewBag.user = dataSet.Tables[0];
                return View();
            }
            catch (Exception exception)
            {
                return RedirectToAction("customerlogin", "index");

            }




        }

        /// <summary>
        /// customer can able to visible the movie  in site 
        /// </summary>
        
        public ActionResult bookingconformation()
        {
           try
            {
                string username = Session["username"].ToString();
                ViewBag.Username = username;
                DataSet dataSet = databaselayer.viewmovie();
                ViewBag.movies = dataSet.Tables[0];
                return View();
            }
            catch (Exception exception) 
            {
                return RedirectToAction("customerlogin", "index");

            }



        }

        /// <summary>
        /// customer can able to book movie in the website
        /// </summary>
        
        public ActionResult Book_Movie_Byuser(int id)
        {
            try
            {

                string username = Session["username"].ToString();
                int user_id = Convert.ToInt32(Session["id"]);

                ViewBag.Username = username;

                booking booking = new booking();
                booking.userid = user_id;
                booking.movieid = id;
                databaselayer.book_movie(booking);
                TempData["msg"] = "Applied";
                return RedirectToAction("bookingconformation");
            }
            catch (Exception exception)
            {
                return RedirectToAction("customerlogin", "index");

            }


        }

        /// <summary>
        /// user can visible the booked movies
        /// </summary>
        /// <returns></returns>
        public ActionResult UserViewbooking()
        {
            try
            {
                string username = Session["username"].ToString();
                int user_id = Convert.ToInt32(Session["id"]);
                booking booking = new booking();
                booking.userid = user_id;

                ViewBag.userid = user_id;
                DataSet dataset = databaselayer.Show_Bokking_movie(booking);
                ViewBag.book = dataset.Tables[0];

                DataSet allmovie = databaselayer.Show_booking();
                ViewBag.allmovie = allmovie.Tables[0];
                return View();
            }
            catch (Exception exception)
            {
                return RedirectToAction("customerlogin", "index");

            }

        }
        /// <summary>
        /// user can be delete booked movies
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult deletebookmovie(int id)
        {

            databaselayer.delete_book_movie(id);
            TempData["message"] = "delete removed successfully";
            return RedirectToAction("UserViewbooking");

        }
        /// <summary>
        /// admin can be view booked movie
        /// </summary>
        /// <returns></returns>
        public ActionResult adminviewbooking()
        {
            try
            {
                string username = Session["username"].ToString();
                booking booking = new booking();



                DataSet dataSet = databaselayer.viewmovie();
                ViewBag.allmovie = dataSet.Tables[0];

                DataSet data = databaselayer.Show_booked_move();
                ViewBag.bookedmovie = data.Tables[0];
                return View();
            }
            catch (Exception exception)
            {
                return RedirectToAction("customerlogin", "index");

            }

        }

        private static readonly byte[] _key = new byte[16] { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 110, 120, 130, 140, 150, 160 };
        private static readonly byte[] _iv = new byte[16] { 20, 30, 40, 50, 60, 70, 80, 90, 100, 110, 120, 130, 140, 150, 160, 10 };

        /// <summary>
        /// This can be used to encript the password
        /// </summary>
        /// <param name="plainText"></param>
        /// <returns></returns>

        public static string Encrypt(string plainText)
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = _key;
                aesAlg.IV = _iv;

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(plainText);
                        }
                        byte[] encrypted = msEncrypt.ToArray();
                        return Convert.ToBase64String(encrypted);
                    }
                }
            }
        }

        /// <summary>
        /// when it is used to decrypt the encrypted password
        /// </summary>
        /// <param name="cipherText"></param>
        /// <returns></returns>
        public static string Decrypt(string cipherText)
        {
            byte[] cipherBytes = Convert.FromBase64String(cipherText);

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = _key;
                aesAlg.IV = _iv;

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using (MemoryStream msDecrypt = new MemoryStream(cipherBytes))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
        }

        private void LogErrorToFile(string errorMessage)
        {
            string filePath = "C:/Logs/MyAppErrors.log";

            // write the error message to the log file
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine(errorMessage);
            }
        }






    }
}