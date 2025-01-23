namespace FinalExam.BL.DTOs;

public record CustomerViewItemDTO
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName => FirstName + " " + LastName;
    public string ProfilePhotoPath { get; set; }
    public string Comment { get; set; }
    public string ProfessionTitle { get; set; }
}
