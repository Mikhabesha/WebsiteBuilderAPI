namespace WebsiteBuilderAPI.Models
{
    public class Website
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Domain { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }

}
