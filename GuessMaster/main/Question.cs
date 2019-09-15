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
                string result = "<:::\00xQ::" + question + "\0:" + cases.Count + ";\0";
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

        public Question(string code)
        {
            if (code.StartsWith("<:::\00xQ::"))
            {
                code = code.Remove(0, 10); //remove '<:::\00xQ::' - start value
                question = code.Substring(0, code.IndexOf('\0')); //get question
                code = code.Remove(0, code.IndexOf('\0') + 1); //remove question and '\0'
                if (code[0] != ':') throw new FormatException("Continue after question is not found");
                code = code.Remove(0, 1); //remove ':'

            }
            else
            {
                throw new FormatException("Start of bytecode is not right");
            }
        }
    }
}
