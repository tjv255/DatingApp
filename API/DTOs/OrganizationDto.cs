namespace API.DTOs
{
    public class OrganizationDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Introduction { get; set; }
        public string PhotoUrl { get; set; }
        public int Established { get; set; }
        public DateTime Created { get; set; } 
        public DateTime LastUpdated { get; set; }
        public ICollection<OrgPhotoDto> Photos { get; set; }
        public ICollection<OrgMemberDto> Members { get; set; }
    }
}