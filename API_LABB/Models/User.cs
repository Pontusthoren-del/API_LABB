namespace API_LABB.Models;


public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;

    public ICollection<UserInterest> PersonInterests { get; set; } = new List<UserInterest>();
    public ICollection<Link> Links { get; set; } = new List<Link>();
}