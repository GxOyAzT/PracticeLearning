using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    interface IHandler
    {
        void SetNextHandler(IHandler handler);
        void Process(Request request);
    }

    abstract class BaseHandler : IHandler
    {
        protected IHandler _nextHandler;

        public BaseHandler()
        {
            _nextHandler = null;
        }

        public abstract void Process(Request request);

        public void SetNextHandler(IHandler handler)
        {
            _nextHandler = handler;
        }
    }

    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public float Income { get; set; }
    }

    class Request
    {
        public object Data { get; set; }
        public List<string> ValidationMessages;

        public Request()
        {
            ValidationMessages = new List<string>();
        }
    }

    class MaxAgeHandler : BaseHandler
    {
        public override void Process(Request request)
        {
            if (request.Data is Person person)
            {
                if (person.Age > 55) request.ValidationMessages.Add("Invalid age.");
                if (_nextHandler != null) _nextHandler.Process(request);
            }
            else
            {
                throw new Exception("Invalid message data");
            }
        }
    }

    class MaxNameLengthHandler : BaseHandler
    {
        public override void Process(Request request)
        {
            if (request.Data is Person person)
            {
                if (person.Name.Length > 10) request.ValidationMessages.Add("Invalid name.");
                if (_nextHandler != null) _nextHandler.Process(request);
            }
            else
            {
                throw new Exception("Invalid message data");
            }
        }
    }

    class MaxIncomeHandler : BaseHandler
    {
        public override void Process(Request request)
        {
            if (request.Data is Person person)
            {
                if (person.Income > 1000) request.ValidationMessages.Add("Invalid income.");
                if (_nextHandler != null) _nextHandler.Process(request);
            }
            else
            {
                throw new Exception("Invalid message data");
            }
        }
    }
}
