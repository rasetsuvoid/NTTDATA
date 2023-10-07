using Application.Common.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    public class ProvisionController : BaseController
    {

        private readonly IProvisionService _provisionService;

        public ProvisionController(IProvisionService provisionService)
        {
            _provisionService = provisionService;
        }
    }
}
