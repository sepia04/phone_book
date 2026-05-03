using Ardalis.Result;
using Contracts.Phone.Responses;
using Domain.Entities;
using Domain.Repositories;
using Mapster;
using Services.Abstracts;

namespace Services;

internal sealed class PhoneService(IRepositoryManager repositoryManager) : IPhoneService
{
    public Result<IEnumerable<PhoneDto>> GetPhones()
    {
        var phones = repositoryManager.PhoneRepository.GetAllPhones();

        var phonesDto = phones.Adapt<Result<IEnumerable<PhoneDto>>>();

        return phonesDto;
    }

    public Result<PhoneDto> GetPhone(int id)
    {
        var phone = repositoryManager.PhoneRepository.GetById(id);

        if (phone is null) return Result.NotFound("Phone is not found");

        var phoneDto = phone.Adapt<PhoneDto>();
        
        return phoneDto;
    }

    public Result<PhoneDto> Create(string phoneNumber, int userId)
    {
        var validationErrors = new List<ValidationError>();

        if (string.IsNullOrEmpty(phoneNumber))
        {
            validationErrors.Add(new ValidationError("Phone Number is Empty"));
        }

        if (userId <= 0)
        {
            validationErrors.Add(new ValidationError("Bad User Id"));
        }

        if (validationErrors.Count > 0)
        {
            return Result.Invalid(validationErrors);
        }

        var newPhone = new Phone
        {
            PhoneNumber = phoneNumber,
            UserId = userId
        };

        repositoryManager.PhoneRepository.Create(newPhone);

        var newPhoneDto = newPhone.Adapt<PhoneDto>();

        return Result.Created(newPhoneDto);
    }

    public Result<PhoneDto> Update(int id, string phoneNumber, int userId)
    {
        var validationErrors = new List<ValidationError>();

        if (string.IsNullOrEmpty(phoneNumber))
        {
            validationErrors.Add(new ValidationError("Phone Number is Empty"));
        }

        if (userId <= 0)
        {
            validationErrors.Add(new ValidationError("Bad User Id"));
        }

        if (validationErrors.Count > 0)
        {
            return Result.Invalid(validationErrors);
        }

        var phone = repositoryManager.PhoneRepository.GetById(id);

        if (phone is null) return Result.NotFound("Phone is not found");

        phone.PhoneNumber = phoneNumber;
        phone.UserId = userId;

        repositoryManager.PhoneRepository.Update(phone);

        var phoneDto = phone.Adapt<PhoneDto>();

        return phoneDto;
    }

    public Result Delete(int id)
    {
        var phone = repositoryManager.PhoneRepository.GetById(id);

        if (phone is null) return Result.NotFound("Phone is not found");

        if (phone.UserId is not null) return Result.Conflict("Can't delete phone number. User has this phone number.");

        repositoryManager.PhoneRepository.Delete(phone);

        return Result.Success();
    }
}