using Microsoft.AspNetCore.Mvc.RazorPages;
using Farcas_Razvan_Lab2_incercareaNR2.Data;

namespace Farcas_Razvan_Lab2_incercareaNR2.Models
{
    public class BookCategoriesPageModel : PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList;

        public void PopulateAssignedCategoryData(Farcas_Razvan_Lab2_incercareaNR2Context context, Book book)
        {
            var allCategories = context.Category;
            var bookCategories= new HashSet<int>(book.BookCategories.Select(c=> c.CategoryID));
            AssignedCategoryDataList = new List<AssignedCategoryData>();
            foreach(var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategoryID = cat.ID,
                    Name = cat.CategoryName,
                    Assigned = bookCategories.Contains(cat.ID)
                });
            }

        }
        public void UpdateBookCategories(Farcas_Razvan_Lab2_incercareaNR2Context context, string[] selectedCategories, Book bookToUpdate)
        {
            if(selectedCategories == null)
            {
                bookToUpdate.BookCategories = new List<BookCategory>();
                return;
            }
            var selectedCategoriesHs = new HashSet<string>(selectedCategories);
            var bookCategories=new HashSet<int>
                (bookToUpdate.BookCategories.Select(c=> c.CategoryID));
            foreach(var cat in context.Category)
            {
                if (selectedCategoriesHs.Contains(cat.ID.ToString()))
                {
                    if (!bookCategories.Contains(cat.ID))
                    {
                        bookToUpdate.BookCategories.Add(
                            new BookCategory
                            {
                                BookID=bookToUpdate.ID,
                                CategoryID=cat.ID
                            });
                    }
                }
                else
                {
                    if (bookCategories.Contains(cat.ID))
                    {
                        BookCategory courseToRemove = bookToUpdate.BookCategories.SingleOrDefault(i => i.CategoryID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }

            }
        }
    }
}
