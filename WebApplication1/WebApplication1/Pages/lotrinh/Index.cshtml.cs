using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Pages.lotrinh
{
    public class IndexModel : PageModel
    {
        private readonly WebApplication1.Data.WebApplication1Context _context;

        public IndexModel(WebApplication1.Data.WebApplication1Context context)
        {
            _context = context;
        }

        [BindProperty(SupportsGet =true)]

        public IList<LoTrinh> LoTrinh { get;set; }
        public PaginatedList<LoTrinh> lotrinhs { get; set; }
        public async Task OnGetAsync(int? pageIndex)
        {
            IQueryable<LoTrinh> lotrinh = from s in _context.LoTrinh
                    select s;
            int pageSize = 3;
            lotrinhs = await PaginatedList<LoTrinh>.CreateAsync(
               lotrinh.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
