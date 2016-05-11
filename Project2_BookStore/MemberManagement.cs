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

        string ID;
        string name;
        string phoneNum;
        string PW;

        public MemberManagement()
        {
            exception = new Exception();
            print = new Print();
            sd = SharingData.GetInstance();

        } 

        public void start()
        {
            while (true)
            {
                switch (print.moveArrow(20, 4, 6))
                {
                    case 6: // 회원등록
                        registerID(1);
                        break;
                    case 7: // 회원수정
                        break;
                    case 8: // 회원삭제
                        break;
                    case 9: // 회원검색
                        break;
                    case 10: // 멤버출력
                        break;
                    case 11: // 뒤로가기
                        break;
                } 
            } 
        }

        public void registerID(int mode)
        {
            if (mode == 1) // ID 입력받기
            {
                print.enterIdMessage();
                ID = Console.ReadLine();
                if (ID == "b") this.start(); // 뒤로가기
                if (string.IsNullOrWhiteSpace(ID)) // 문자열이 공백이거나 NULL 일경우
                {
                    print.idIsNullMessage(); // ERROR
                    this.registerID(1); // 재귀
                }
                if (!exception.stringLength(ID, 14)) // 입력받은 문자의 길이가 14를 넘는조건
                {
                    print.LengthOverMessage(); // ERROR
                    this.registerID(1); 
                }
                if (!exception.stringCheck(ID, 1)) // 영어와 숫자만 들어가있는지 판별
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
            }

            if(mode == 2) // 패스워드 입력받기
            {
                string tempPW;

                print.enterPwMessage();
                PW = Console.ReadLine();
                if (PW == "b") this.start();
                print.checkPwMessage();
                tempPW = Console.ReadLine();
                if (PW == "b") this.start();

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
            }

            if (mode == 3) // 이름 입력받기
            {
                print.enterName();
                name = Console.ReadLine();
                if (name == "b") this.start();
                if (!exception.stringCheck(name, 2))
                {
                    print.nameErrorMessage();
                    this.registerID(3);
                }
            }

            if (mode == 4) // 핸드폰번호 입력받기
            {
                print.enterPhoneNum();
                phoneNum = Console.ReadLine();
                if (phoneNum == "b") this.start();
                if (!exception.stringCheck(phoneNum, 3))
                {
                    print.phoneNumLengthOverMessage();
                    this.registerID(4);
                }
            }
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
       
    } // Class - Management
}
