using System;
using FubuMVC.Core.Registration;
using FubuPersistence;
using FubuMVC.Validation;
using FubuValidation;

namespace fubu_todo
{
    public class FubuTodoViewModel : IEntity
    {
        public string title { get; set; }
        public string description { get; set; }
        public bool complete { get; set; }

        public FubuTodoViewModel()
        {
            complete = false;
        }

        public Guid Id { get; set; }
    }

    public class FubuTodoViewModelOverrides : ClassValidationRules<CreateTodo>
    {
        public FubuTodoViewModelOverrides()
        {
            Property(x => x.Title).Required(ValidationMode.Triggered);
            Property(x => x.Description).Required(ValidationMode.Triggered);
        }
    }
}