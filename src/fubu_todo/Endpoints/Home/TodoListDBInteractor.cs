using System;
using System.Collections.Generic;
using System.Linq;
using FubuPersistence;

namespace fubu_todo.Endpoints.Home
{
    public class TodoListDBInteractor : ITodoListDBInteractor
    {
        private readonly IEntityRepository _entityRepository;
        private readonly ITransaction _transaction;

        public TodoListDBInteractor(IEntityRepository entityRepository, ITransaction transaction)
        {
            _entityRepository = entityRepository;
            _transaction = transaction;
        }

        public void addTodo(FubuTodoViewModel newTodo)
        {
            _transaction.WithRepository(x => x.Update(newTodo));
        }

        public IEnumerable<FubuTodoViewModel> getUncompleted()
        {
            return _entityRepository.All<FubuTodoViewModel>().Where(item => !item.complete).ToList();
        }

        public IEnumerable<FubuTodoViewModel> GetAll()
        {
            return _entityRepository.All<FubuTodoViewModel>().ToList();
        }

        public void markComplete(Guid id)
        {
            var completedTodo = _entityRepository.Find<FubuTodoViewModel>(id);
            completedTodo.complete = true;
            _transaction.WithRepository(x => x.Update(completedTodo));
        }

        public void deleteTodo(Guid id)
        {
            _transaction.WithRepository(x =>
            {
                var foundTodo = x.Find<FubuTodoViewModel>(id);
                x.Remove(foundTodo);
            });
        }
    }

    public interface ITodoListDBInteractor
    {
        void addTodo(FubuTodoViewModel newTodo);
        IEnumerable<FubuTodoViewModel> getUncompleted();
        IEnumerable<FubuTodoViewModel> GetAll();
        void markComplete(Guid id);
        void deleteTodo(Guid id);
    }
}