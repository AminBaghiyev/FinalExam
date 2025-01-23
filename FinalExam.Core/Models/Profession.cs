using FinalExam.Core.Models.Base;

namespace FinalExam.Core.Models;

public class Profession : BaseEntity
{
    public string Title { get; set; }
    public ICollection<Customer> Customers { get; set; }
}
