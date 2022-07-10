using Dto.Family;

namespace ServicesInterfaces;

public interface IFamilyService
{
    Task<CreateFamilyDtoResponse> CreateFamily(int familyTreeId, CreateFamilyDtoRequest request, CancellationToken cancellationToken);

}