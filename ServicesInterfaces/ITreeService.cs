using Dto;

namespace ServicesInterfaces;

public interface ITreeService
{
     Task<FamilyTreeDto> CreateTree(FamilyTreeDto request, CancellationToken token);
}