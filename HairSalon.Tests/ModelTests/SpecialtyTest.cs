using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;
using System.Collections.Generic;
using System;

namespace HairSalon.Tests
{
    [TestClass]
    public class SpecialtyTest : IDisposable
    {
        public void Dispose()
        {
            Specialty.ClearAll();
        }
        public SpecialtyTest()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=tanner_damron_test;";
        }

        [TestMethod]
        public void SpecialtyConstructor_CreatesInstanceOfSpecialty_Specialty()
        {
            Specialty newSpecialty = new Specialty("Bob Cut", 0);
            Assert.AreEqual(typeof(Specialty), newSpecialty.GetType());
        }

        [TestMethod]
        public void GetName_ReturnsName_String()
        {
            string name = "Bob Cut";
            int id = 0;
            Specialty newSpecialty = new Specialty(name, id);
            string result = newSpecialty.GetName();
            Assert.AreEqual(name, result);
        }

        [TestMethod]
        public void Save_SavesSpecialtyToDatabase_SpecialtyList()
        {
            Specialty testSpecialty = new Specialty("Bob Cut");
            testSpecialty.Save();
            List<Specialty> result = Specialty.GetAll();
            List<Specialty> testList = new List<Specialty> { testSpecialty };
            CollectionAssert.AreEqual(testList, result);
        }

        [TestMethod]
        public void GetAll_ReturnsAllSpecialtyObjects_SpecialtyList()
        {
            string name01 = "BobCut";
            string name02 = "RainbowDye";
            Specialty newSpecialty1 = new Specialty(name01);
            newSpecialty1.Save();
            Specialty newSpecialty2 = new Specialty(name02);
            newSpecialty2.Save();
            List<Specialty> newList = new List<Specialty> { newSpecialty1, newSpecialty2 };
            List<Specialty> result = Specialty.GetAll();
            CollectionAssert.AreEqual(newList, result);
        }
    }
}