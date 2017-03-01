using GudrunsjodenConfig.SourceCode;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gudrunsjoden.TestSuite
{
    public class SuiteBase : Main
    {
        public SuiteBase(IWebDriver Obj)
        {
            driver = Obj;
        }
        public SuiteBase()
        {

        }
    }
}
