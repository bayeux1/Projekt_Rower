using DL.Models;
using DL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using System.IO;
using Microsoft.AspNet.Identity;

namespace Projekt_Rower.Controllers
{
    public class AdminController : Controller
    {
        [Authorize(Roles = "admin")]
        public ActionResult Index()
        {
            return View();
        }
        private AdminService _adminService;
        public AdminController()
        {
            _adminService = new AdminService();
        }

        [HttpGet]
        public ActionResult GetWidoki()
        {
            var widoki = _adminService.GetWidoki();
            return PartialView(@"~/Views/Admin/Widoki.cshtml", widoki);

        }
        [HttpGet]
        public ActionResult GetNiebezpieczenstwa()
        {
            var niebezpieczenstwa = _adminService.GetNiebezpieczenstwa();
            return PartialView(@"~/Views/Admin/Niebezpieczenstwa.cshtml", niebezpieczenstwa);

        }
        [HttpGet]
        public ActionResult GetOceny()
        {
            var oceny = _adminService.GetOceny();
            return PartialView(@"~/Views/Admin/Oceny.cshtml", oceny);

        }
        [HttpGet]
        public ActionResult GetTrasa_Ulice()
        {
            var trasa_ulice = _adminService.GetTrasa_Ulice();
            return PartialView(@"~/Views/Admin/Trasa_Ulice.cshtml", trasa_ulice);

        }

        [HttpGet]
        public ActionResult GetUsers()
        {
            var users = _adminService.GetUser();
            return PartialView(@"~/Views/Admin/Uzytkownicy.cshtml", users);

        }
        [HttpGet]
        public ActionResult GetTracks()
        {
            var tracks = _adminService.GetTrasy();
            return PartialView(@"~/Views/Admin/Trasy.cshtml", tracks);

        }
        [Route("{id}")]
        public ActionResult EditNiebezpieczenstwa(int? id)
        {
            var niebezpieczenstwo = _adminService.GetNiebezpieczenstwa(id.Value);
            if (niebezpieczenstwo == null)
            {
                return HttpNotFound();
            }

            return View(niebezpieczenstwo);
        }
        [Route("{id}")]
        public ActionResult EditOceny(int? id)
        {
            var oceny = _adminService.GetOceny(id.Value);
            if (oceny == null)
            {
                return HttpNotFound();
            }

            return View(oceny);
        }
        [Route("{id}")]
        public ActionResult EditTrasa_Ulice(int? id)
        {
            var trasa_ulice = _adminService.GetTrasa_Ulice(id.Value);
            if (trasa_ulice == null)
            {
                return HttpNotFound();
            }

            return View(trasa_ulice);
        }

        [Route("{id}")]
        public ActionResult EditWidoki(int? id)
        {
            var widok = _adminService.GetWidoki(id.Value);
            if (widok == null)
            {
                return HttpNotFound();
            }

            return View(widok);
        }

