namespace MvcAndWebApiDotNetFive.Models
{
    public class ResponseModel
    {
        public ResponseModel()
        {

        }

        public ResponseModel(bool success, string message = null)
        {
            this.Success = success;
            this.Message = message;
        }
        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
