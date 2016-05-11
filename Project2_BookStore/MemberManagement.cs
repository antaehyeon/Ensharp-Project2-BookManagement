using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2_BookStore
{
    class MemberManagement
    {
        private Print print;
        private Exception exception;
        private SharingData sd;
        private Run run;

        string ID;
        string name;
        string phoneNum;
        string PW;

        public MemberManagement(Run run)
        {
            exception = new Exception();
            print = new Print();
            sd = SharingData.GetInstance();
            this.run = run;
        } 

        public void registerID(int mode)
        {
            if (mode == 1) // ID 입력받기
            {
                print.enterIdMessage();
                ID = Console.ReadLine();
                if (ID == "b") run.startMember(); // 뒤로가기
                if (string.IsNullOrWhiteSpace(ID)) // 문자열이 공백이거나 NULL 일경우
                {
                    print.idIsNullMessage(); // ERROR
                    this.registerID(1); // 재귀
                }
                if (ID.Length < 8) // ID가 너무 짧을경우
                {
                    print.lengthNotSatisfyMessage(); // ERROR
                    this.registerID(1);
                }
                if (exception.stringFirstLetterCheck(ID)) // ID 첫문자가 숫자일경우
                {
                    print.idFirstLetterNoNumMessage(); // ERROR
                    this.registerID(1);
                }
                if (exception.stringLength(ID, 14)) // 입력받은 문자의 길이가 14를 넘는조건
                {
                    print.lengthOverMessage(); // ERROR
                    this.registerID(1); 
                }
                if (exception.stringCheck(ID, 1)) // 영어와 숫자만 들어가있는지 판별
                {
                    print.onlyEnglishAndNumMessage(); // ERROR
                    this.registerID(1);
                }
                for (int i = 0; i < sd.MemberList.Count; i++) // 등록되있는 Member List 에서
                {
                    if(sd.MemberList[i].MemberID == ID) // ID가 중복되는지 검사
                    {
                        print.duplicationIdMessage(); // ERROR
                        this.registerID(1);
                    }
                }
                mode = 2;
            }

            if(mode == 2) // 패스워드 입력받기
            {
                string tempPW;

                print.enterPwMessage();
                PW = showStarPW();
                if (PW == "b") run.startMember();
                print.checkPwMessage();
                tempPW = showStarPW();
                if (tempPW == "b") run.startMember();

                if (PW != tempPW) // 입력한 두개의 패스워드가 일치하지 않을 때
                {
                    print.disaccordPw(); // ERROR
                    this.registerID(2);
                }
                if(string.IsNullOrWhiteSpace(PW)) // 패스워드가 NULL이거나 공백만 있을경우
                {
                    print.pwIsNullMessage(); // ERROR
                    this.registerID(2);
                }
                mode = 3;
            }           

            if (mode == 3) // 이름 입력받기
            {
                print.enterName();
                name = Console.ReadLine();
                if (name == "b") run.startMember();
                if (exception.stringCheck(name, 2))
                {
                    print.nameErrorMessage();
                    this.registerID(3);
                }
                mode = 4;
            }            

            if (mode == 4) // 핸드폰번호 입력받기
            {
                print.enterPhoneNum();
                phoneNum = Console.ReadLine();
                if (phoneNum == "b") run.startMember();
                if (exception.stringCheck(phoneNum, 3))
                {
                    print.phoneNumLengthOverMessage();
                    this.registerID(4);
                }
                for (int i = 0; i < sd.MemberList.Count; i++)
                {
                    if (phoneNum == sd.MemberList[i].PhoneNum)
                    {
                        print.existsPhoneNumMessage();
                        this.registerID(4);
                    }
                }
            }

            string creatTime = DateTime.Now.ToString();

            MemberVO data = new MemberVO(ID, name, creatTime, PW, phoneNum);
            sd.MemberList.Add(data);
            print.idRegisterSccessMessage();

            run.startMember();
        }

        public void modifyMember()
        {

        }

        public void deleteMember()
        {

        }

        public void searchMember()
        {

        }

        public void printMember()
        {

        }

        public string showStarPW()
        {
            ConsoleKeyInfo key;

            string pass = "";
            do
            {
                key = Console.ReadKey(true);

                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    pass += key.KeyChar;
                    Console.Write("*");
                }
                else
                {
                    if (key.Key == ConsoleKey.Backspace && pass.Length > 0)
                    {
                        pass = pass.Substring(0, (pass.Length - 1));
                        Console.Write("\b \b");
                    }
                }
            }
            while (key.Key != ConsoleKey.Enter);

            return pass;
        } // method - password

    } // Class - Management
}
