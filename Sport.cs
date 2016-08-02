using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson56
{
    class Sport
    {
        private static string[] _femaleSport;
        private static string[] _maleSport;

        public string Name { get; set; }
        public int Score { get; set; }
        public string MsgAward { get; set; }

        public static string[] MaleSport { get { return _maleSport; } }
        public static string[] FemaleSport { get { return _femaleSport; } }

        public static void InitBoysSport(params string[] values)
        {
            _maleSport = values;
        }
        public static void InitGirlsSport(params string[] values)
        {
            _femaleSport = values;
        }

    }
}
