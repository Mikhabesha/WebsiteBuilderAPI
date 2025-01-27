//using NPOI.SS.Formula.Functions;

namespace WebsiteBuilderAPI.DTOs
{
    public class UserDto
    {
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public object? Id { get; internal set; }
    }
    public class ServiceResult<T>
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }
    }
}
