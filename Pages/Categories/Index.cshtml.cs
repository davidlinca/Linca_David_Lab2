using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Linca_David_Lab2.Data;
using Linca_David_Lab2.Models;
using Linca_David_Lab2.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace Linca_David_Lab2.Pages.Categories
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    {
        private readonly Linca_David_Lab2.Data.Linca_David_Lab2Context _context;

        public IndexModel(Linca_David_Lab2.Data.Linca_David_Lab2Context context)
        {
            _context = context;
        }

        public IList<Category> Category { get; set; } = default!;

        public CategoryIndexData CategoryData { get; set; }
        public int CategoryID { get; set; }
        public int BookID { get; set; }

        public async Task OnGetAsync(int? id, int? bookID)
        {
            CategoryData = new CategoryIndexData();
            CategoryData.Categories = await _context.Category
                .Include(i => i.BookCategories)
                .ThenInclude(c => c.Book)
                .ThenInclude(b => b.Author)
                .OrderBy(i => i.CategoryName)
                .ToListAsync();

            if (id != null)
            {
                CategoryID = id.Value;
                CategoryData.Books = CategoryData.Categories
                    .Where(i => i.ID == id.Value).SelectMany(i => i.BookCategories.Select(b => b.Book));
            }
        }
    }
}
