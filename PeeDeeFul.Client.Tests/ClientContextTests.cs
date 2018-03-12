using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PeeDeeFul.Client.Security;

namespace PeeDeeFul.Client.Tests
{
    [TestClass]
    public class ClientContextTests
    {
        [TestMethod]
        public void CreateContext01()
        {
            var ctx = new ClientContext("appname", new KeyRequestAuthenticator("key1"));
            Assert.AreEqual<Uri>(new Uri("https://appname.azurewebsites.net"), ctx.Url);
        }

        [TestMethod]
        public void CreateContext02()
        {
            var ctx = new ClientContext("https://myapps.mycompany.com/folder1/api", new KeyRequestAuthenticator("key2"));
            Assert.AreEqual<Uri>(new Uri("https://myapps.mycompany.com"), ctx.Url);
        }

        [TestMethod]
        public void CreateContext03()
        {
            var ctx = new ClientContext("https://myapps.mycompany.com:1234/api", new KeyRequestAuthenticator("key2"));
            Assert.AreEqual<Uri>(new Uri("https://myapps.mycompany.com:1234"), ctx.Url);
        }

        [TestMethod]
        public void CreateContext04()
        {
            var ctx = new ClientContext("http://localhost:7071/api/Documents/Render", new KeyRequestAuthenticator("key2"));
            Assert.AreEqual<Uri>(new Uri("http://localhost:7071/"), ctx.Url);
        }

        // 
    }
}
