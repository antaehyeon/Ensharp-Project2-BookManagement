using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2_BookStore
{
    class Exception
    {
        public Exception()
        {

        } // Constructor


        public int inputData(int num)
        {
            string str;
            str = Console.ReadLine();

            if (ExceptionString(str, num) != -1)
                return Convert.ToInt32(str);
            else
                return -1;
        } // method - Input Method
        
        public int ExceptionString(string str, int num)
        {
            int[] array = new int[num];

            for (int i = 0; i < num; i++)
            {
                array[i] = i + 1;
            }

            for (int i = 0; i < num; i++)
            {
                if (str == Convert.ToString(array[i]))
                    return 0;
            }
            Console.WriteLine("              잘못 입력하셨습니다 :D");
            Console.ReadKey();
            return -1;
        } // method - ExceptionString


        // ID 부분 입력 예외처리를 위해 ASCII 코드를 이용하였습니다
        public string inputString()
        {
            string str;
            str = Console.ReadLine();

            
            if (str.Length > 14)
            {
                Console.WriteLine("14자를 넘을 수 없습니다.");
                Console.ReadKey();
                return "ERROR";
            }

            byte[] strtoASCII = Encoding.ASCII.GetBytes(str);

            if (string.IsNullOrEmpty(str) == true)
            {
                Console.WriteLine("Enter 기호는 입력하실 수 없습니다.");
                Console.ReadKey();
                return "ERROR";
            }
            else if (inputIdFunction(strtoASCII, str.Length))
            {
                return str;
            }
            else
            {
                Console.WriteLine("        잘못 입력하셨습니다.");
                Console.ReadKey();
                return "ERROR";
            }
        } // method - inputString

        // 역시 이름을 입력받을때에도 ASCII 코드를 이용하였습니다
        public string inputName()
        {
            string str;
            str = Console.ReadLine();
            byte[] ASCIILetter = Encoding.ASCII.GetBytes(str);

            if (string.IsNullOrEmpty(str) == true)
            {
                Console.WriteLine("Enter키만 입력할 수 없습니다");
                Console.ReadKey();
                return "ERROR";
            }
            else if (ASCIILetter[0] == 63 && ASCIILetter.Length == 1)
            {
                Console.WriteLine("   한글 2글자 이상으로");
                Console.WriteLine("   입력해주세요");
                Console.ReadKey();
                return "ERROR";
            }
            else if (ASCIILetter[0] == 63 && ASCIILetter[1] == 63)
            {
                return str;
            }
            else
                return "ERROR";
        } // method - inputName

        public string inputPhoneNum(int length)
        {
            string str;
            str = Console.ReadLine();

            if (str.Length > length)
            {
                return "ERROR";
            }
                
            byte[] ASCIILetter = Encoding.ASCII.GetBytes(str);

            if (string.IsNullOrEmpty(str) == true)
            {
                return "ERROR";
            }
            else if (inputPhoneNumFunction(ASCIILetter, ASCIILetter.Length))
            {
                return str;
            }
            else
                return "ERROR";
        } // method - inputPhoneNumFour

        public bool inputPhoneNumFunction(byte[] array, int length)
        {
            for(int i = 0; i < length; i++)
            {
                if (array[i] >= 48 && array[i] <= 57) { }
                else
                    return false;
            }
            return true;
        } // methond - inputPhoneNumFunction

        public bool inputIdFunction(byte[] array, int length)
        {
            for(int i = 0; i < length; i++)
            {
                if ((array[i] >= 65 && array[i] <= 90)  || //소문자
                    (array[i] >= 97 && array[i] <= 122) || // 대문자
                     array[i] >= 48 && array[i] <= 57)  { } // 숫자
                else
                    return false;
            }
            return true;
        } // method - intputIdFunction


    } // class Exception
}
