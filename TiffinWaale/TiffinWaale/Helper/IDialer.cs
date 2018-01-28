using System;
using System.Collections.Generic;
using System.Text;

namespace TiffinWaale.Helper
{
    public interface IDialer
    {
        bool MakeCall(string phoneNumber);
    }
}
