namespace API.Helpers
{
  public class OrganizationParams : PaginationParams
    {
        public string CurrentName { get; set; }
        public string OrderBy { get; set; } = "lastUpdated";
    }
}