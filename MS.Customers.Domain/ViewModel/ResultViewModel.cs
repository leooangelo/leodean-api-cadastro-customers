using Newtonsoft.Json;

namespace MS.Customer.Domain.ViewModels
{
    public class ResultViewModel
    {
        public ResultViewModel(string message, dynamic data, bool success = true)
        {
            Message = message;
            Success = success;
            Data = data;
        }

        public ResultViewModel(string message, bool success = true)
        {
            Message = message;
            Success = success;
        }

        public ResultViewModel() { }

        public string Message { get; set; }
        public bool Success { get; set; }
        public dynamic Data { get; set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
