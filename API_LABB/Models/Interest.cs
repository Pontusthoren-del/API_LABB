namespace API_LABB.Models;

public class Interest
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public ICollection<PersonInterest> PersonInterests { get; set; } = new List<PersonInterest>();
    public ICollection<Link> Links { get; set; } = new List<Link>();
}