namespace API.Entities
{
    public class OrgLike
    {
        public Organization Org { get; set; }
        public int OrgId { get; set; }
        public AppUser LikedUser { get; set; }
        public int LikedUserId { get; set; }
    }
}