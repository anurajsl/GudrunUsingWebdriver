using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Enum
{
    public class EnumTypes
    {
        public enum IBarMenu
        {
            Journal,
            Events,
            Jobs,
            People,
            Videos,
            News,
            Blogs,
            Images,
            Books,
            MyProfile,
            MyJournal,
            Office,
            BySubjects
        }
        public enum TestData
        {
            Common = 1,
            Events = 2,
            Configuration = 7,
            MyHome = 9,
            Customers = 11,

        }
        public enum Object
        {
            ReviewForum,
            Login,
            OfficeLogin,

        }

    }
}
