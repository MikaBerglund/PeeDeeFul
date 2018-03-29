using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PeeDeeFul.DocumentModel;

namespace PeeDeeFul.DocumentModel.Tests
{
    [TestClass]
    public class ImageTests
    {
        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            var dir = new FileInfo(Assembly.GetExecutingAssembly().ManifestModule.FullyQualifiedName).Directory;
            var path = Path.Combine(dir.FullName, "BasketBall01.jpg");
            if (File.Exists(path))
            {
                File.Delete(path);
            }

            Properties.Resources.BasketBall01.Save(path);
            BaseketBall01Path = new FileInfo(path);
        }

        private static FileInfo BaseketBall01Path;

        [TestMethod]
        public void ProcessImages01()
        {
            var img = new Image()
            {
                SourceUrl = new Uri("https://cdn.pixabay.com/photo/2017/03/08/21/20/pdf-2127829_960_720.png")
            };
            Assert.IsNull(img.SourceFile);
            Assert.IsNotNull(img.SourceUrl);

            Task.WaitAll(img.PrepareSourcesAsync());

            Assert.IsNotNull(img.Base64Data);
        }

        [TestMethod]
        public void ProcessImages02()
        {
            var img = new Image()
            {
                SourceFile = BaseketBall01Path
            };
            Assert.IsNull(img.SourceUrl);
            Assert.IsNotNull(img.SourceFile);
            Assert.IsNotNull(img.Name);
            Assert.IsNull(img.Base64Data);

            Task.WaitAll(img.PrepareSourcesAsync());

            Assert.IsNotNull(img.Base64Data);
            Assert.IsNotNull(img.Name);
        }

        [TestMethod]
        public void ProcessImages03()
        {
            var doc = new Document();
            var img = doc
                .AddSection()
                .AddImage(BaseketBall01Path);

            Task.WaitAll(img.PrepareSourcesAsync());

            Tools.ParseDdl(doc);
        }

    }
}
