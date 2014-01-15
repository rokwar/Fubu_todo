using System;
using FubuPersistence;

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
}