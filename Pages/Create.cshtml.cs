using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace todoapp_netcore.Pages
{
    public class CreateModel : PageModel
    {
        private readonly ToDoService _service;

        [BindProperty]
        public ToDoItem Item { get; set; }

        public CreateModel(ToDoService service)
        {
            _service = service;
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _service.Add(Item);

            return RedirectToPage("/Index");
        }
    }
}
