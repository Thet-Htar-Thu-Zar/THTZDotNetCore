using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using THTZDotNetCore.MiniKpayDatabase.Models;

namespace THTZDotNetCore.MiniKpayRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WithdrawController : ControllerBase
    {
        private readonly AppDbContext _db = new AppDbContext();

        [HttpGet]
        public IActionResult GetWithdraws()
        {
            var lst = _db.TblWithdraws.Where(d => !d.DeleteFlag).ToList();

            return Ok(lst);
        }

        [HttpGet("{id}")]
        public IActionResult GetWithdraw(int id)
        {
            var item = _db.TblWithdraws.FirstOrDefault(d => !d.DeleteFlag && d.WithdrawId == id);

            if (item is null)
            {
                return NotFound();
            }

            return Ok(item);

        }

        [HttpPost]

        public IActionResult CreateWithdraw(TblWithdraw w)
        {
            var currentUser = _db.TblUsers.FirstOrDefault(u => u.MobileNumber == w.MobileNumber && !u.DeleteFlag);

            if (currentUser is null)
            {
                return BadRequest("No Data Found");
            }

            if (currentUser.Balance < w.Balance)
            {
                return BadRequest("Insufficient balance.");
            }

            var newBalance =  currentUser.Balance - w.Balance;
            currentUser.Balance = newBalance;
            _db.TblWithdraws.Add(w);
            _db.SaveChanges(); 

            return Ok("Withdraw completed successfully.");
        }
    }
}
