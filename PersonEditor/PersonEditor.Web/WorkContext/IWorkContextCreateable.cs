using Microsoft.AspNetCore.Http;
using PersonEditor.Model;

namespace PersonEditor.Web.WorkContext
{
    public interface IWorkContextCreatable
    {
        IWorkContext Create(HttpContext context);
    }
}
