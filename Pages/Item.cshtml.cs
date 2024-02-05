using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebUI.Models;
using WebUI.Services;

namespace WebUI.Pages
{
    public class ItemModel : PageModel
    {
        public List<Item> items = new();
        [BindProperty]
        public Item NewItem { get; set; } = new();
        public void OnGet()
        {
            items = ItemService.GetAll();
        }
        public string GlutenFreeText(Item item)
        {
            return item.IsGlutenFree ? "Gluten Free" : "Not Gluten Free";
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            ItemService.Add(NewItem);
            return RedirectToAction("Get");
        }

        public IActionResult OnPostDelete(int id)
        {
            ItemService.Delete(id);
            return RedirectToAction("Get");
        }
    }
}
