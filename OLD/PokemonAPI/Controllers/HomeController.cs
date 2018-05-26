using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PokemonAPI.Models.ViewModel;
using PokemonTcgSdk;

namespace PokemonAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult Cards()
        {
            ViewBag.Title = "Home Page";
            var card = Card.Find<Pokemon>("base4-4");
            var vm = new CardsViewModel(card);
            return View(vm);
        }



    }
}
