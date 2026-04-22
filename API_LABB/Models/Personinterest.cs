namespace API_LABB.Models;

public class PersonInterest
{
    public int PersonId { get; set; }
    public Person Person { get; set; } = null!;

    public int InterestId { get; set; }
    public Interest Interest { get; set; } = null!;
}