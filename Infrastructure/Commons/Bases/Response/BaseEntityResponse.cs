namespace Infrastructure.Commons.Bases.Responses
{
    public class BaseEntityResponse<T>
    {
        public int TotalRecords { get; set; }
        public List<T>? Items { get; set; }
    }
}
