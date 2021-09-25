using System;

namespace PersonEditor.Model.Exceptions
{
    public class PersonNotFoundException : Exception
    {
        public PersonNotFoundException(string message): base(message)
        {
        }

        public PersonNotFoundException()
        {

        }
    }
}
