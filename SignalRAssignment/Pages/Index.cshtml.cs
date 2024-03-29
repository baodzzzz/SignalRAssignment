﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SignalRAssignment.Models;
using System.Text.Json;

namespace SignalRAssignment.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ASS2_DBContext dbContext;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            this.dbContext = dbContext;
        }

        public void OnGet()
        {
        }

        [BindProperty]
        public Models.Account Account { get; set; }

        public async Task<IActionResult> OnPost()
        {
            var acc = await dbContext.Accounts.SingleOrDefaultAsync(a => a.UserName.Equals(Account.UserName) && a.Password.Equals(Account.Password));

            if (acc == null)
            {
                ViewData["msg"] = "Email or Password is invalid";
                return Page();
            }

            if (acc.Type == "1")
            {
                HttpContext.Session.SetString("Staff", JsonSerializer.Serialize(acc));
                return Redirect("~/Admin/Products");
            }
            else if (acc.Type == "2")
            {
                HttpContext.Session.SetString("User", JsonSerializer.Serialize(acc));
            }
            return Redirect("~/Admin/Members");
        }
    }
}