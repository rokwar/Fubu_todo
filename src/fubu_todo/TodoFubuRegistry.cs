using System.Net;
using FubuMVC.Core;
using FubuMVC.Validation;

namespace fubu_todo
{
    public class TodoFubuRegistry : FubuRegistry
    {
        public TodoFubuRegistry()
        {
            Actions.IncludeClassesSuffixedWithEndpoint();
            Routes.HomeIs<HomeEndpoint>(x => x.Index());

            AlterSettings<ValidationSettings>(validation => validation.FailAjaxRequestsWith(HttpStatusCode.OK));
        }
    }
}