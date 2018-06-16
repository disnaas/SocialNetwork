using Evaluation_ASPNET_TECHNOBOOK.Infrastructure;
using Evaluation_ASPNET_TECHNOBOOK.Models;
using Model.Client.Entity;
using Model.Client.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Evaluation_ASPNET_TECHNOBOOK.Controllers
{
    
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [Anonymous]
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [Anonymous]
        public ActionResult Register(UtilisateursForm form)
        {
            if (ModelState.IsValid)
            {
                try
                {
                ServiceClientLocator.Instance.Utilisateurs.Insert(new Utilisateurs(form.Nom,form.Prenom,form.AdresseMail,form.Password,form.DateNaissance));

                }
                catch (Exception ex) when(ex.Data.Contains("Number") && ((int)ex.Data["Number"]) == 2627)
                {

                    ViewBag.ErrorEmail = "L'adresse email est déjà enregistrée";
                }

                if (ViewBag.ErrorEmail != null)
                    return View(form);

                return RedirectToAction("Login", "Home");
            }
            return View(form);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [Anonymous]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [Anonymous]
        public ActionResult Login(LoginForm form)
        {
            if (ModelState.IsValid)
            {
                Utilisateurs u = ServiceClientLocator.Instance.Utilisateurs.Get(form.Password, form.AdresseMail);
                
                if (u == null)
                {
                    ViewBag.ErrorIsLog = "Adresse Mail et / ou mot de passe incorrect";
                    return View(form);
                }
                   SessionManager.Users = u;
                   return RedirectToAction("Index", "Member", new { area = "Profil" });
            }
            return View(form);
        }
    }
}