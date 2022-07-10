using Domains;
using Dto.Person;
using Infrastructure.Exceptions;

namespace ServicesInterfaces;

public interface IPersonService
{
    Task<PersonDtoResponse> CreatePerson(int userId, PersonDtoRequest request, CancellationToken cancellationToken);
    Task<PersonDtoResponse> UpdatePerson(int userId, int personId, PersonDtoRequest request, CancellationToken cancellationToken);
    Task DeletePerson(int userId, int personId, CancellationToken cancellationToken);
    /// <summary>
    /// Returns a user's person or throw the exception.
    /// </summary>
    /// <param name="userId"></param>
    /// <param name="personId"></param>
    /// <param name="cancellationToken"></param>
    /// <exception cref="MyFamilyTreeNotFoundException"></exception>
    /// <returns></returns>
    Task<Person> GetUsersPersonOrThrow(int userId, int personId, CancellationToken cancellationToken);

    Task<PersonDtoResponse[]> GetAllPersons(int userId, int skip, int take, CancellationToken cancellationToken);
}