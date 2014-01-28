using System;
using System.Web.UI.WebControls;
using FubuMVC.Core.Ajax;
using FubuMVC.Core.Continuations;
using fubu_todo.Endpoints.Home;
using Microsoft.Data.OData.Query.SemanticAst;
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

        public AjaxContinuation completeTodo(CompleteTodo viewModel)
        {
            _dbInteractor.markComplete(viewModel.Id);
            var continuation = AjaxContinuation.Successful();
            return continuation;
        }

        public AjaxContinuation deleteTodo(DeleteTodo viewModel)
        {
            _dbInteractor.deleteTodo(viewModel.Id);
            var continuation = AjaxContinuation.Successful();
            return continuation;
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