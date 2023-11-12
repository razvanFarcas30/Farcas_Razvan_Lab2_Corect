using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Farcas_Razvan_Lab2_incercareaNR2.Data;
using Farcas_Razvan_Lab2_incercareaNR2.Models;
using Microsoft.EntityFrameworkCore;

namespace Farcas_Razvan_Lab2_incercareaNR2.Pages.Borrowings
{
    public class CreateModel : PageModel
    {
        private readonly Farcas_Razvan_Lab2_incercareaNR2.Data.Farcas_Razvan_Lab2_incercareaNR2Context _context;

        public CreateModel(Farcas_Razvan_Lab2_incercareaNR2.Data.Farcas_Razvan_Lab2_incercareaNR2Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var bookList = _context.Book
            .Include(b => b.Author)
            .Select(x => new
 {
     x.ID,
     BookFullName = x.Title + " - " + x.Author.LastName + " " +
x.Author.FirstName
 });
            ViewData["BookID"] = new SelectList(bookList, "ID", "BookFullName");
        ViewData["MemberID"] = new SelectList(_context.Member, "ID", "FullName");
            return Page();
        }

        [BindProperty]
        public Borrowing Borrowing { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Borrowing == null || Borrowing == null)
            {
                return Page();
            }

            _context.Borrowing.Add(Borrowing);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
