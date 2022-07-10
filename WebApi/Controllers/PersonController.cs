using Dto.Person;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServicesInterfaces;

namespace WebApi.Controllers;
// For all those people who think that return task directly instead of awaiting it is a smart decision 
// https://www.youtube.com/watch?v=Q2zDatDVnO0&ab_channel=NickChapsas

[Authorize]
[Route("api/persons")]
[ApiController]
public class PersonController: BaseController
{
    private readonly IPersonService _personService;

    public PersonController(IPersonService personService)
    {
        _personService = personService;
    }
    
    [HttpGet]
    public async Task<PersonDtoResponse[]> Index([FromQuery]int skip, CancellationToken cancellationToken, [FromQuery]int take)
    {
        return await _personService.GetAllPersons(UserId, skip, take, cancellationToken);
    }
    
    [HttpPost]
    public async Task<PersonDtoResponse> Create(PersonDtoRequest request, CancellationToken cancellationToken)
    {
        return await _personService.CreatePerson(UserId, request, cancellationToken);
    }
    
    [HttpPut("[action]/{personId}")]
    public async Task<PersonDtoResponse> Update(PersonDtoRequest request, int personId, CancellationToken cancellationToken)
    {
        return await _personService.UpdatePerson(UserId, personId, request, cancellationToken);
    }
    
    [HttpDelete("[action]/{personId}")]
    public async Task<IActionResult> Delete(int personId, CancellationToken cancellationToken)
    {
        await _personService.DeletePerson(UserId, personId, cancellationToken);
        return Ok();
    }
}