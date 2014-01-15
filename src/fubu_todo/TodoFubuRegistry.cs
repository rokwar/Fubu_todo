using FubuMVC.Core;

namespace fubu_todo
{
    public class TodoFubuRegistry : FubuRegistry
    {
        public TodoFubuRegistry()
        {
            Actions.IncludeClassesSuffixedWithEndpoint();
            Routes.HomeIs<HomeEndpoint>(x => x.Index());
        }
    }
}