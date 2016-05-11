using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2_BookStore
{
    class Exception
    {
        public Exception() { } 


        // param : 입력받은 숫자에 따라서 문자열의 길이를 제한한다
        // true : 조건충족
        // false : 문자열의 길이가 입력받은 숫자보다 큼
        public bool stringLength(string str, int param)
        {
            if (str.Length > param) return true;
            else                    return false;
        }

        // 아이디 입력받을때 예외처리
        // MODE 1 : (영어, 숫자 6-14자 제한)
        // MODE 2 : (한글만, 2-6자 제한)
        // MODE 3 : (숫자만, 10~11자 제한)
        public bool stringCheck(string str, int mode)
        {
            string sParttern = "";
            switch (mode)
            {
                case 1: // ID쪽 (영어,숫자, 6-14자 제한)
                    sParttern = "^[a-z0-9]{6,14}$";
                    break;
                case 2: // 이름쪽 (한글만, 2-6자 제한)
                    sParttern = "^[가-힣]{2,6}$";
                    break;
                case 3: // 핸드폰번호쪽 (숫자만, 10~11자 제한)
                    sParttern = "^[0-9]{10,11}$";
                    break;
            }

            if (System.Text.RegularExpressions.Regex.IsMatch(str, sParttern)) return false;
            else return true;
        }

        public bool stringFirstLetterCheck(string str)
        {
            byte[] strToASCII = Encoding.ASCII.GetBytes(str);
            if (strToASCII[0] >= 48 && strToASCII[0] <= 57)
            {
                return true;
            }
            return false;
        }

      
    } // Class - Exception
}
