namespace API.Models
{
    public class ServiceResponse<T>
    {
        public T? Data { get; set; }
        public bool Error { get; set; } = false;
        public string? Message { get; set; }
    }
}
