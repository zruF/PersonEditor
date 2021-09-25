using Microsoft.AspNetCore.Http;
using PersonEditor.Model;

namespace PersonEditor.Web.WorkContext
{
    public class WorkContextCreator : IWorkContextCreatable
    {
        public IWorkContext Create(HttpContext context)
        {
            return new Model.WorkContext();
        }
    }
}
