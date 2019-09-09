using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuessMaster.main
{
    public class Question
    {
        public Dictionary<string, bool> cases;
        public string question;

        public Question()
        {
            question = "";
            cases = new Dictionary<string, bool>();
        }

        public string ToByteCode()
        {
            return "";
        }
    }
}
