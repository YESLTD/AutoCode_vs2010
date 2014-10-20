using System;
using System.Collections.Generic;
using System.Text;

namespace AutoCode
{
    interface IBaseProperity
    {
         string getStrConn();
         string getModelClassPath();
         string getDaoClassPath();
         string getServiceClassPath();
         void setStrConn(string connectsting);
         void setModelClassPath(string path);
         void setDaoClassPath(string path);
         void setServiceClassPath(string path);
    }
}
