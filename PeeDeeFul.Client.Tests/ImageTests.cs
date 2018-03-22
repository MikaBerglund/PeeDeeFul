using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PeeDeeFul.DocumentModel;

namespace PeeDeeFul.Client.Tests
{
    [TestClass]
    public class ImageTests
    {
        [TestMethod]
        public void ProcessImages01()
        {
            var img = new Image()
            {
                SourceUrl = new Uri("https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQvCmnMYA3WsODPzkn06fVBO_oDRLQUeZiglEl0WO6Kd3ekKBSe")
            };
            Assert.IsNull(img.SourceFile);
            Assert.IsNotNull(img.SourceUrl);

            Task.WaitAll(img.PrepareSourcesAsync());

            Assert.IsNotNull(img.Base64Data);
        }
    }
}
