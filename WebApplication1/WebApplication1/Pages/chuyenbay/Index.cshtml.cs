using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Pages.chuyenbay
{
    public class IndexModel : PageModel
    {
        private readonly WebApplication1.Data.WebApplication1Context _context;

        public IndexModel(WebApplication1.Data.WebApplication1Context context)
        {
            _context = context; 
        }
        [BindProperty(SupportsGet = true)]
        public IList<ChuyenBay> ChuyenBay { get; set; }

        [BindProperty(SupportsGet = true)]
        public List<KhachHang> KhachHang { get; set; }
        public PaginatedList<ChuyenBay> chuyenbays {get;set;}
        public async Task OnGetAsync(int? pageIndex)
        {


            KhachHang = (from s in _context.KhachHang
                         select s).ToList<KhachHang>();




            IQueryable<ChuyenBay> chuyenbay = from s in _context.ChuyenBay
                         select s;
            int pageSize = 3;
            chuyenbays = await PaginatedList<ChuyenBay>.CreateAsync(
               chuyenbay.AsNoTracking(), pageIndex ?? 1, pageSize);
        }
    }
}
