namespace API_LABB.Models;

public class Interest
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public ICollection<UserInterest> PersonInterests { get; set; } = new List<UserInterest>();
    public ICollection<Link> Links { get; set; } = new List<Link>();
}