﻿using NPGeek.Web.DAL;
using NPGeek.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NPGeek.Web.Controllers
{
    public class HomeController : Controller
    {
        IParkDAL dal;
        IWeatherDAL dalWeather;

        public HomeController(IParkDAL dal, IWeatherDAL dalWeather)
        {
            this.dal = dal;
            this.dalWeather = dalWeather;
        }

        // GET: Home
        public ActionResult Index()
        {
            List<ParkModel> list = dal.GetAllParks();
            return View("Index", list);
        }

        public ActionResult Detail(string parkCode)
        {
            ParkModel model = dal.GetPark(parkCode);
            return View("Detail", model);
        }

        public ActionResult WeatherDisplay(string parkCode)
        {
            List<WeatherModel> weather = dalWeather.GetWeather(parkCode);
            return PartialView(weather);
        }
    }
}