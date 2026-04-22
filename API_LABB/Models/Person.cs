namespace API_LABB.Models;


public class Person
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;

    public ICollection<PersonInterest> PersonInterests { get; set; } = new List<PersonInterest>();
    public ICollection<Link> Links { get; set; } = new List<Link>();
}