using System;
using System.Collections.Generic;
using System.Linq;

namespace todoapp_netcore
{
    public class ToDoService
    {
        private List<ToDoItem> _items = new List<ToDoItem>();

        public List<ToDoItem> GetAll()
        {
            return _items;
        }

        public ToDoItem Get(Guid id)
        {
            return _items.FirstOrDefault(x => x.Id == id);
        }

        public void Add(ToDoItem item)
        {
            _items.Add(item);
        }

        public void Delete(Guid id)
        {
            var item = Get(id);
            if (item != null)
            {
                _items.Remove(item);
            }
        }

        public void Update(ToDoItem item)
        {
            var existingItem = Get(item.Id);
            if (existingItem != null)
            {
                existingItem.Title = item.Title;
                existingItem.IsDone = item.IsDone;
            }
        }
    }
}
