using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EntityLayer;
using DALayer;
using DALayer.Models;
using Microsoft.AspNetCore.Authorization;

namespace UILayer.Controllers
{
    //[Route("api/[controller]")]
    //[Authorize]
    [ApiController]
    public class LoanWebApiController : ControllerBase
    {
        private ILoan lnser;
        public LoanWebApiController(ILoan lnser)
        {
            this.lnser = lnser;
        }

        [HttpGet]
        [Route("DisplayAllLoanRecords")]

        public async Task<IActionResult> Display()
        {
            List<LoanModel> lnlst = new List<LoanModel>();
            try
            {
                lnlst = await lnser.ShowAllAvailableLoans();
                return Ok(lnlst);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("GetLoanStatus/{id}")]
        public async Task<IActionResult> GetStatus(int id)
        {
            LoanModel? ln;
            try
            {
                ln = await lnser.GetLoanStatus(id);
                return Ok(ln);
            }
            catch (Exception e) { return BadRequest(e.Message); }
        }

        [HttpPost]
        [Route("TakeNewLoan")]
        public async Task<IActionResult> NewLoan(LoanModel ln)
        {
            LoanModel? loan;
            try
            {
                loan = await lnser.TakeLoan(ln);
                return Ok(loan);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        [Route("UpdateLoanDetails")]
        public async Task<IActionResult> Update(LoanModel Updln)
        {
            LoanModel? loan;
            try
            {
                loan = await lnser.UpdateLoanDetails(Updln);
                return Ok(loan);
            }
            catch (Exception e) { return BadRequest(e.Message); }
        }

        [HttpDelete]
        [Route("DeleteLoanRecord/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            LoanModel? loan;
            try
            {
                loan = await lnser.DeleteLoanRecord(id);
                return Ok(loan);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }

}

