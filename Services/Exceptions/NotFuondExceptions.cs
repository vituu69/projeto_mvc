using System;

namespace WebProjct.Service.Exception
{
    public class NotFuondExceptions : ApplicationException
    {
        public NotFuondExceptions(string message) : base(message)
        {
            
        }
    }
}