using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Music.WindowsStore.Model
{
    public class Lesson
    {
        public string SubTitle { get; set; }
        public string Information { get; set; }
        public string File_Name { get; set; }

        public string NextLessonFile { get; set; }
        public string PreviousLessonFile { get; set; }

        public IEnumerable<Description> Descriptions { get; set; }
    }
}
