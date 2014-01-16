using System.Collections.Generic;
using System.Linq;
using FubuPersistence;

namespace fubu_todo.Endpoints.Home
{
    public class TodoListDBInteractor : ITodoListDBInteractor
    {
        private readonly IEntityRepository _entityRepository;
        
        public TodoListDBInteractor(IEntityRepository entityRepository)
        {
            _entityRepository = entityRepository;
        }

        public void addTodo(FubuTodoViewModel newTodo)
        {
            _entityRepository.Update(newTodo);
        }

        public IEnumerable<FubuTodoViewModel> getUncompleted()
        {
            return _entityRepository.All<FubuTodoViewModel>().Where(item => !item.complete).ToList();
        }

        public IEnumerable<FubuTodoViewModel> GetAll()
        {
            return _entityRepository.All<FubuTodoViewModel>().ToList();
        }

        public void markComplete(FubuTodoViewModel completedTodo)
        {
            _entityRepository.Update(completedTodo);
        }
    }

    public interface ITodoListDBInteractor
    {
        void addTodo(FubuTodoViewModel newTodo);
        IEnumerable<FubuTodoViewModel> getUncompleted();
        IEnumerable<FubuTodoViewModel> GetAll();
        void markComplete(FubuTodoViewModel completedTodo);
    }
}