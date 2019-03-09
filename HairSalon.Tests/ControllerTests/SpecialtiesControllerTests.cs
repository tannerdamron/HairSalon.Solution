using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using HairSalon.Controllers;
using HairSalon.Models;

namespace HairSalon.Tests
{
    [TestClass]
    public class SpecialtiesControllerTest
    {
        [TestMethod]
        public void Index_ReturnsCorrectView_True()
        {
            SpecialtiesController controller = new SpecialtiesController();
            ActionResult indexView = controller.Index();
            Assert.IsInstanceOfType(indexView, typeof(ViewResult));
        }

        [TestMethod]
        public void New_ReturnsCorrectView_True()
        {
            SpecialtiesController controller = new SpecialtiesController();
            ActionResult newView = controller.New(1);
            Assert.IsInstanceOfType(newView, typeof(ViewResult));
        }

        [TestMethod]
        public void Create_ReturnsCorrectView_True()
        {SpecialtiesController controller = new SpecialtiesController();
            ActionResult newView = controller.Create("Jane");
            Assert.IsInstanceOfType(newView, typeof(ViewResult));
        }

        [TestMethod]
        public void Show_ReturnsCorrectView_True()
        {
            SpecialtiesController controller = new SpecialtiesController();
            ActionResult newView = controller.Show(0);
            Assert.IsInstanceOfType(newView, typeof(ViewResult));
        }

        [TestMethod]
        public void AddStylist_ReturnsRedirectToCorrectAction_Show()
        {
            SpecialtiesController controller = new SpecialtiesController();
            RedirectToActionResult newView = controller.AddStylist(1, 1) as RedirectToActionResult;
            string result = newView.ActionName; 
            Assert.AreEqual(result, "Show");
        }
    }
}