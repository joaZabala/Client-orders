using System.Net;

namespace SegundoFinal.Response
{
    public class ApiResponse<T>
    {
        public T Data { get; set; }

        public string ErrorMessage { get; set; }

        public HttpStatusCode StatusCode { get; set; }

        public bool Success { get; set; }

        public ApiResponse()
        {
            Success = true;
            ErrorMessage = string.Empty;
            StatusCode = HttpStatusCode.OK;
        }

        public void SetError(string error, HttpStatusCode httpStatusCode)
        {
            Success = false;
            StatusCode = httpStatusCode;
            ErrorMessage = error;
        }
    }
}
