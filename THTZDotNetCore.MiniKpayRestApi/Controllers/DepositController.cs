using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using THTZDotNetCore.MiniKpayDatabase.Models;

namespace THTZDotNetCore.MiniKpayRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepositController : ControllerBase
    {
        private readonly AppDbContext _db = new AppDbContext();

        [HttpGet]
        public IActionResult GetDeposits()
        {
            var lst = _db.TblDeposits
                    .Where(d => !d.DeleteFlag) 
                    .ToList();

            return Ok(lst);
        }

        [HttpGet("{id}")]
        public IActionResult GetDeposit(int id)
        {
            var item = _db.TblDeposits
                     .FirstOrDefault(d => !d.DeleteFlag && d.DepositId == id);

            if (item is null)
            {
                return NotFound();
            }

            return Ok(item);

        }

        [HttpPost]
        public IActionResult CreateDeposit(TblDeposit deposit)
        {
            var currentUser = _db.TblUsers
                                .FirstOrDefault(u => u.MobileNumber == deposit.MobileNumber && !u.DeleteFlag);

            if (currentUser is null)
            {
                return BadRequest("No Data Found");
            }

            var newBalance = currentUser.Balance + deposit.Balance;

            currentUser.Balance = newBalance;
            _db.TblDeposits.Add(deposit);
            _db.SaveChanges();

            return Ok("Deposit completed successfully.");
        }
    }
}
