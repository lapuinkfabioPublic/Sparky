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
        
        bool LogToDB(string message);

        bool LogBalanceAfterWithdrawal(int balanAfterWithdrawal);

        string MessageWithReturnStr(string message);

        bool LogWithOutPutResult(string str, out string outputStr);

        bool LogWithRefObj(ref Customer customer);

    }

    public class LogBook : ILogBook
    {
        public LogBook()
        { }

        public bool LogBalanceAfterWithdrawal(int balanAfterWithdrawal)
        {
            if (balanAfterWithdrawal >= 0)
            {
                Console.WriteLine("Sucess");
                return true;
            }
            Console.WriteLine("Failure");
            return false;
        }

        public bool LogToDB(string message)
        {
            return true;
        }

        public bool LogWithOutPutResult(string str, out string outputStr)
        {
            outputStr = "Hello " + str;
            return true;
        }

        public bool LogWithRefObj(ref Customer customer)
        {

            return true;
        }

        public void Message(string message)
        {
        }

        public string MessageWithReturnStr(string message)
        {
            Console.WriteLine(message);
            return message.ToLower();
        }
    }


    public class LogFakker : ILogBook
    {
        public LogFakker()
        { }

        public bool LogBalanceAfterWithdrawal(int balanAfterWithdrawal)
        {
            throw new NotImplementedException();
        }

        public bool LogToDB(string message)
        {
            throw new NotImplementedException();
        }

        public void Message(string message)
        {
        }

        public string MessageWithReturnStr(string message)
        {
            return message.ToLower();
        }
        public bool LogWithOutPutResult(string str, out string outputStr)
        {
            outputStr = "Hello " + str;
            return true;
        }
        public bool LogWithRefObj(ref Customer customer)
        {
            return true;
        }

    }
}
