using AutoMapper;
using Domain.EntitiesDTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.IService;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Controllers
{
    [Route("api/wallets")]
    [ApiController]
    public class WalletController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IServiceWrapper _serviceWrapper;

        public WalletController(IServiceWrapper serviceWrapper, IMapper mapper)
        {
            _serviceWrapper = serviceWrapper;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize]
        [SwaggerOperation(Summary = "[Authorize] Get All Wallet Type")]
        public async Task<IActionResult> GetAllWalletTypes()
        {
            var walletTypes = _serviceWrapper.Wallets.GetAllWalletType().ToList();
            if (walletTypes != null && walletTypes.Count() > 0)
            {
                var result = _mapper.Map<List<WalletTypeDTO>>(walletTypes);
                return Ok(result);
            }
            return NotFound("There's no wallet type!");
        }

    }
}
