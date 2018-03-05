using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using IniParser;


namespace TestAutoit.ReadsFiles
{
   public class Readersfile
    {
        public FileIniDataParser Parse = new FileIniDataParser();

        public string[] Filesreadinn()
        {
           
            var data =  Parse.ReadFile(Path.GetFullPath( @"UseFiles\Config.ini"));
            string inn = data[@"Param"][@"INN"];
            string[] innsplit = Regex.Split(inn,":");
            return innsplit;
        }

        public void Filewrite(string inns)
        {
            var data = Parse.ReadFile(Path.GetFullPath(@"UseFiles\Config.ini"));
            string inn = data[@"Param"][@"INNOTH"];
            data[@"Param"][@"INNOTH"] =String.Format(inn+"/{0}",inns);
            Parse.WriteFile(Path.GetFullPath(@"UseFiles\Config.ini"),data);
        }

        public string[] Filesreadinnprint()
        {
            var data = Parse.ReadFile(Path.GetFullPath(@"UseFiles\Config.ini"));
            string inn = data[@"Param"][@"INNFILE"];
            string[] innsplit = Regex.Split(inn, ":");
            return innsplit;
        }

    }
}
