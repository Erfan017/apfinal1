using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abcd
{
    class allmethods
    {
        public static bool nationalidcheck(string id)
        {
            bool flag = false;
            if (id.Length == 10)
            {
                char[] komaki = id.ToCharArray();
                if (komaki[0] == '0' && komaki[1] == '0') flag = true;
            }

            return flag;
        }
        public static bool emailcheck(string email)
        {
            bool flag = false; 
            char[] komaki = email.ToCharArray();
            int i = 0;
            while (i < komaki.Length)
            {
                if (komaki[i] == '@') break;
                i++;
            }
            int x = 0;
            for (int j = 0; j < komaki.Length;j++)
            {
                if (komaki[j] == '.') x = j;
            }
            try
            {
                char a=komaki[x + 1];
                if (i > 0 && x > i + 1) flag = true;
            }
            catch (Exception)
            {
            }
            return flag;
        }
        public static bool phonechecker(string number,out string newnumber)
        {
            bool flag = false;
            string x="";
            char[]komaki = number.ToCharArray();
            
;            newnumber = "";
            try
            {
                switch (komaki.Length)
                {
                    case 10:
                        if (komaki[0] == '9')
                        {
                            double.Parse(number);
                            newnumber = "0" + number;
                            flag = true;
                        }
                        
                        break;
                    case 11:
                        if (komaki[1] == '9' && komaki[0]=='0')
                        {
                            double.Parse(number);
                            newnumber =number;
                            flag = true;
                        }
                        
                        break;
                    case 14:
                        if (komaki[0] == '+' && komaki[1] == '9' && komaki[2]=='8' && komaki[3]=='0'&&komaki[4]=='9')
                        {
                            for (int i = 3; i < 14; i++) x += komaki[i];
                            double.Parse(x);
                            newnumber = x;
                            flag = true;
                        }
                        if (komaki[0] == '0' && komaki[1] == '0' && komaki[2] == '9' && komaki[3] == '8' && komaki[4] == '9')
                        {
                            x = "0";
                            for (int i = 4; i < 14; i++) x += komaki[i];
                            double.Parse(x);
                            newnumber = x;
                            flag = true;
                        }
                        break;
                    case 13:
                        if (komaki[0] == '+' && komaki[1] == '9' && komaki[2] == '8' && komaki[3] == '9' )
                        {
                            x = "0";
                            for (int i = 3; i < 13; i++) x += komaki[i];
                            double.Parse(x);
                            newnumber = x;
                            flag = true;
                        }
                        if (komaki[0] == '9' && komaki[1] == '8' && komaki[2] == '0' )
                        {
                            
                            for (int i = 2; i < 13; i++) x += komaki[i];
                            double.Parse(x);
                            newnumber = x;
                            flag = true;
                        }
                        break;
                    case 12:
                        if (komaki[0] == '9' && komaki[1] == '8' && komaki[2] == '9')
                        {
                            x = "0";
                            for (int i = 2; i < 12; i++) x += komaki[i];
                            double.Parse(x);
                            newnumber = x;
                            flag = true;
                        }
                        break;
                    case 15:
                        if (komaki[0] == '0' && komaki[1] == '0' && komaki[2] == '9' && komaki[3] == '8' && komaki[4]=='0')
                        {
                            
                            for (int i = 4; i < 15; i++) x += komaki[i];
                            double.Parse(x);
                            newnumber = x;
                            flag = true;
                        }
                        
                        break;
                }
            }
            catch (Exception)
            {                
            }
            return flag;
        }
        public static int signinid;
    }
}
