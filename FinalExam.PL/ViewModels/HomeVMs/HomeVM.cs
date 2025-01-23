using FinalExam.BL.DTOs;

namespace FinalExam.PL.ViewModels;

public class HomeVM
{
    public ICollection<CustomerViewItemDTO> Customers { get; set; }
}
