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
            await email.CheckEmail();
            Assert.AreNotEqual(0, email.EmailCount);
        }

        [TestMethod]
        public async Task TestFetchEmail()
        {
            await email.GetEmailAddress();
            await email.CheckEmail();
            Email selectemail = await email.FetchEmail(email.Emails.FirstOrDefault().MailId);
            Assert.AreNotEqual(0, selectemail.MailId.Length);
        }
    }
}
