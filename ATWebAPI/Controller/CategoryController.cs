using Microsoft.AspNetCore.Mvc;

namespace ATWebAPI.Controller
{
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ILogger<LoginController> _logger; 
        public CategoryController(ILogger<LoginController> logger)
        {
            _logger = logger;   
        }
        
    }
}
