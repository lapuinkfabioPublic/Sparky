using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
    public interface ILogBook
    {
        void Message(string message);

    }

    public class LogBook : ILogBook
    {
        public LogBook()
        { }

        public void Message(string message)
        {
            Console.WriteLine(message);
        }
    }


    public class LogFakker : ILogBook
    {
        public LogFakker()
        { }

        public void Message(string message)
        {
        }
    }
}
