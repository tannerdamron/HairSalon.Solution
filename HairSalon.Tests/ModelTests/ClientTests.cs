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

        [TestMethod]
        public void Equals_ReturnsTrueIfDescriptionsAreTheSame_Client()
        {
            Client firstClient = new Client("Jimbo", 1);
            Client secondClient = new Client("Jimbo", 1);
            Assert.AreEqual(firstClient, secondClient);
        }

        [TestMethod]
        public void Save_SavesToDatabase_ClientList()
        {
            Client testClient = new Client("Jimbo", 1);
            testClient.Save();
            List<Client> result = Client.GetAll();
            List<Client> testList = new List<Client> { testClient };
            CollectionAssert.AreEqual(testList, result);
        }

        [TestMethod]
        public void Save_AssignsIdToObject_Id()
        {
            Client testClient = new Client("Jimbo", 1);
            testClient.Save();
            Client savedClient = Client.GetAll()[0];
            int result = savedClient.GetId();
            int testId = testClient.GetId();
            Assert.AreEqual(testId, result);
        }

        [TestMethod]
        public void Edit_UpdatesClientInDatabase_String()
        {
            Client testClient = new Client("Jimbo", 1);
            testClient.Save();
            string secondDescription = "Jimbob";
            testClient.Edit(secondDescription);
            string result = Client.Find(testClient.GetId()).GetName();
            Assert.AreEqual(secondDescription, result);
        }

        [TestMethod]
        public void GetStylistId_ReturnsClientsParentStylistId_Int()
        {
            Stylist newStylist = new Stylist("Jane");
            Client newClient = new Client("Jimbo", 0, newStylist.GetId());
            int result = newClient.GetStylistId();
            Assert.AreEqual(newStylist.GetId(), result);
        }

        [TestMethod]
        public void Delete_DeletesClientFromDatabase_NoClient()
        {
            Client testClient = new Client("Jimbo", 1);
            Client emptyList = new Client("", 0);
            Client foundClient = Client.Find(testClient.GetId());
            foundClient.Delete();
            Assert.AreEqual(foundClient, emptyList);
        }
    }
}