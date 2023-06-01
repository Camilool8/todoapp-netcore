using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace todoapp_netcore.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ToDoService _service;
        public List<ToDoItem> Items { get; set; }

        public IndexModel(ToDoService service)
        {
            _service = service;
        }

        public void OnGet()
        {
            Items = _service.GetAll();
        }
    }
}