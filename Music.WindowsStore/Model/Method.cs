using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.WindowsStore.Model
{
    public class Method
    {
        public int Number { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public List<Lesson> Lessons { get; set; }
    }
}
