using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using THTZDotNetCore.MiniKpayDatabase.Models;

namespace THTZDotNetCore.MiniKpayRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankAccountController : ControllerBase
    {
        private readonly AppDbContext _db = new AppDbContext();

        [HttpGet]
        public IActionResult GetBankAccounts()
        {
            var lst = _db.TblUsers.AsNoTracking().ToList();
            return Ok(lst);
        }

        [HttpGet("{id}")]
        public IActionResult GetBankAccount(int id)
        {
            var item = _db.TblUsers.AsNoTracking().FirstOrDefault(x => x.UserId == id);
            if (item is null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        [HttpPost]

        public IActionResult CreateBankAccount(TblUser user)
        {
            _db.TblUsers.Add(user);
            _db.SaveChanges();
            return Ok(user);
        }

        [HttpPut("{id}")]

        public IActionResult UpdateBankAccount(int id, TblUser user)
        {
            var item = _db.TblUsers.AsNoTracking().FirstOrDefault(x => x.UserId == id);
            if (item is null)
            {
                return NotFound();
            }

            item.FirstName = user.FirstName;
            item.LastName = user.LastName;
            item.MobileNumber = user.MobileNumber;
            item.Balance = user.Balance;
            item.Pin = user.Pin;

            _db.Entry(item).State = EntityState.Modified;
            _db.SaveChanges();

            return Ok(item);
        }

        //[HttpPatch("{id}")]

        //public IActionResult PatchBankAccount(int id, TblUser user)
        //{
        //    var item = _db.TblUsers.AsNoTracking().FirstOrDefault(x => x.UserId == id);
        //    if (item is null)
        //    {
        //        return NotFound();
        //    }

        //    if (!string.IsNullOrEmpty(user.FirstName))
        //    {
        //        item.FirstName = user.FirstName;

        //    }
        //    if (!string.IsNullOrEmpty(user.LastName))
        //    {
        //        item.LastName = user.LastName;
        //    }
        //    if (!string.IsNullOrEmpty(user.MobileNumber))
        //    {
        //        item.MobileNumber = user.MobileNumber;
        //    }
        //    if (!string.IsNullOrEmpty(user.Balance))
        //    {
        //        item.Balance = user.Balance;
        //    }
        //    if (!string.IsNullOrEmpty(user.Pin))
        //    {
        //        item.MobileNumber = user.Pin;
        //    }

        //    _db.Entry(item).State = EntityState.Modified;
        //    _db.SaveChanges();

        //    return Ok(item);
        //}

        [HttpDelete("{id}")]
        public IActionResult DeleteBankAccount(int id)
        {
            var item = _db.TblUsers.AsNoTracking().FirstOrDefault(x => x.UserId == id);
            if (item is null)
            {
                return NotFound();
            }

            item.DeleteFlag = true;
            _db.Entry(item).State = EntityState.Modified;
            _db.SaveChanges();

            return Ok();
        }
    }
}
