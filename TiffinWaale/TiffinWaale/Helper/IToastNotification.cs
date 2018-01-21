using System;
using System.Collections.Generic;
using System.Text;

namespace TiffinWaale.Helper
{
    public interface IToastNotification
    {
        void LongTime(string message);
        void ShortTime(string message);
    }
}
