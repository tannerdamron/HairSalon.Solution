using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Controllers;
using HairSalon.Models;

namespace HairSalon.Tests
{
    [TestClass]
    public class ClientControllerTest
    {

        [TestMethod]
        public void New_ReturnsCorrectView_True()
        {
            ClientsController controller = new ClientsController();
            ActionResult view = controller.New(1);
            Assert.IsInstanceOfType(view, typeof(ViewResult));
        }

        [TestMethod]
        public void Show_ReturnsCorrectView_True()
        {
            ClientsController controller = new ClientsController();
            ActionResult newView = controller.Show(1, 1);
            Assert.IsInstanceOfType(newView, typeof(ViewResult));
        }

        [TestMethod]
        public void Edit_ReturnsCorrectView_True()
        {
            ClientsController controller = new ClientsController();
            ActionResult newView = controller.Edit(1, 1);
            Assert.IsInstanceOfType(newView, typeof(ViewResult));
        }

        [TestMethod]
        public void Update_ReturnsCorrectView_True()
        {
            ClientsController controller = new ClientsController();
            ActionResult newView = controller.Update(1, 1, "Jimbo");
            Assert.IsInstanceOfType(newView, typeof(ViewResult));
        }

        [TestMethod]
        public void Delete_ReturnsCorrectView_True()
        {
            ClientsController controller = new ClientsController();
            ActionResult newView = controller.Delete(1, 1);
            Assert.IsInstanceOfType(newView, typeof(ViewResult));
        }
    }
}