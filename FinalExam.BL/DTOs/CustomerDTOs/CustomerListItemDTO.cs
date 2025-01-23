namespace FinalExam.BL.DTOs;

public record CustomerListItemDTO
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string ProfessionTitle { get; set; }
}
