using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    class Project
    {
        public string Name { get; set; }
        public List<File> Files { get; set; }

        public Project(string name,List<File> files)
        {
            Name = name;
            Files = files;
        }
    }
}
