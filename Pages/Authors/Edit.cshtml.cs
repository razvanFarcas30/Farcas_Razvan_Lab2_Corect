﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Farcas_Razvan_Lab2_incercareaNR2.Data;
using Farcas_Razvan_Lab2_incercareaNR2.Models;

namespace Farcas_Razvan_Lab2_incercareaNR2.Pages.Authors
{
    public class EditModel : PageModel
    {
        private readonly Farcas_Razvan_Lab2_incercareaNR2.Data.Farcas_Razvan_Lab2_incercareaNR2Context _context;

        public EditModel(Farcas_Razvan_Lab2_incercareaNR2.Data.Farcas_Razvan_Lab2_incercareaNR2Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Author Author { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Author == null)
            {
                return NotFound();
            }

            var author =  await _context.Author.FirstOrDefaultAsync(m => m.ID == id);
            if (author == null)
            {
                return NotFound();
            }
            Author = author;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Author).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthorExists(Author.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool AuthorExists(int id)
        {
          return (_context.Author?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
