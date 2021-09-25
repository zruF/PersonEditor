using PersonEditor.Model.Repositories;

namespace PersonEditor.Model
{
    public interface IWorkContext
    {
         IPersonRepository PersonRepository { get; }
    }
}
