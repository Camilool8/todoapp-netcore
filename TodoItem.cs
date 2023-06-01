namespace todoapp_netcore
{
    public class ToDoItem
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; }
        public bool IsDone { get; set; }
    }


}
