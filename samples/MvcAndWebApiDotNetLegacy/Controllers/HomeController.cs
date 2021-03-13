using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcAndWebApiDotNetLegacy.Controllers
{
    using Models;

    using PatternsAndConcepts.DummyModels;
    using PatternsAndConcepts.Services;

    public class HomeController : Controller
    {
        const string contentTypeJson = "application/json; charset=utf-8";

        //This type of "caching implementation" is for test purposes only and it is not intended for production use
        private static List<ProductStructLayoutSequential> listOfProductStructs;
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Test()
        {

            List<ProductStructLayoutSequential> data = GetSetCahedDataForTesting();

            string theJsonSerializedData = Newtonsoft.Json.JsonConvert.SerializeObject(data);

            var content = new ContentResult();
            content.ContentType = contentTypeJson;
            content.Content = theJsonSerializedData;

            return content;
        }


        public ActionResult VerifyCacheSet()
        {
            var responseModel = new ResponseModel();
            List<ProductStructLayoutSequential> data = GetSetCahedDataForTesting();
            if (data != null)
            {
                responseModel.Success = true;
                responseModel.Message =
                    $"Cached List<ProductStructLayoutSequential> with count: {data.Count.ToString()}";
            }
            string theJsonSerializedData = Newtonsoft.Json.JsonConvert.SerializeObject(responseModel);

            var content = new ContentResult();
            content.ContentType = contentTypeJson;
            content.Content = theJsonSerializedData;

            return content;
        }

        private List<ProductStructLayoutSequential> GetSetCahedDataForTesting()
        {
            if (listOfProductStructs == null)
            {
                string filePath = Server.MapPath("/App_Data");
                listOfProductStructs = TestDataGenerator.Generate_Medium_List_Of_Product_Structs(filePath);

            }
            return listOfProductStructs;
        }
    }
}