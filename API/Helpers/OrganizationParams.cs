namespace API.Helpers
{
  public class OrganizationParams : PaginationParams
    {
        public string CurrentName { get; set; }
        public string OrderBy { get; set; } = "lastUpdated";
        public string City { get; set; }
        public string ProvinceOrState { get; set; }
        public string Country { get; set; }
    }
}