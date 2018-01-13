using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TiffinWaale.Views
{

    public class HomepageMenuItem
    {
        public HomepageMenuItem()
        {
            TargetType = typeof(HomepageDetail);
        }
        public int Id { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}