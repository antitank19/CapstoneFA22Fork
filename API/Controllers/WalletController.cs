using AutoMapper;
using Domain;
using Domain.EntitiesDTO;
using Domain.EntitiesForManagement;
using Infrastructure.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
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
        [Route("api/wallets")]
        [SwaggerOperation(Summary = "[Authorize] Get Wallet By account")]
        public async Task<IActionResult> GetWalletByAccountID()
        {
            string accountID = User.Identity.Name;
            if (accountID.IsNullOrEmpty() || accountID == "0")
            {
                return BadRequest("The account is not available in our system!");
            }
            var wallets = _serviceWrapper.Wallets.GetWalletsByAccountID(int.Parse(accountID)).ToList();
            if (wallets == null || wallets.Count == 0)
            {
                return NotFound("This user does not have any wallet yet!");
            }
            var respond = _mapper.Map<List<WalletDTO>>(wallets);
            return Ok(respond);
        }

        [HttpPost]
        [Authorize]
        [Route("api/wallets")]
        [SwaggerOperation(Summary = "[Authorize] Create a Wallet")]
        public async Task<IActionResult> CreateWallet(WalletCreateRequest request)
        {
            string accountID = User.Identity.Name;

            if (accountID.IsNullOrEmpty() || accountID == "0")
            {
                return BadRequest("The account is not available in our system!");
            }

            Wallet newWallet = new Wallet()
            {
                WalletId = Guid.NewGuid(),
                AccountId = int.Parse(accountID),
                Balance = 0,
                CreatedDate = DateTime.Now,
                Status = 1,
                WalletTypeId = (int)request.WalletType
            };

            var result = await _serviceWrapper.Wallets.CreateWallet(newWallet);
            if (result == null)
            {
                return BadRequest();
            }
            var respond = _mapper.Map<WalletDTO>(result);
            return StatusCode(201, result);
        }


        [HttpPut]
        [Authorize]
        [Route("api/wallets")]
        [SwaggerOperation(Summary = "[Authorize] Udpate a Wallet")]
        public async Task<IActionResult> UpdateWallet(WalletUpdateRequest request)
        {
            string accountID = User.Identity.Name;

            if (accountID.IsNullOrEmpty() || accountID == "0")
            {
                return BadRequest("The account is not available in our system!");
            }
            Wallet wallet = new Wallet()
            {
                WalletId = request.WalletId,
                Balance = request.Balance,
            };

            var result = await _serviceWrapper.Wallets.UpdateWallet(wallet);
            if (result == null)
            {
                return BadRequest();
            }
            var respond = _mapper.Map<WalletDTO>(result);
            return StatusCode(200, result);
        }

        [HttpDelete]
        [Authorize]
        [Route("api/wallets")]
        [SwaggerOperation(Summary = "[Authorize] Disable a Wallet")]
        public async Task<IActionResult> DisableWallet(Guid id)
        {
            string accountID = User.Identity.Name;

            if (accountID.IsNullOrEmpty() || accountID == "0")
            {
                return BadRequest("The account is not available in our system!");
            }
            var result = await _serviceWrapper.Wallets.DisableWallet(id, int.Parse(accountID));
            if (!result)
            {
                return BadRequest("Cannot delete this wallet, please try again");
            }

            return StatusCode(200, "Deleted");
        }

        [HttpGet]
        [Authorize]
        [Route("api/wallets/types")]
        [SwaggerOperation(Summary = "[Authorize] Get All Wallet Types")]
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

        [HttpGet]
        [Authorize]
        [Route("api/wallet/type")]
        [SwaggerOperation(Summary = "[Authorize] Get Wallet By its type")]
        public async Task<IActionResult> GetWalletByAccountIDAndType(WalletTypeEnum walletType)
        {
            string accountID = User.Identity.Name;
            if (accountID.IsNullOrEmpty() || accountID == "0")
            {
                return BadRequest("The account is not available in our system!");
            }
            var wallet = await _serviceWrapper.Wallets.GetWalletByAccountIDAndType(int.Parse(accountID), (int)walletType);
            if (wallet == null)
            {
                return NotFound("Wallet not found!");
            }
            var respond = _mapper.Map<WalletDTO>(wallet);
            return Ok(respond);
        }

        [HttpGet]
        [Authorize]
        [Route("api/wallet/{id}")]
        [SwaggerOperation(Summary = "[Authorize] Get Wallet By its ID")]
        public async Task<IActionResult> GetWalletByID(Guid id)
        {
            var walletFound = await _serviceWrapper.Wallets.GetWalletByID(id);
            if(walletFound == null)
            {
                return NotFound("This wallet is not found!");
            }
            var respond = _mapper.Map<WalletDTO>(walletFound);
            return Ok(respond);
        }
    }
}
