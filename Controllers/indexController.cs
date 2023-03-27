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

namespace ticket_booking_system.Controllers
{
    public class indexController : Controller
    {
        // GET: index
        database.database databaselayer = new database.database();
        public ActionResult show_data()
        {
            DataSet dataSet = databaselayer.Show_data();
            ViewBag.customer = dataSet.Tables[0];
            return View();
        }
        public ActionResult Add_record()
        {
            return View();


        }


        [HttpPost]

        public ActionResult Add_record(FormCollection fc)
        {
            customer customers= new customer();
            customers.firstname = fc["firstname"];
            customers.lastname = fc["lastname"];
            customers.dateofbirth = fc["dateofbirth"];
            customers.gender = fc["gender"];
            customers.phonenumber = fc["phone"];
            customers.email = fc["email"];
            customers.address = fc["address"];
            customers.state = fc["state"];
            customers.city = fc["city"];
            customers.username = fc["username"];
            customers.password = fc["password"];
            
            databaselayer.Add_record(customers);
            TempData["msg"] = "inserted";

            return View(customers);

        }



        public ActionResult addmovies()
        {
            return View();


        }


        [HttpPost]

        public ActionResult addmovies( FormCollection formcollection, HttpPostedFileBase image)
        {
            if (Session["username"] != null)
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
            else
            {
                return RedirectToAction("customerlogin", "index");
            }
           

        }

        public ActionResult viewmovie()
        {
            DataSet dataSet = databaselayer.viewmovie();
            ViewBag.movies = dataSet.Tables[0];
            return View();
            
        }
        public ActionResult updatemovie(int id)
        {
            DataSet dataset = databaselayer.Showmoviebyid(id);
            ViewBag.jobrecord = dataset.Tables[0];
            return View();
        }

        [HttpPost]
        public ActionResult updatemovie(int id, FormCollection formcollection, HttpPostedFileBase image)
        {
            if (Session["username"] != null)
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
            else
            {
                return RedirectToAction("customerlogin", "index");
            }
            

        }









        public ActionResult deletemovie(int id)
        {
            if (Session["username"] != null)
            {
                string username = Session["username"].ToString();
                ViewBag.Username = username;
                databaselayer.deletemovie(id);
                TempData["msg"] = "Job deleted";
                return RedirectToAction("viewmovie");

            }
            else
            {
                return RedirectToAction("customerlogin", "index");
            }
            
        }

        public ActionResult customerlogin()
        {
             return View();

        }
        [HttpPost]
        public ActionResult customerlogin(FormCollection formcollection)
        {

            customer movie = new customer();
            movie.username = formcollection["username"];
            movie.password = formcollection["password"];
            int count;
            Session["Username"] = null;
            if (movie.username == "admin" && movie.password == "admin@12345")
            {
                Session["username"] = "admin";
                return RedirectToAction("adminhome", "Home");
            }
            DataSet dataset = databaselayer.Login(movie);
            count = dataset.Tables[0].Rows.Count;

            ViewBag.login = dataset.Tables[0];


            if (count == 1)
            {
                Session["username"] = dataset.Tables[0].Rows[0]["username"];
                TempData["msg"] = " login Successfully";
                return RedirectToAction("userhome", "index"); 
            }
            else
            {
                TempData["msg"] = "Invalid username or password";
                return View();
            }


        }
        public ActionResult Logout()
        {
            Session["username"] = null;
            return RedirectToAction("Index", "Home");
        }

        public ActionResult userhome()
        {
            if (Session["username"] != null)
            {
                string username = Session["username"].ToString();
                ViewBag.Username = username;
                return View();
            }
            else
            {
                return RedirectToAction("customerlogin", "index");
            }


        }
        public ActionResult bookmovie()
        {
            if (Session["username"] != null)
            {
                string username = Session["username"].ToString();
                ViewBag.Username = username;
                DataSet dataSet = databaselayer.viewmovie();
                ViewBag.movies = dataSet.Tables[0];
                return View();
            }
            else
            {
                return RedirectToAction("customerlogin", "index");
            }


        }
        public ActionResult contactinformation()
        {
            return View();


        }





    }
}