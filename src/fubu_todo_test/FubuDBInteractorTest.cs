﻿using System.Linq;
using FubuPersistence;
using FubuPersistence.InMemory;
using FubuTestingSupport;
using fubu_todo;
using fubu_todo.Endpoints.Home;
using NUnit.Framework;
using Raven.Client.Linq;


namespace fubu_todo_test
{
    [TestFixture]
    public class FubuDBInteractorTest : InteractionContext<TodoListDBInteractor>
    {
        protected override void beforeEach()
        {
            var repository = EntityRepository.InMemory();
            Services.Inject<IEntityRepository>(repository);
            Services.Inject<ITransaction>(new DelegatingTransaction(Services.Container));
        }

        [Test]
        public void addTodoTest()
        {
            ClassUnderTest.addTodo(new FubuTodoViewModel());
            ClassUnderTest.GetAll().ShouldHaveCount(1);
        }

        [Test]
        public void getUncompletedTest()
        {
            ClassUnderTest.addTodo(new FubuTodoViewModel());
            ClassUnderTest.addTodo(new FubuTodoViewModel{complete = true});
            ClassUnderTest.getUncompleted().ShouldHaveCount(1);
        }
        [Test]
        public void GetAllTest()
        {
            ClassUnderTest.addTodo(new FubuTodoViewModel());
            ClassUnderTest.addTodo(new FubuTodoViewModel { complete = true });
            ClassUnderTest.GetAll().ShouldHaveCount(2);
        }

        [Test]
        public void markCompletedTest()
        {
            FubuTodoViewModel testModel = new FubuTodoViewModel();
            ClassUnderTest.addTodo(testModel);
            ClassUnderTest.markComplete(testModel);
            ClassUnderTest.GetAll().ShouldHaveCount(1);
            ClassUnderTest.getUncompleted().ShouldHaveCount(0);
        }
    }
}
