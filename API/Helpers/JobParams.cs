namespace API.Helpers
{
    public class JobParams : PaginationParams
    {
        public string OrderBy { get; set; } = "mostRecent";
        public string Genres { get; set; }
        public string SkillsRequired { get; set; }
        public string City { get; set; }
        public string ProvinceOrState { get; set; }
        public string Country { get; set; }
    }
}