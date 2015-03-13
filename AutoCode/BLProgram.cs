using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Windows.Forms;
using CSScriptLibrary;
using Microsoft.CSharp;

namespace AutoCode
{
    class BLProgram
    {
        public void cc()
        {
            Assembly assembly = CSScript.LoadCode(
             @"using System;
              public class Script
              {
                  public static void SayHello(string gritting)
                  {
                      Console.WriteLine(gritting);
                  }
              }");
            AsmHelper script = new AsmHelper(assembly);
            script.Invoke("Script.SayHello", "Hello World!");
        }


    }
    
}
