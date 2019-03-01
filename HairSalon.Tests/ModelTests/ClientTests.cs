using Microsoft.VisualStudio.TestTools.UnitTesting;
using HairSalon.Models;
using System.Collections.Generic;
using System;

namespace HairSalon.Tests
{
    [TestClass]
    public class ClientTest : IDisposable
    {
        public void Dispose()
        {
            Client.ClearAll();
        }
        public ClientTest()
        {
            DBConfiguration.ConnectionString = "server=localhost;user id=root;password=root;port=8889;database=tanner_damron_test;";
        }

        [TestMethod]
        public void ClientConstructor_CreatesInstanceOfClient_Client()
        {
            Client newClient = new Client("jimbo", 1);
            Assert.AreEqual(typeof(Client), newClient.GetType());
        }

        [TestMethod]
        public void GetName_ReturnsName_String()
        {
            string name = "jimbob";
            Client newClient = new Client(name, 1);
            string result = newClient.GetName();
            Assert.AreEqual(name, result);
        }

        [TestMethod]
        public void SetName_SetClientName_String()
        {
            string name = "Jimbo";
            Client newClient = new Client(name, 1);
            string updatedName = "Jimbob";
            newClient.SetName(updatedName);
            string result = newClient.GetName();
            Assert.AreEqual(updatedName, result);
        }

        [TestMethod]
        public void GetAll_ReturnsEmptyList_ClientList()
        {
            List<Client> newList = new List<Client> { };
            List<Client> result = Client.GetAll();
            CollectionAssert.AreEqual(newList, result);
        }

        [TestMethod]
        public void GetAll_ReturnsClients_ClientList()
        {
            string name01 = "jimbob";
            string name02 = "jimbo";
            Client newClient1 = new Client(name01, 1);
            newClient1.Save();
            Client newClient2 = new Client(name02, 1);
            newClient2.Save();
            List<Client> newList = new List<Client> { newClient1, newClient2 };
            List<Client> result = Client.GetAll();
            CollectionAssert.AreEqual(newList, result);
        }

        [TestMethod]
        public void Find_ReturnsCorrectClientFromDatabase_Client()
        {
            Client testClient = new Client("Mow the lawn", 1);
            testClient.Save();
            Client foundClient = Client.Find(testClient.GetId());
            Assert.AreEqual(testClient, foundClient);
        }
    }
}