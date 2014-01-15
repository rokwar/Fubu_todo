using FubuMVC.Core;

namespace fubu_todo
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            FubuApplication.BootstrapApplication<FubuTodoApplication>();
        }
    }
}