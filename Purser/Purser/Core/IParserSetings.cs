using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Purser.Core
{
    interface IParserSetings
    {

        string BaseUrl { get; set; }

        string Prefix  { get; set; }

        int StartPoint { get; set; }

        int EndPoint   { get; set; }
    }
}
