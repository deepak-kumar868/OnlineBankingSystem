using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DALayer;
using EntityLayer;
using Microsoft.AspNetCore.Authorization;

namespace UILayer.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class AccountController : ControllerBase
    {
        private IAccount actser;
        public AccountController(IAccount actser)
        {
            this.actser = actser;
        }

        [HttpGet]
        [Route("DisplayAllAccounts")]

        public async Task<IActionResult> DisplayAllAccounts()
        {
            List<AccountModel> actlst = new List<AccountModel>();
            try
            {
                actlst =await actser.ShowAllAccounts();
                return Ok(actlst);

            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("ShowByAcctByCusId/{id}")]
        public async Task<IActionResult> ShowByAcctNo(int id)
        {
            AccountModel? act;
            try
            {
                act = await actser.ShowByAcctNo(id);
                return Ok(act);
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("AddAccount")]
        public async Task<IActionResult> AddAccount(AccountModel AddAct)
        {
            AccountModel? act;
            try
            {
                act=await actser.AddAccount(AddAct);
                return Ok(act);
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        [Route("UpdateAccount")]
        public async Task<IActionResult> UpdateAccount(AccountModel UpdAct)
        {
            AccountModel? act;
            try
            {
                act=await actser.UpdateAccount(UpdAct);
                return Ok(act);
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteAccount/{id}")]
        public async Task<IActionResult> DeleteAccount(int id)
        {
            AccountModel? DelAct;
            try
            {
                DelAct = await actser.DeleteAccount(id);
                return Ok(DelAct);
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
