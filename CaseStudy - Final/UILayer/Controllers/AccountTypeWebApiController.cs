using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DALayer;
using DALayer.Models;
using EntityLayer;
using Microsoft.AspNetCore.Authorization;

namespace UILayer.Controllers
{
    //[Route("api/[controller]")]
    //[Authorize]
    [ApiController]
    public class AccountTypeWebApiController : ControllerBase
    {
        private IAccountType ATser;
        public AccountTypeWebApiController(IAccountType ATser)
        {
            this.ATser = ATser;
        }

        [HttpGet]
        [Route("DisplayAllActTypes")]

        public async Task<IActionResult> Display()
        {
            List<AccountTypeModel> ATlst = new List<AccountTypeModel>();
            try
            {
                ATlst =await ATser.ShowAllAccountTypes();
                return Ok(ATlst);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("GetActTypeServicesById/{id}")]
        public async Task<IActionResult> GetServices(int id)
        {
            AccountTypeModel? ActTyp;
            try
            {
                ActTyp = await ATser.GetActTypeServices(id);
                return Ok(ActTyp);
            }
            catch (Exception e) { return BadRequest(e.Message); }
        }

        [HttpPost]
        [Route("AddNewActType")]
        public async Task<IActionResult> AddNewActType(AccountTypeModel ActTyp)
        {
            AccountTypeModel? ATyp;
            try
            {
                ATyp = await ATser.AddNewAcctType(ActTyp);
                return Ok(ATyp);
            }
            catch (Exception e) { return BadRequest(e.Message); }
        }

        [HttpPut]
        [Route("UpdateActType")]
        public async Task<IActionResult> Update(AccountTypeModel Upd)
        {
            AccountTypeModel? ATyp;
            try
            {
                ATyp=await ATser.UpdateAcctTypeDetails(Upd);
                return Ok(ATyp);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteActType/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            AccountTypeModel? ActTyp;
            try
            {
                ActTyp = await ATser.DeleteAcctType(id);
                return Ok(ActTyp);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
