using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Controllers;
using HairSalon.Models;

namespace HairSalon.Tests
{
    [TestClass]
    public class StylistsControllerTest
    {
        [TestMethod]
        public void Index_ReturnsCorrectView_True()
        {
            StylistsController controller = new StylistsController();
            ActionResult indexView = controller.Index();
            Assert.IsInstanceOfType(indexView, typeof(ViewResult));
        }

        [TestMethod]
        public void New_ReturnsCorrectView_True()
        {
            StylistsController controller = new StylistsController();
            ActionResult newView = controller.New();
            Assert.IsInstanceOfType(newView, typeof(ViewResult));
        }

        [TestMethod]
        public void Create_ReturnsCorrectView_True()
        {
            StylistsController controller = new StylistsController();
            ActionResult newView = controller.Create("Jane");
            Assert.IsInstanceOfType(newView, typeof(RedirectToActionResult));
        }

        [TestMethod]
        public void Show_ReturnsCorrectView_True()
        {
            StylistsController controller = new StylistsController();
            ActionResult newView = controller.Show(0);
            Assert.IsInstanceOfType(newView, typeof(ViewResult));
        }

        [TestMethod]
        public void Delete_ReturnsCorrectView_True()
        {
            StylistsController controller = new StylistsController();
            ActionResult newView = controller.Delete(0);
            Assert.IsInstanceOfType(newView, typeof(ViewResult));
        }
    }
}