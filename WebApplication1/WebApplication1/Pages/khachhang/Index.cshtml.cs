using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Pages.khachhang
{
    public class IndexModel : PageModel
    {
        private readonly WebApplication1.Data.WebApplication1Context _context;

        public IndexModel(WebApplication1.Data.WebApplication1Context context)
        {
            _context = context;
        }
        [BindProperty(SupportsGet =true)]

        public IList<KhachHang> KhachHang { get; set; }
        public PaginatedList<KhachHang> khachhangs { get; set; }

        public async Task OnGetAsync(int? pageIndex)
        {
            IQueryable<KhachHang> khachhang = from s in _context.KhachHang
                                              select s;
            int pageSize = 3;
            khachhangs = await PaginatedList<KhachHang>.CreateAsync(
               khachhang.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
