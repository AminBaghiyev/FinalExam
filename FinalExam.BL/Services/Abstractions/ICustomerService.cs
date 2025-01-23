using FinalExam.BL.DTOs;
using FinalExam.Core.Models;

namespace FinalExam.BL.Services.Abstractions;

public interface ICustomerService
{
    Task<ICollection<CustomerListItemDTO>> GetListItemsAsync(int count = 0);
    Task<ICollection<CustomerViewItemDTO>> GetViewItemsAsync(int count = 3);
    Task<CustomerUpdateDTO> GetByIdForUpdateAsync(int id);
    Task<Customer> GetByIdAsync(int id);
    Task CreateAsync(CustomerCreateDTO dto);
    Task UpdateAsync(CustomerUpdateDTO dto);
    Task DeleteAsync(int id);
    Task<int> SaveChangesAsync();
}
