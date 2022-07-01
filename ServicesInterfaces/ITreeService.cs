using Dto;
using Dto.FamilyTree;

namespace ServicesInterfaces;

public interface ITreeService
{
     Task<FamilyTreeDtoResponse> CreateTree(FamilyTreeDtoRequest request, CancellationToken token);
     Task<FamilyTreeDtoResponse[]> GetTrees(int userId, CancellationToken cancellationToken);
}