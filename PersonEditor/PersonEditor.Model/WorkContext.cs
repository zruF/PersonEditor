using PersonAPI.Model.Repositories;
using PersonEditor.Model.Context;
using PersonEditor.Model.Repositories;

namespace PersonEditor.Model
{
    public class WorkContext : IWorkContext
    {
        private readonly DataContext _dataContext;

        internal DataContext DataContext => _dataContext;

        private readonly PersonRepository _person;

        internal PersonRepository Person => _person;

        public IPersonRepository PersonRepository => _person;

        public WorkContext()
        {
            _dataContext = new DataContext();

            _person = new PersonRepository(_dataContext);
        }
    }
}
