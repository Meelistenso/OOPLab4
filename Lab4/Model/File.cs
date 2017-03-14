using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class File
    {
        public string Name { get; set; }
        public List<Class> Classes { get; set; }

        public File(string name, List<Class> classes) {
            Name = name;
            Classes = classes;
        }
    }
}
