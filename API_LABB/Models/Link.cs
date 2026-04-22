namespace API_LABB.Models;

public class Link
{
    public int Id { get; set; }
    public string Url { get; set; } = string.Empty;
    public string Label { get; set; } = string.Empty;

    public int PersonId { get; set; }
    public Person Person { get; set; } = null!;

    public int InterestId { get; set; }
    public Interest PersonName { get; set; } = null!;
}