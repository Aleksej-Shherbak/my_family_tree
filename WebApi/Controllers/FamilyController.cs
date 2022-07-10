using Dto.Family;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServicesInterfaces;

namespace WebApi.Controllers;

[Authorize]
[Route("api/families")]
[ApiController]
public class FamilyController: BaseController
{
    private readonly IFamilyService _familyService;

    public FamilyController(IFamilyService familyService)
    {
        _familyService = familyService;
    }
    
    [HttpPost("[action]/{familyTreeId}")]
    public async Task<CreateFamilyDtoResponse> Create(CreateFamilyDtoRequest request, int familyTreeId, CancellationToken cancellationToken)
    {
        return await _familyService.CreateFamily(familyTreeId, request, cancellationToken);
    }
}