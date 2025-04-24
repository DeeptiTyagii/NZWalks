using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NZWalks.API.Controllers
{
    //api/Walks
    [Route("api/[controller]")] 
    [ApiController]  //tells the app that this is api controller not mvc controller
    public class WalksController : ControllerBase
    {
    }
}
