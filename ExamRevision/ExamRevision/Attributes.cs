using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamRevision
{
    class Attributes : Attribute
    {
        string comment;
        public Attributes(string comment)
        {
            this.comment = comment;
        }

        public Attributes()
        {

        }
    }
}
