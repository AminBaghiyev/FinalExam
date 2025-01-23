using FinalExam.Core.Models.Base;

namespace FinalExam.Core.Models;

public class Customer : BaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string ProfilePhotoPath { get; set; }
    public string Comment { get; set; }
    public int ProfessionId { get; set; }
    public Profession Profession { get; set; }
}
