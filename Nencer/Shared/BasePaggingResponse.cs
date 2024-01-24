namespace Nencer.Shared
{
    public class BasePaggingResponse<T>
    {
        public long TotalItems {  get; set; }
        public T Data { get; set; }
    }
}
