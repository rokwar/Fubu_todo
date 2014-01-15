using System.Linq;
using FubuPersistence;
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
            Container.Inject<IEntityRepository>(repository);
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
    }
}
