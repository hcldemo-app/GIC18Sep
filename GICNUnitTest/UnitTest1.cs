using GICMicro.Controllers;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;


namespace Tests
{
    public class Tests
    {
        //[SetUp]
        //public void Setup()
        //{
        //}

       

        [Test]
        public void TestGetProducts()
        {
            ProductsController obj = new ProductsController();

            ViewResult actResult = obj.GetProducts() as ViewResult;

            Assert.That(actResult.ViewName, Is.EqualTo("GetProducts"));
        }

        [Test]
        public void TestGetLastProduct()
        {
            ProductsController obj = new ProductsController();

            ViewResult actResult = obj.GetLastProduct() as ViewResult;

            Assert.That(actResult.ViewName, Is.EqualTo("GetLastProduct"));
        }

    }
}