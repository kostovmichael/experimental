namespace MvcAndWebApiDotNetFive.Controllers.WebApiControllers
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;

    using Models;

    using PatternsAndConcepts.DummyModels;
    using PatternsAndConcepts.Services;

    using System.Collections.Generic;
    using System.IO;
    using System.Net;
    using System.Net.Mime;
    using System.Text;
    using System.Threading.Tasks;
    using System.Xml.Linq;
    using System.Xml.Serialization;

    [ApiController]
    public class BenchmarkXmlController : Controller
    {
        private readonly ILogger<BenchmarkXmlController> _logger;
        const string contentTypeJson = "application/json; charset=utf-8";


        //This type of "caching implementation" is for test purposes only and it is not intended for production use
        private static List<ProductStructLayoutSequential> listOfProductStructs;


        public BenchmarkXmlController(ILogger<BenchmarkXmlController> logger)
        {
            _logger = logger;
            //DO NOT use this kind of "caching" in prod environment
            GetSetCahedDataForTesting();
        }
        [Route("api/BenchmarkXml/VerifyCacheSet"), Produces(MediaTypeNames.Application.Json)]
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


        [Route("api/BenchmarkXml/PostRandomXml"), Produces(MediaTypeNames.Application.Xml)]
        public async Task<IActionResult> PostRandomXml()
        {
            string theContent = string.Empty;

            //var test = HttpContext.Request.Body;
            using (StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8))
            {
                theContent = await reader.ReadToEndAsync();
            }
            XmlSerializer serializer = new XmlSerializer(typeof(XElement));



            //XmlSerializer serializer = new XmlSerializer();
            var myRootElement = XElement.Parse(theContent);
            XDocument doc = XDocument.Parse(theContent);


            var theResponseData = GetXElementsTestResponse();

            var content = new ContentResult();
            content.ContentType = "text/xml; charset=utf-8";
            content.Content = theResponseData.ToString();
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


        private XElement GetXElementsTestResponse()
        {

            const string testXmlData =
                "<s:Envelope xmlns:s=\"http://schemas.xmlsoap.org/soap/envelope/\"><s:Body></s:Body></s:Envelope>";
            return XElement.Parse(testXmlData);
        }
    }
}