        [Route("{id}")]
    public ActionResult EditUzytkownicy(int? id)
    {
        var user = _adminService.GetUserData(id.Value);
        if (user == null)
        {
            return HttpNotFound();
        }

        return View(user);
    }
        [Route("{id}")]
        public ActionResult DetailsWidoki(int? id)
        {
            var widok = _adminService.GetWidoki(id.Value);
            if (widok == null)
            {
                return HttpNotFound();
            }
            return View(widok);
        }
        [Route("{id}")]
        public ActionResult DetailsNiebezpieczenstwa(int? id)
        {
            var niebezpieczenstwa = _adminService.GetNiebezpieczenstwa(id.Value);
            if (niebezpieczenstwa == null)
            {
                return HttpNotFound();
            }
            return View(niebezpieczenstwa);
        }
        [Route("{id}")]
        public ActionResult DetailsOceny(int? id)
        {
            var oceny = _adminService.GetOceny(id.Value);
            if (oceny == null)
            {
                return HttpNotFound();
            }
            return View(oceny);
        }
        [Route("{id}")]
        public ActionResult DetailsTrasa_Ulice(int? id)
        {
            var trasa_ulice = _adminService.GetTrasa_Ulice(id.Value);
            if (trasa_ulice == null)
            {
                return HttpNotFound();
            }
            return View(trasa_ulice);
        }
        [Route("{id}")]
    public ActionResult DetailsUzytkownicy(int? id)
    {
        var user = _adminService.GetUserData(id.Value);
        if (user == null)
        {
            return HttpNotFound();
        }
        return View(user);
    }
    [Route("{id}")]
    public ActionResult DeleteUzytkownicy(int? id)
    {

        var user = _adminService.GetUserData(id.Value);
        if (user == null)
        {
            return HttpNotFound();
        }
        return View(user);
    }
        [HttpPost]
        public ActionResult EditNiebezpieczenstwa(Niebezpieczenstwa niebezpieczenstwo)
        {
            _adminService.EditNiebezpieczenstwa(niebezpieczenstwo);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult EditOceny(Oceny oc)
        {
            _adminService.EditOceny(oc);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult EditTrasa_Ulice(Trasa_Ulice trasa_ulice)
        {
            _adminService.EditTrasa_Ulice(trasa_ulice);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult EditWidok(Widoki widok)
        {
            _adminService.EditWidoki(widok);
            return RedirectToAction("Index");
        }

        [HttpPost]
    public ActionResult EditUzytkownicy(Uzytkownicy user)
    {
        _adminService.UserProfileEdit(user);
        return RedirectToAction("Index");
    }
    [HttpPost]
    public ActionResult DeleteUzytkownicy(int id)
    {
        var user = _adminService.GetUserData(id);
        if (user == null)
        {
            return HttpNotFound();
        }
        _adminService.DeleteUser(id);
        return RedirectToAction("Index");
    }

    public ActionResult Trasy()
    {
        return View(_adminService.GetTrasy());
    }



    [Route("{id}")]
    public ActionResult DetailsTrasy(int? id)
    {
        var track = _adminService.GetTrasy(id.Value);

        return View(track);
    }



    [Route("{id}")]
    public ActionResult EditTrasy(int? id)
    {
        var track = _adminService.GetTrasy(id.Value);
        return View(track);
    }

    [Route("{id}")]
    public ActionResult DeleteTrasy(int? id)
    {
        var track = _adminService.GetTrasy(id.Value);

        return View(track);
    }

        [Route("{id}")]
        public ActionResult DeleteWidoki(int? id)
        {
            var widok = _adminService.GetWidoki(id.Value);

            return View(widok);
        }
        [Route("{id}")]
        public ActionResult DeleteNiebezpieczenstwa(int? id)
        {
            var niebezpieczenstwa = _adminService.GetNiebezpieczenstwa(id.Value);

            return View(niebezpieczenstwa);
        }
        [Route("{id}")]
        public ActionResult DeleteOceny(int? id)
        {
            var oceny = _adminService.GetOceny(id.Value);

            return View(oceny);
        }
        [Route("{id}")]
        public ActionResult DeleteTrasa_Ulice(int? id)
        {
            var trasy_ulice = _adminService.GetTrasa_Ulice(id.Value);

            return View(trasy_ulice);
        }

        public ActionResult AddNiebezpieczenstwa()
        {
            return View();
        }
        public ActionResult AddOceny()
        {
            return View();
        }
        public ActionResult AddTrasa_Ulice()
        {
            return View();
        }
        public ActionResult AddWidoki()
        {
            return View();
        }
        public ActionResult AddTrasy()
    {
        return View();
    }
    [HttpPost]
    public ActionResult DeleteTrasy(int id)
    {
        var track = _adminService.GetTrasy(id);
        _adminService.DeleteTrack(id);
        return RedirectToAction("Index");
    }
        [HttpPost]
        public ActionResult DeleteWidoki(int id)
        {
            var widoki = _adminService.GetWidoki(id);
            _adminService.DeleteWidoki(id);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult DeleteNiebezpieczenstwa(int id)
        {
            var niebezpieczenstwa = _adminService.GetNiebezpieczenstwa(id);
            _adminService.DeleteNiebezpieczenstwa(id);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult DeleteOceny(int id)
        {
            var oceny = _adminService.GetOceny(id);
            _adminService.DeleteOceny(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult DeleteTrasa_Ulice(int id)
        {
            var trasa_ulice = _adminService.GetTrasa_Ulice(id);
            _adminService.DeleteTrasa_Ulice(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult EditWidoki(Widoki widok)
        {

            _adminService.EditWidoki(widok);
            return RedirectToAction("Index");
        }


        [HttpPost]
    public ActionResult EditTrasy(Trasy track)
    {

        _adminService.EditTrack(track);
        return RedirectToAction("Index");
    }
    [HttpPost]
    public ActionResult AddTrasy(Trasy track)
    {
        _adminService.AddTrack(track);

        return RedirectToAction("Index");
    }
        [HttpPost]
        public ActionResult AddWidoki(Widoki widok)
        {
            _adminService.AddWidok(widok);

            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult AddNiebezpieczenstwa(Niebezpieczenstwa niebezpieczenstwo)
        {
            _adminService.AddNiebezpieczenstwa(niebezpieczenstwo);

            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult AddOceny(Oceny oc)
        {
            _adminService.AddOceny(oc);

            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult AddTrasa_Ulice(Trasa_Ulice trasa_ulice)
        {
            _adminService.AddTrasa_Ulice(trasa_ulice);

            return RedirectToAction("Index");
        }
    }
}