using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Farcas_Razvan_Lab2_incercareaNR2.Data;
using Farcas_Razvan_Lab2_incercareaNR2.Models;
using Farcas_Razvan_Lab2_incercareaNR2.Models.ViewModels;
using System.Security.Policy;

namespace Farcas_Razvan_Lab2_incercareaNR2.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly Farcas_Razvan_Lab2_incercareaNR2.Data.Farcas_Razvan_Lab2_incercareaNR2Context _context;

        public IndexModel(Farcas_Razvan_Lab2_incercareaNR2.Data.Farcas_Razvan_Lab2_incercareaNR2Context context)
        {
            _context = context;
        }

        public IList<Category> Category { get;set; } = default!;

        public BookData BookD { get; set; }
        public int CategoryID { get; set; }
        public int BookID { get; set; }
        public async Task OnGetAsync(int ?id, int? bookID)
        {
            BookD = new BookData();
            BookD.Categories= await _context.Category
                .Include(i=> i.BookCategories)
                .ThenInclude(i=>i.Book)
                .OrderBy(i=>i.CategoryName)
                .ToListAsync();
            BookD.BookCategories = await _context.BookCategory
                .Include(b =>b.Category)
                .Include(b => b.Book)
                .OrderBy(b => b.Book)
                .ToListAsync();
            if (id != null)
            {
                CategoryID = id.Value;
                BookD.Books = await _context.BookCategory
                .Where(c => c.CategoryID == CategoryID)
                .Select(c => c.Book)
                .ToListAsync();
            }

        }
    }
}
