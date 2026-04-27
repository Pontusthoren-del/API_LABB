namespace API_LABB.Models;

public class Link
{
    public int Id { get; set; }
    public string Url { get; set; } = string.Empty;
    public string Label { get; set; } = string.Empty;

    public int UserId { get; set; }
    public User User { get; set; } = null!;

    public int InterestId { get; set; }
    public Interest Interest{ get; set; } = null!;
}