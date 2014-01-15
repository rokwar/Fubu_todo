using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Raven.Client.Document;

namespace fubu_todo_test
{
    class HelperMethods
    {
        static public DocumentStore SpinUpNewDB()
        {
            DocumentStore documentStore = new DocumentStore { Url = "http://localhost:8080" };
            documentStore.DefaultDatabase = "TestDB" + DateTime.Now.Ticks;
            documentStore.Initialize();
            return documentStore;
        }
    }
}
