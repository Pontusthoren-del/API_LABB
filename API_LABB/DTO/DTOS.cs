namespace API_LABB.DTOs;

public record PersonDto(int Id, string Name, string Phone);

public record InterestDto(int Id, string Title, string Description);

public record LinkDto(int Id, string Url, string Label, int InterestId, string InterestTitle, string PersonName);

public record AddInterestToPersonDto(int InterestId);

public record AddLinkDto(string Url, string Label, int InterestId);