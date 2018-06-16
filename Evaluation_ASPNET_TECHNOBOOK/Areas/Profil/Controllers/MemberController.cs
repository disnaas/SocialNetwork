using Evaluation_ASPNET_TECHNOBOOK.Areas.Profil.Models;
using Evaluation_ASPNET_TECHNOBOOK.Infrastructure;
using Evaluation_ASPNET_TECHNOBOOK.Models;
using Model.Client.Entity;
using Model.Client.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Evaluation_ASPNET_TECHNOBOOK.Areas.Profil.Controllers
{
    [AuthRequired]
    public class MemberController : Controller
    {
        #region FilActualité
        public ActionResult Feed()
        {
            List<FeedForm> Liste = new List<FeedForm>();
            foreach (Utilisateurs user in ServiceClientLocator.Instance.Utilisateurs.Get().Where(c => c.AdresseMail == SessionManager.Users.AdresseMail))
            {
                if (user.UsersID == SessionManager.Users.UsersID)
                {
                    foreach (Fil fil in ServiceClientLocator.Instance.Fil.Get())
                    {
                        if (fil.UsersID == user.UsersID)
                        {
                            Liste.Add(new FeedForm() { Prenom = user.Prenom, Text = fil.Text, Id = fil.FilID, UsersID = user.UsersID, DatePost = fil.DateLigne });
                        }
                        else
                        {
                            foreach (Amis item in ServiceClientLocator.Instance.Amis.Get())
                            {
                                if (item.UsersID == SessionManager.Users.UsersID)
                                {

                                    if (item.IsAmis == true)
                                    {
                                        if (fil.UsersID == item.AmisID)
                                        {
                                            Utilisateurs u = ServiceClientLocator.Instance.Utilisateurs.Get(item.AmisID);
                                            Liste.Add(new FeedForm() { Prenom = u.Prenom, Text = fil.Text, Id = fil.FilID, UsersID = item.AmisID, DatePost = fil.DateLigne });

                                        }
                                    }

                                }
                            }
                        }
                    }
                }
            }
            return View(Liste);
        }
        #endregion

        #region Index
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(FilForm form)
        {
            if (ModelState.IsValid)
            {
                ServiceClientLocator.Instance.Fil.Insert(new Fil(SessionManager.Users.UsersID, form.Text));
                return RedirectToAction("Index", "Member");
            }
            return View(form);
        }
        #endregion

        #region Recherche Effective
        public ActionResult Recherche(RechercheForm form)
        {
            List<RechercheForm> ListRecherche = new List<RechercheForm>();
            int count = 1;
            foreach (Utilisateurs user in ServiceClientLocator.Instance.Utilisateurs.Get().Where(c => c.Prenom == form.Prenom))
            {
                if (user.UsersID != SessionManager.Users.UsersID && user.Nom == form.Nom)
                {
                    if (ServiceClientLocator.Instance.Amis.Get().Select(c => c.UsersID).Contains(user.UsersID))
                    {
                        foreach (Amis item in ServiceClientLocator.Instance.Amis.Get().Where(c => c.UsersID == user.UsersID))
                        {
                            if (item.AmisID == SessionManager.Users.UsersID)
                            {
                                return View(ListRecherche);
                            }
                            else if (ServiceClientLocator.Instance.Amis.Get().Count(c => c.UsersID == user.UsersID) == count)
                            {
                                ListRecherche.Add(new RechercheForm() { UsersID = user.UsersID, Prenom = user.Prenom, Nom = user.Nom, DateInscription = user.DateInscription });
                                return View(ListRecherche);
                            }
                            count++;
                        }
                    }
                    else
                    {
                        ListRecherche.Add(new RechercheForm() { UsersID = user.UsersID, Prenom = user.Prenom, Nom = user.Nom, DateInscription = user.DateInscription });
                        return View(ListRecherche);
                    }
                }
            }
            return View(ListRecherche);
        }
        #endregion

        #region Recherche Prenom
        public ActionResult Search()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Search(SearchForm form)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Recherche", new RouteValueDictionary(new { controller = "Member", action = "Recherche", prenom = form.Prenom, nom = form.Nom }));
            }
            return View(form);
        }
        #endregion

        #region Logout
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Home", new { area = "" });
        }
        #endregion

        public ActionResult Add(RechercheForm Form)
        {
            ServiceClientLocator.Instance.Amis.Insert(new Amis(SessionManager.Users.UsersID, Form.UsersID, false, true));
            return RedirectToAction("Recherche", "Member", new { area = "Profil" });
        }

        public ActionResult DemandeAmis(DemandeAmis form)
        {
            List<DemandeAmis> ListAmis = new List<DemandeAmis>();
            foreach (Amis item in ServiceClientLocator.Instance.Amis.Get())
            {
                if (item.UsersID == SessionManager.Users.UsersID)
                {
                    foreach (Utilisateurs itemuser in ServiceClientLocator.Instance.Utilisateurs.Get())
                    {
                        if (itemuser.UsersID == item.AmisID && item.DemandeAmis == true)
                        {
                            ListAmis.Add(new DemandeAmis() { Prenom = itemuser.Prenom, Nom = itemuser.Nom, UsersID = itemuser.UsersID });
                        }
                    }
                }
            }
            return View(ListAmis);
        }
        public ActionResult CanAdd(DemandeAmis form)
        {
            ServiceClientLocator.Instance.Amis.Change(new Amis(SessionManager.Users.UsersID, form.UsersID, false, false));
            return RedirectToAction("DemandeAmis", "Member", new { area = "Profil" });
        }
        public ActionResult Amis(AmisForm form)
        {
            List<AmisForm> AmisActuelle = new List<AmisForm>();
            foreach (Utilisateurs item in ServiceClientLocator.Instance.Utilisateurs.Get())
            {
                if (item.UsersID != SessionManager.Users.UsersID)
                {
                    foreach (Amis amitem in ServiceClientLocator.Instance.Amis.Get())
                    {
                        if (amitem.AmisID == item.UsersID && SessionManager.Users.UsersID == amitem.UsersID && amitem.IsAmis == true)
                        {
                            AmisActuelle.Add(new AmisForm() { Prenom = item.Prenom, Nom = item.Nom, DateDinscription = item.DateInscription, DateNaissance = item.DateNaissance, UsersID = item.UsersID });
                        }
                    }

                }
            }
            return View(AmisActuelle);
        }
        public ActionResult SuppAmis(AmisForm form)
        {
            ServiceClientLocator.Instance.Amis.SuppFriend(new Amis(SessionManager.Users.UsersID, form.UsersID, false, false));
            return RedirectToAction("Amis", "Member", new { area = "Profil" });
        }
        public ActionResult Modif(FeedForm Fom)
        {
            return View(Fom);
        }
        [HttpPost]
        public ActionResult Modif(FeedForm form, int id)
        {
            ServiceClientLocator.Instance.Fil.Update(new Fil(SessionManager.Users.UsersID, form.Text, id));
            return RedirectToAction("Feed", "Member", new { area = "Profil" });
        }
        public ActionResult SuppPost(int id)
        {
            ServiceClientLocator.Instance.Fil.Delete(new Fil(SessionManager.Users.UsersID, id));
            return RedirectToAction("Feed", "Member", new { area = "Profil" });
        }
        public ActionResult Update()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Update(UpdateUserForm form)
        {
            ServiceClientLocator.Instance.Utilisateurs.Update(new Utilisateurs(SessionManager.Users.UsersID, form.Nom, form.Prenom, form.Email));
            return RedirectToAction("Update", "Member");
        }
        public ActionResult SupprimerProfil()
        {
            ServiceClientLocator.Instance.Utilisateurs.Delete(new Utilisateurs(SessionManager.Users.UsersID));
            return RedirectToAction("Index", "Home",new { area = "" });
        }
    }
}