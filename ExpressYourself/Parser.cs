using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExpressYourself
{
    public class Parser
    {
        /// <summary>
        /// Looks for a title in a Media file string.
        /// </summary>
        /// <param name="str">The string to search</param>
        /// <returns>the title string if it exists</returns>
        public static string GetTitle(string str)
        {
            var titleExpression = new Regex(@"title\: (.*),+");
            var match = titleExpression.Match(str);
            if (!match.Success)
            {
                return "NOT FOUND";
            }
            else
            {
                return match.Groups[1].Value;
            }
        }

        public static string GetType(string str)
        {
            var typeExpression = new Regex(@"(\b[A-Z]*[a-z]*),Title+\: .*,Length+\: [0-9]*[a-z]* [0-9]*[a-z]*");
            var match = typeExpression.Match(str);
            if (!match.Success)
            {
                return "LOL";
            }
            else
            {
                return match.Groups[1].Value;
            }
        }

        public static string GetLength(string str)
        {
            var numberExpression = new Regex(@"\b[A-Z]*[a-z]*,Title+\: .*,Length+\: ([0-9]*[a-z]* [0-9]*[a-z]*)");
            var match = numberExpression.Match(str);
            if (!match.Success)
            {
                return "LOL";
            }
            else
            {
                return match.Groups[1].Value;
            }
        }

        public static bool IsValidLine(string str)
        {
            var lineValue = new Regex(@"\b[A-Z]*[a-z]*,Title+\: .*,Length+\: [0-9]*[a-z]* [0-9]*[a-z]*");
            var match = lineValue.Match(str);
            if (!match.Success)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
