using FinalExam.BL.DTOs;
using FinalExam.Core.Models;

namespace FinalExam.BL.Services.Abstractions;

public interface IProfessionService
{
    Task<ICollection<ProfessionListItemDTO>> GetListItemsAsync(int count = 0);
    Task<ProfessionUpdateDTO> GetByIdForUpdateAsync(int id);
    Task<Profession> GetByIdAsync(int id);
    Task<Profession> GetByIdWithChildrenAsync(int id);
    Task CreateAsync(ProfessionCreateDTO dto);
    Task UpdateAsync(ProfessionUpdateDTO dto);
    Task DeleteAsync(int id);
    Task<int> SaveChangesAsync();
}
