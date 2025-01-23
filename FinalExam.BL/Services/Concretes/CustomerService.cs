using AutoMapper;
using FinalExam.BL.DTOs;
using FinalExam.BL.Exceptions;
using FinalExam.BL.Services.Abstractions;
using FinalExam.BL.Utilities;
using FinalExam.Core.Models;
using FinalExam.DL.Repository.Abstractions;

namespace FinalExam.BL.Services.Concretes;

public class CustomerService : ICustomerService
{

    readonly IRepository<Customer> _repository;
    readonly IRepository<Profession> _professionRepository;
    readonly IMapper _mapper;

    public CustomerService(IRepository<Customer> repository, IRepository<Profession> professionRepository, IMapper mapper)
    {
        _repository = repository;
        _professionRepository = professionRepository;
        _mapper = mapper;
    }

    public async Task<ICollection<CustomerListItemDTO>> GetListItemsAsync(int count = 0) => _mapper.Map<ICollection<CustomerListItemDTO>>(await _repository.GetAllAsync(count, false, includes: "Profession"));

    public async Task<ICollection<CustomerViewItemDTO>> GetViewItemsAsync(int count = 3) => _mapper.Map<ICollection<CustomerViewItemDTO>>(await _repository.GetAllAsync(count, false, includes: "Profession"));

    public async Task<Customer> GetByIdAsync(int id) => await _repository.GetByIdAsync(id, includes: "Profession") ?? throw new BaseException();

    public async Task<CustomerUpdateDTO> GetByIdForUpdateAsync(int id) => _mapper.Map<CustomerUpdateDTO>(await GetByIdAsync(id));

    public async Task CreateAsync(CustomerCreateDTO dto)
    {
        if (await _professionRepository.GetByIdAsync(dto.ProfessionId) is null) throw new BaseException("There is no such a profession");

        Customer customer = _mapper.Map<Customer>(dto);
        customer.ProfilePhotoPath = await dto.ProfilePhoto.SaveAsync("customers");

        await _repository.CreateAsync(customer);
    }

    public async Task UpdateAsync(CustomerUpdateDTO dto)
    {
        if (await _professionRepository.GetByIdAsync(dto.ProfessionId) is null) throw new BaseException("There is no such a profession");

        Customer oldCustomer = await GetByIdAsync(dto.Id);
        Customer customer = _mapper.Map<Customer>(dto);
        customer.CreatedAt = oldCustomer.CreatedAt;
        customer.ProfilePhotoPath = dto.ProfilePhoto is not null ? await dto.ProfilePhoto.SaveAsync("customers") : oldCustomer.ProfilePhotoPath;

        _repository.Update(customer);

        if (dto.ProfilePhoto is not null) File.Delete(Path.Combine(Path.GetFullPath("wwwroot"), "uploads", "customers", oldCustomer.ProfilePhotoPath));
    }

    public async Task DeleteAsync(int id)
    {
        Customer customer = await GetByIdAsync(id);

        _repository.Delete(customer);

        File.Delete(Path.Combine(Path.GetFullPath("wwwroot"), "uploads", "customers", customer.ProfilePhotoPath));
    }

    public async Task<int> SaveChangesAsync() => await _repository.SaveChangesAsync();
}
