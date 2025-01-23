using AutoMapper;
using FinalExam.BL.DTOs;
using FinalExam.BL.Exceptions;
using FinalExam.BL.Services.Abstractions;
using FinalExam.Core.Models;
using FinalExam.DL.Repository.Abstractions;

namespace FinalExam.BL.Services.Concretes;

public class ProfessionService : IProfessionService
{

    readonly IRepository<Profession> _repository;
    readonly IMapper _mapper;

    public ProfessionService(IRepository<Profession> repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ICollection<ProfessionListItemDTO>> GetListItemsAsync(int count = 0) => _mapper.Map<ICollection<ProfessionListItemDTO>>(await _repository.GetAllAsync(count, false));

    public async Task<Profession> GetByIdAsync(int id) => await _repository.GetByIdAsync(id) ?? throw new BaseException();

    public async Task<Profession> GetByIdWithChildrenAsync(int id) => await _repository.GetByIdAsync(id, includes: "Customers") ?? throw new BaseException();

    public async Task<ProfessionUpdateDTO> GetByIdForUpdateAsync(int id) => _mapper.Map<ProfessionUpdateDTO>(await GetByIdAsync(id));

    public async Task CreateAsync(ProfessionCreateDTO dto)
    {
        Profession profession = _mapper.Map<Profession>(dto);

        await _repository.CreateAsync(profession);
    }

    public async Task UpdateAsync(ProfessionUpdateDTO dto)
    {
        Profession oldProfession = await GetByIdAsync(dto.Id);
        Profession profession = _mapper.Map<Profession>(dto);
        profession.CreatedAt = oldProfession.CreatedAt;

        _repository.Update(profession);
    }

    public async Task DeleteAsync(int id)
    {
        Profession profession = await GetByIdWithChildrenAsync(id);

        if (profession.Customers.Count > 0) throw new BaseException("This profession has customers!");

        _repository.Delete(profession);
    }

    public async Task<int> SaveChangesAsync() => await _repository.SaveChangesAsync();
}
