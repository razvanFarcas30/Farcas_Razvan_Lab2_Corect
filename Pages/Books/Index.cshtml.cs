﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Farcas_Razvan_Lab2_incercareaNR2.Data;
using Farcas_Razvan_Lab2_incercareaNR2.Models;

namespace Farcas_Razvan_Lab2_incercareaNR2.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly Farcas_Razvan_Lab2_incercareaNR2.Data.Farcas_Razvan_Lab2_incercareaNR2Context _context;

        public IndexModel(Farcas_Razvan_Lab2_incercareaNR2.Data.Farcas_Razvan_Lab2_incercareaNR2Context context)
        {
            _context = context;
        }

        public IList<Book> Book { get;set; } = default!;
        public BookData BookD { get; set; }
        public int BookID { get; set; }
        public int CategoryID { get; set; }



        public async Task OnGetAsync(int? id, int? categoryID)
        {
            BookD = new BookData();
            BookD.Books = await _context.Book
                    .Include(b => b.Publisher)
                    .Include(b => b.Author)
                    .Include(b => b.BookCategories)
                    .ThenInclude(b => b.Category)
                    .AsNoTracking()
                    .OrderBy(b => b.Title)
                    .ToListAsync();
            if (id != null)
            {
                BookID = id.Value;
                Book book = BookD.Books
                .Where(i => i.ID == id.Value).Single();
                BookD.Categories = book.BookCategories.Select(s => s.Category);
            }
        }
    }
}
