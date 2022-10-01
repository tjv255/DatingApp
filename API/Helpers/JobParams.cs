namespace API.Helpers
{
    public class JobParams : PaginationParams
    {
        public string OrderBy { get; set; } = "lastUpdated";
        public string CurrentName { get; set; }
        public string Genres { get; set; }
        public string SkillsRequired { get; set; }
        public string City { get; set; }
        public string ProvinceOrState { get; set; }
        public string Country { get; set; }
    }
}