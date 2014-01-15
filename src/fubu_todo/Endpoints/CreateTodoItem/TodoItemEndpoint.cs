namespace fubu_todo
{
    public class TodoItemEndpoint
    {
        public FubuTodoViewModel createTodo(CreateTodo todo)
        {
            return new FubuTodoViewModel
            {
                title = todo.Title,
                description = todo.Description
            };
        }
    }

    public class CreateTodo
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}