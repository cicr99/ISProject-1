using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ISProject.Models;
using ISProject.Data;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace ISProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _db;
        public UserController(ApplicationDbContext db)
        {
            _db=db;
        }
        public async Task<IActionResult> Index()
        {
            var claimsIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);
            // Para ver todos los usuarios menos el q esta logueado.
            //return View(await _db.User.Where(u=>u.Id != claim.Value).ToListAsync() );
            // Para ver todos los usuarios, incluido el q esta logueado
            return View(await _db.User.ToListAsync());
        }
    }
}
