using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureTemplate.Api.Controllers;

// [Authorize] // Uncomment if you want to secure the API with authentication
[Route("api/v1/[controller]")]
[ApiController]
public class BaseApiController : ControllerBase
{
}