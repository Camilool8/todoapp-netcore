using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace todoapp_netcore
{
    [ApiController]
    [Route("[controller]")]
    public class ToDoController : ControllerBase
    {
        private readonly ToDoService _service;

        public ToDoController(ToDoService service)
        {
            _service = service;
        }

        [HttpGet]
        public ActionResult<List<ToDoItem>> GetAll()
        {
            return Ok(_service.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<ToDoItem> Get(Guid id)
        {
            var item = _service.Get(id);
            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        [HttpPost]
        public ActionResult<ToDoItem> Add(ToDoItem item)
        {
            _service.Add(item);
            return CreatedAtAction(nameof(Get), new { id = item.Id }, item);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _service.Delete(id);
            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, ToDoItem item)
        {
            if (id != item.Id)
            {
                return BadRequest();
            }

            _service.Update(item);
            return NoContent();
        }
    }
}
