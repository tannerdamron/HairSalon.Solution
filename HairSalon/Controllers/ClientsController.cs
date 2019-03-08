using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using System.Collections.Generic;

namespace HairSalon.Controllers
{
    public class ClientsController : Controller
    {

        [HttpGet("/clients")]
        public ActionResult Index()
        {
            List<Client> allClients = Client.GetAll();
            return View(allClients);
        }

        [HttpGet("/stylists/{stylistId}/clients/new")]
        public ActionResult New(int stylistId)
        {
            Stylist stylist = Stylist.Find(stylistId);
            return View(stylist);
        }

        [HttpGet("/clients/{clientId}")]
        public ActionResult Show(int clientId)
        {
            Client client = Client.Find(clientId);
            int stylistId = client.GetStylistId();
            Stylist stylist = Stylist.Find(stylistId);
            Dictionary<string, object> model = new Dictionary<string, object>();
            model.Add("client", client);
            model.Add("stylist", stylist);
            return View(model);
        }

        [HttpGet("stylists/{stylistId}/clients/{clientId}")]
        public ActionResult Show(int stylistId, int clientId)
        {
            Client client = Client.Find(clientId);
            Stylist stylist = Stylist.Find(stylistId);
            Dictionary<string, object> model = new Dictionary<string, object>();
            model.Add("client", client);
            model.Add("stylist", stylist);
            return View(model);
        }

        [HttpGet("/stylists/{stylistId}/clients/{clientId}/edit")]
        public ActionResult Edit(int stylistId, int clientId)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Stylist stylist = Stylist.Find(stylistId);
            model.Add("stylist", stylist);
            Client client = Client.Find(clientId);
            model.Add("client", client);
            return View(model);
        }

        [HttpPost("/stylists/{stylistId}/clients/{clientId}")]
        public ActionResult Update(int stylistId, int clientId, string newName)
        {
            Client client = Client.Find(clientId);
            client.Edit(newName);
            Dictionary<string, object> model = new Dictionary<string, object>();
            Stylist stylist = Stylist.Find(stylistId);
            model.Add("stylist", stylist);
            model.Add("client", client);
            return View("Show", model);
        }

        [HttpGet("/stylists/{stylistId}/clients/{clientId}/delete")]
        public ActionResult Delete(int stylistId, int clientId)
        {
            Dictionary<string, object> model = new Dictionary<string, object>();
            Stylist stylist = Stylist.Find(stylistId);
            Client client = Client.Find(clientId);
            model.Add("stylist", stylist);
            model.Add("client", client);
            return View(model);
        }

        [HttpPost("/stylists/{stylsitId}/clients/{clientId}/deleted")]
        public ActionResult DeleteClient(int stylistId, int clientId)
        {
            Stylist stylist = Stylist.Find(stylistId);
            Client client = Client.Find(clientId);
            client.Delete();
            return View("DeletedClient");
        }

        [HttpGet("/clients/delete")]
        public ActionResult DeleteAll()
        {
            Client.ClearAll();
            return View();
        }
    }
}