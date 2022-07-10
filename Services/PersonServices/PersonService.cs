using Domains;
using Domains.Enums;
using Dto.Person;
using EntityFramework;
using Infrastructure.Exceptions;
using Microsoft.EntityFrameworkCore;
using ServicesInterfaces;

namespace Services.PersonServices;

public class PersonService: IPersonService
{
    private readonly ApplicationDbContext _applicationDbContext;
    private readonly IFileService _fileService;

    public PersonService(ApplicationDbContext applicationDbContext, IFileService fileService)
    {
        _applicationDbContext = applicationDbContext;
        _fileService = fileService;
    }
    
    public async Task<PersonDtoResponse> CreatePerson(int userId, PersonDtoRequest request,
        CancellationToken cancellationToken)
    {
        var newPerson = new Person
        {
            BirthDate = request.BirthDate,
            FirstName = request.FirstName,
            LastName = request.LastName,
            MiddleName = request.MiddleName,
        };

        if (request.IsMale.HasValue)
        {
            newPerson.Gender = request.IsMale.Value ? Gender.Male : Gender.Female;
        }

        if (request.Avatar != null)
        {
            var file = await _fileService.SaveFile(request.Avatar, userId, cancellationToken);
            newPerson.AvatarId = file.Id;
        }

        await _applicationDbContext.Persons.AddAsync(newPerson, cancellationToken);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return newPerson.MapToDto();
    }

    public async Task<PersonDtoResponse> UpdatePerson(int userId,int personId, PersonDtoRequest request, CancellationToken cancellationToken)
    {
        var person = await GetUsersPersonOrThrow(userId, personId, cancellationToken);
        if (request.IsMale.HasValue)
        {
            person.Gender = request.IsMale.Value ? Gender.Male : Gender.Female;
        }
        else
        {
            person.Gender = null;
        }

        if (request.BirthDate.HasValue)
        {
            person.BirthDate = request.BirthDate.Value;
        }
        else
        {
            person.BirthDate = null;
        }

        person.FirstName = request.FirstName;
        person.LastName = request.LastName;
        person.MiddleName = request.MiddleName;

        if (request.Avatar != null)
        {
            if (person.Avatar != null)
            {
                await _fileService.DropFile(person.Avatar, userId, cancellationToken);
            }

            var file = await _fileService.SaveFile(request.Avatar, userId, cancellationToken);
            person.AvatarId = file.Id;
        }

        await _applicationDbContext.SaveChangesAsync(cancellationToken);
        return person.MapToDto();
    }

    public async Task DeletePerson(int userId, int personId, CancellationToken cancellationToken)
    {
        var person = await GetUsersPersonOrThrow(userId, personId, cancellationToken);
        _applicationDbContext.Persons.Remove(person);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<Person> GetUsersPersonOrThrow(int userId, int personId, CancellationToken cancellationToken)
    {
        var person = await _applicationDbContext.Persons.Where(x => x.UserId == userId && x.Id == personId)
            .FirstOrDefaultAsync(cancellationToken);
        if (person == null)
        {
            throw new MyFamilyTreeNotFoundException($"User with id {personId} not found");
        }

        return person;
    }

    public async Task<PersonDtoResponse[]> GetAllPersons(int userId, int skip, int take, CancellationToken cancellationToken)
    {
        return (await _applicationDbContext.Persons.Include(x => x.Avatar)
                .Where(x => x.UserId == userId).ToArrayAsync(cancellationToken))
            .Select(x => x.MapToDto()).ToArray();
    }
}