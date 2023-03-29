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
    [Authorize]
    [ApiController]
    public class TransactionApiController : ControllerBase
    {
        private ITransaction trser;
        public TransactionApiController(ITransaction trser)
        {
            this.trser = trser;
        }

        [HttpGet]
        [Route("DisplayAllTransactions")]

        public async Task<IActionResult> DisplayAllTransactions()
        {
            List<TransactionModel> tlst = new List<TransactionModel>();
            try
            {
                tlst = await trser.ShowAllTransactions();
                return Ok(tlst);

            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        [Route("GetTransactionStatus/{id}")]
        public async Task<IActionResult> GetTransactionStatus(int id)
        {
            TransactionModel? trans;
            try
            {
                trans =await trser.GetTransactionStatus(id);
                return Ok(trans);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        [Route("MakeTransaction")]
        public async Task<IActionResult> MakeTransaction(TransactionModel trans)
        {
            TransactionModel? t;
            try
            {
                t = await trser.MakeTransaction(trans);
                return Ok(t);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        [Route("UpdateTransaction")]
        public async Task<IActionResult> UpdateTransaction(TransactionModel Updtrans)
        {
            TransactionModel? trans;
            try
            {
                trans = await trser.UpdateTransaction(Updtrans);
                return Ok(trans);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteTransaction/{id}")]
        public async Task<IActionResult> DeleteTransaction(int id)
        {
            TransactionModel? trans;
            try
            {
                trans = await trser.DeleteTransaction(id);
                return Ok(trans);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
