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

        public FubuContinuation completeTodo(CompleteTodo viewModel)
        {
            _dbInteractor.markComplete(viewModel.Id);
            return FubuContinuation.RedirectTo<HomeEndpoint>(x => x.Index());
        }

        public FubuContinuation deleteTodo(DeleteTodo viewModel)
        {
            _dbInteractor.deleteTodo(viewModel.Id);
            return FubuContinuation.RedirectTo<HomeEndpoint>(x => x.Index());
        }
    }

    public class DeleteTodo
    {
        public Guid Id { get; set; }
    }

    public class CompleteTodo
    {
        public Guid Id { get; set; }
    }

}