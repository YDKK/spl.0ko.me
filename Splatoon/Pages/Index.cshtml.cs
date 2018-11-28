using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace Splatoon.Pages
{
    public class IndexModel : PageModel
    {
        public static Dictionary<string, (DateTime CachedAt, Dictionary<string, dynamic> Data)> Cache = new Dictionary<string, (DateTime CachedAt, Dictionary<string, dynamic> Data)>();
        public string UserName { get; set; }

        public IActionResult OnGet()
        {
            var regex = new Regex("^[a-zA-Z_]{1,15}$");
            UserName = HttpContext.Request.Query["user"];

            if (!string.IsNullOrEmpty(UserName) && !regex.IsMatch(UserName))
            {
                return StatusCode((int)HttpStatusCode.BadRequest, "ユーザ名の形式が不正です．");
            }

            return Page();
        }
    }
}
