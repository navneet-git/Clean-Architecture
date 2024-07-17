namespace Application.Common
{
    public class Response<T> : IDisposable
    {
        public bool IsSuccess { get; set; } = true;
        public string Error { get; set; } = string.Empty;
        public T Data { get; set; }
        public IEnumerable<T> ListData { get; set; }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
