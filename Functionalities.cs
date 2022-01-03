using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SearchMultiplePDFFiles
{
    public partial class PDFSearcher : Form
    {
        private List<object> FindAllOf(string haystack, string needle)
        {
            var retval = new List<object>();

            int index = 0;
            int pos = 0;

            while ( index != -1)
            {
                index = haystack.IndexOf(needle, pos);

                if (index != -1)
                {
                    retval.Add(haystack.Substring(index, needle.Length));
                    pos = index + needle.Length + 1;
                }
            }

            return retval;
        }
    }
}
