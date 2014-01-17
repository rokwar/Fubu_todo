using System;
using System.Web.UI.WebControls;
using FubuMVC.Core.Continuations;
using fubu_todo.Endpoints.Home;
using Raven.Client.Linq;

namespace fubu_todo
{
    public class TodoItemEndpoint
    {
        private readonly ITodoListDBInteractor _dbInteractor;
        public TodoItemEndpoint(ITodoListDBInteractor dbInteractor)
        {
            _dbInteractor = dbInteractor; 
        }
        public FubuContinuation createTodo(FubuTodoViewModel viewModel)
        {
            FubuTodoViewModel newTodo = new FubuTodoViewModel
            {
                title = viewModel.title,
                description = viewModel.description
            };
            _dbInteractor.addTodo(newTodo);
            return FubuContinuation.RedirectTo<HomeEndpoint>(x => x.Index());
        }
        public FubuContinuation completeTodo(FubuTodoViewModel viewModel)
        {
            _dbInteractor.markComplete(viewModel);
            return FubuContinuation.RedirectTo<HomeEndpoint>(x => x.Index());
        }
    }

    public class CreateTodo
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}