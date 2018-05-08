using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCServer
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpServer server = new HttpServer(8967);
            server.Start();
        }
    }
}
