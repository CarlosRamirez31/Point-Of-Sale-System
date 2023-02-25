namespace Infrastructure.Commons.Bases.Requests
{
    public class BaseFiltersRequest : BasePaginationRequest
    {
        public int? NumFilter { get; set; } = null;
        public string? TextFilter { get; set; } = null;
        public int? StateFilter { get; set; } = null;
        public string? StarDate { get; set; } = null;
        public string? EndDate { get; set; } = null;
        public bool? Download { get; set; } = null;
    }
}
