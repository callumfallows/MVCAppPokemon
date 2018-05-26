
namespace PokeMart.Web.ApiTypes
{
    public class ApiResponse<T>
    {
        public static ApiResponse<T> Success(T payload)
        {
            return new ApiResponse<T>(payload);
        }
        public static ApiResponse<T> Fail(string message)
        {
            return new ApiResponse<T>(new Error(message));
        }
        private ApiResponse(T payload)
        {
            Payload = payload;
        }
        private ApiResponse(Error error)
        {
            Error = error;
        }
        public T Payload { get; }
        public Error Error { get; }
    }
}