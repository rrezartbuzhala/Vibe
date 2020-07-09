using System;
using System.Collections.Generic;
using System.Text;

namespace Rrezart.Vibe.Application.Exceptions
{
    public class PasswordIncorrectException : Exception
    {
        
        public PasswordIncorrectException() : base(String.Format("Password is incorrect"))
        {

        }
    }
}
