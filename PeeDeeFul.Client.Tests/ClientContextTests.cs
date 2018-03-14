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
            var ctx = new PdfClientContext("appname", new KeyRequestAuthenticator("key1"));
            Assert.AreEqual<Uri>(new Uri("https://appname.azurewebsites.net/api"), ctx.BaseUrl);
        }

        [TestMethod]
        public void CreateContext02()
        {
            var ctx = new PdfClientContext("https://myapps.mycompany.com/folder1/api", new KeyRequestAuthenticator("key2"));
            Assert.AreEqual<Uri>(new Uri("https://myapps.mycompany.com/folder1/api"), ctx.BaseUrl);
        }

        [TestMethod]
        public void CreateContext03()
        {
            var ctx = new PdfClientContext("https://myapps.mycompany.com:1234/api", new KeyRequestAuthenticator("key2"));
            Assert.AreEqual<Uri>(new Uri("https://myapps.mycompany.com:1234/api"), ctx.BaseUrl);
        }

        [TestMethod]
        public void CreateContext04()
        {
            var ctx = new PdfClientContext("http://localhost:7071/somefolder", new KeyRequestAuthenticator("key2"));
            Assert.AreEqual<Uri>(new Uri("http://localhost:7071/somefolder"), ctx.BaseUrl);
        }

        // 
    }
}
