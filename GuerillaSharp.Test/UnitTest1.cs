using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GuerrillaSharp;
using System.Linq;
using GuerrillaSharp.Models;
using System.Threading.Tasks;

namespace GuerillaSharp.Test
{
    [TestClass]
    public class UnitTest1
    {
        GuerrillaMail email = new GuerrillaMail();

        [TestMethod]
        public async Task TestGetEmailAddress()
        {
            await email.GetEmailAddress();
            Assert.IsNotNull(email.EmailAddress);
        }

        [TestMethod]
        public async Task TestCheckEmail()
        {
            await email.GetEmailAddress();
            var emails = await email.CheckEmail();
            Assert.AreNotEqual(0, emails.Count);
        }

        [TestMethod]
        public async Task TestFetchEmail()
        {
            await email.GetEmailAddress();
            var emails = await email.CheckEmail();
            Email selectemail = await email.FetchEmail(emails.First().MailId);
            Assert.AreNotEqual(0, selectemail.MailId.Length);
        }
    }
}
