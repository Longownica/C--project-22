using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace Forum.Helpers
{
    public static class MyServer
    {
        public static string MapPath(string path)
        {
            return Path.Combine(
            (string)AppDomain.CurrentDomain.GetData("ContentRootPath"),
            path);
        }
    }
}
