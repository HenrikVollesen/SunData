using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SunData
{
    internal class Util
    {
        private static ProgressBar? progressBar1;

        public static DateTime wholeDay(DateTime day)
        {
            return new DateTime(day.Year, day.Month, day.Day);
        }

        public static void InitProgressBar(int index, ProgressBar bar, bool visible = true)
        {
            if (index == 1)
            {
                if (progressBar1 == null)
                    progressBar1 = bar;
                progressBar1.Visible = visible;
            }
        }

        public static void SetProgressBar(int index, int prog, int max = 100)
        {
            if (index == 1)
            {
                if (progressBar1 != null)
                {
                    if (max != 100)
                    {
                        progressBar1.Maximum = max;
                    }
                    progressBar1.Value = prog;
                    progressBar1.Refresh();
                }
            }
        }

    }
}
