using Dto;
using Dto.FamilyTree;

namespace ServicesInterfaces;

public interface ITreeService
{
     Task<FamilyTreeDtoResponse> CreateTree(int userId, FamilyTreeDtoRequest request, CancellationToken cancellationToken);
     Task<FamilyTreeDtoResponse[]> GetTrees(int userId, CancellationToken cancellationToken);
}