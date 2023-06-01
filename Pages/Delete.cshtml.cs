using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace todoapp_netcore.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly ToDoService _service;

        [BindProperty]
        public Guid Id { get; set; }

        public DeleteModel(ToDoService service)
        {
            _service = service;
        }

        public IActionResult OnGet(Guid id)
        {
            var item = _service.Get(id);

            if (item == null)
            {
                return NotFound();
            }

            Id = id;

            return Page();
        }

        public IActionResult OnPost()
        {
            _service.Delete(Id);

            return RedirectToPage("/Index");
        }
    }
}
