using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using THTZDotNetCore.MiniKpayDatabase.Models;

namespace THTZDotNetCore.MiniKpayRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TansferController : ControllerBase
    {
        private readonly AppDbContext _db = new AppDbContext();

        [HttpGet]
        public IActionResult GetTransferHistorys()
        {
            var lst = _db.TblTransfers.Where(d => !d.DeleteFlag).ToList();

            return Ok(lst);
        }

        [HttpGet("{id}")]
        public IActionResult GetTransferHistory(int id)
        {
            var item = _db.TblTransfers.FirstOrDefault(d => !d.DeleteFlag && d.TransferId == id);

            if (item is null)
            {
                return NotFound();
            }

            return Ok(item);

        }

        [HttpPost]

        public IActionResult CreateTransfer(TblTransfer transfer)
        {
                var sender = _db.TblUsers.FirstOrDefault(u => u.MobileNumber == transfer.FromMobileNumber && !u.DeleteFlag);

                var receiver = _db.TblUsers.FirstOrDefault(u => u.MobileNumber == transfer.ToMobileNumber && !u.DeleteFlag);

                if (sender is null)
                    return BadRequest("Invalid sender mobile number.");

                if (receiver is null)
                    return BadRequest("Invalid receiver mobile number.");

                if (transfer.FromMobileNumber == transfer.ToMobileNumber)
                    return BadRequest("Sender and receiver mobile numbers must be different.");

                if (sender.Balance < transfer.Amount)
                    return BadRequest("Insufficient balance.");

                if (sender.Pin.ToString() != transfer.Pin.ToString())
                    return Unauthorized("PIN is incorrect.");

            sender.Balance -= transfer.Amount;
            receiver.Balance += transfer.Amount;

            _db.TblTransfers.Add(transfer);
            _db.SaveChanges();
            return Ok("Transfer completed successfully.");
        }
    }
}
