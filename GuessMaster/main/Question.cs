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

        public string ToByteCode
        {
            get
            {
                string result = "<:::\00xQ::" + question + ':' + cases.Count + ";\0";
                foreach (KeyValuePair<string, bool> pair in cases)
                {
                    result += "0xQQ:::" + pair.Key + ":::(a)\0-\0";
                    if (pair.Value)
                    {
                        result += "\\o";
                    }
                    else
                    {
                        result += "\\g";
                    }
                    result += "\0%;";
                }
                return result + "kjlkm:::>";
            }
        }
    }
}
