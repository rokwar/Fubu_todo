using System;
using FubuLocalization;
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
            Property(x => x.Title).Required(ValidationTokens.TitleRequired, ValidationMode.Triggered);
            Property(x => x.Description).Required(ValidationTokens.DescriptionRequired, ValidationMode.Triggered);
        }
    }

    public class ValidationTokens : StringToken
    {
        public static ValidationTokens TitleRequired = new ValidationTokens("Title is required");
        public static ValidationTokens DescriptionRequired = new ValidationTokens("Description is required");
        public ValidationTokens(string defaultValue)
            : base(null, defaultValue)
        {
            
        }
    }
}