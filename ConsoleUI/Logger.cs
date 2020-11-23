using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    public class Logger
    {
        private static Logger _logger;

        private Logger()
        {

        }

        public static Logger GetIstance()
        {
            if (_logger is null)
            {
                _logger = new Logger();
            }

            return _logger;
        }
    }
}
