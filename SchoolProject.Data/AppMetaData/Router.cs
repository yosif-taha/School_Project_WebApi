using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Data.AppMetaData
{
    public static class Router
    {
        public const string singleRoute = "/{id}";

        public const string root = "api";
        public const string version = "V1";
        public const string rule = $"{root}/{version}/";


        public static class StudentRouting 
        {
            public const string prefix = $"{rule}Student";
            public const string List = $"{prefix}/List";
            public const string GetById = prefix + singleRoute;



        }
    }
}
