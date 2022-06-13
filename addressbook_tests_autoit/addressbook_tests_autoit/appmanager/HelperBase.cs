using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoItX3Lib;

namespace addressbook_tests_autoit
{
    public class HelperBase
    {
        protected ApplicationManager manager;
        protected AutoItX3 aux;
        protected string WINTITLE;
        public HelperBase(ApplicationManager manager)
        {
            this.manager = manager;
            this.aux = manager.Aux;
            WINTITLE = ApplicationManager.WINTITLE;
        }
    }
}