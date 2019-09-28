using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MailSender.lib.Services.InMemory;
using MailSender.lib.Entityes;

namespace MailSender.lib.Tests.Services.InMemory
{
    [TestClass]
    public class InMemoryRecipientsDataProviderTests
    {
        [AssemblyInitialize]
        public static void TestAssembly_Initialize(TestContext context)
        {

        }

        [ClassInitialize]
        public static void TestClass_Initialize(TestContext context)
        {

        }

        [TestInitialize]
        public void Test_Initialize()
        {

        }

        [TestCleanup]
        public void Test_Celanup()
        {

        }

        [ClassCleanup]
        public static void TestClass_Cleanup()
        {

        }

        [AssemblyCleanup]
        public static void TestAssembly_Cleanup()
        {

        }

        public InMemoryRecipientsDataProviderTests()
        {

        }

        [TestMethod]
        public void CreateNewRecipientInEmptyProvider()
        {
            var data_provider = new InMemoryRecipientsDataProvider();

            var expected_recipient_name = "Получатель 1";
            var expected_recipient_address = "recipient1@server.com";
            var expected_id = 1;

            var new_recipient = new Recipient
            {
                Name = expected_recipient_name,
                Address = expected_recipient_address
            };

            data_provider.Create(new_recipient);
            var actual_id = new_recipient.Id;

            var actual_recipient = data_provider.GetById(expected_id);

            Assert.AreEqual(expected_id, actual_id);
            Assert.AreEqual(expected_recipient_name, actual_recipient.Name);
            Assert.AreEqual(expected_recipient_address, actual_recipient.Address);

            StringAssert.Matches("value string", new System.Text.RegularExpressions.Regex(@"\w+\s\w+"));

            //CollectionAssert.AllItemsAreUnique(...)

            if (expected_id != actual_id)
                throw new AssertFailedException("Идентификаторы объектов не совпадают");
        }
    }
}
