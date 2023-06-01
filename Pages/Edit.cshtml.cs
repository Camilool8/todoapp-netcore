using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace todoapp_netcore.Pages
{
    public class EditModel : PageModel
    {
        private readonly ToDoService _service;

        [BindProperty]
        public ToDoItem Item { get; set; }

        public EditModel(ToDoService service)
        {
            _service = service;
        }

        public IActionResult OnGet(Guid id)
        {
            Item = _service.Get(id);

            if (Item == null)
            {
                return NotFound();
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _service.Update(Item);

            return RedirectToPage("/Index");
        }
    }
}
