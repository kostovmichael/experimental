namespace MvcAndWebApiDotNetFive.Controllers.WebApiControllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    using Models;

    using PatternsAndConcepts.DummyModels;
    using PatternsAndConcepts.Services;

    using System.Collections.Generic;
    using System.Net.Mime;
    using System.Threading.Tasks;

    [ApiController]
    public class BenchmarkJsonController : Controller
    {
        private readonly ILogger<BenchmarkJsonController> _logger;
        const string contentTypeJson = "application/json; charset=utf-8";


        //This type of "caching implementation" is for test purposes only and it is not intended for production use
        private static List<ProductStructLayoutSequential> listOfProductStructs;


        public BenchmarkJsonController(ILogger<BenchmarkJsonController> logger)
        {
            _logger = logger;
            //DO NOT use this kind of "caching" in prod environment
            GetSetCahedDataForTesting();
        }
        [Route("api/BenchmarkJson/VerifyCacheSet"), Produces(MediaTypeNames.Application.Json)]
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
            string theJsonSerializedData = System.Text.Json.JsonSerializer.Serialize(responseModel);

            var content = new ContentResult();
            content.ContentType = contentTypeJson;
            content.Content = theJsonSerializedData;

            return content;
        }

        [Route("api/BenchmarkJson/NewtonSoftJsonMidSizeStructArraySerialization"), Produces(MediaTypeNames.Application.Json)]
        public ActionResult NewtonSoftJsonMidSizeStructArraySerialization()
        {
            List<ProductStructLayoutSequential> data = GetSetCahedDataForTesting();

            string theJsonSerializedData = Newtonsoft.Json.JsonConvert.SerializeObject(data);

            var content = new ContentResult();
            content.ContentType = contentTypeJson;
            content.Content = theJsonSerializedData;

            return content;
        }

        [Route("api/BenchmarkJson/TextJsonMidSizeStructArraySerialization"), Produces(MediaTypeNames.Application.Json)]
        public ActionResult TextJsonMidSizeStructArraySerialization()
        {
            List<ProductStructLayoutSequential> data = GetSetCahedDataForTesting();

            string theJsonSerializedData = System.Text.Json.JsonSerializer.Serialize(data);

            var content = new ContentResult();
            content.ContentType = contentTypeJson;
            content.Content = theJsonSerializedData;

            return content;
        }

        private List<ProductStructLayoutSequential> GetSetCahedDataForTesting()
        {
            if (listOfProductStructs == null)
            {
                listOfProductStructs = TestDataGenerator.Generate_Medium_List_Of_Product_Structs();

            }
            return listOfProductStructs;
        }

    }
}
