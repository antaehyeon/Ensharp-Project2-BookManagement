                                        using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace Project2_BookStore
{
    class Print
    {
        MemberManagement member_manage;
        BookManagement book_manage;
        SharingData sd;

        public Print()
        {
            sd = SharingData.GetInstance();
        }


        // 화살표로 움직일 수 있게 해주는 메소드
        public int moveArrow(int pWidth, int pHeight, int menuNumber, int mode)
        {
            ConsoleKeyInfo cki;
            int width = pWidth, height = pHeight;

            while (true)
            {
                Console.Clear();
                switch (mode)
                {
                    case 1: // 첫화면
                        firstMenu();
                        break;
                    case 2:
                        memberMenu();
                        break;

                }



                Console.SetCursorPosition(width, height);
                Console.Write('→');

                // KEY 의 입력을 받는 부분
                cki = Console.ReadKey(true);
                switch (cki.Key)
                {
                    case ConsoleKey.UpArrow:
                        height--;
                        break;
                    case ConsoleKey.DownArrow:
                        height++;
                        break;
                    case ConsoleKey.Enter:
                        return height;
                }

                // 맨위에서 UpArrow 이벤트가 발생했을 때(즉 위방향키를 눌렀을 때) 맨 아래로 가게해주도록 설계
                if (height == pHeight - 1)
                {
                    height = pHeight + menuNumber - 1;
                }
                else if (height == pHeight + menuNumber)
                {
                    height = pHeight;
                }
            }
        }
        // 메뉴관련 출력
        public void firstMenu()
        {
            // Console 창의 크기를 조절
            Console.SetWindowSize(124, 40);
            Console.Clear();
            title("도서관리 프로그램");

            Console.Write(hangleCenterArrange(124, "[  ] 회원 관리"));
            Console.Write(hangleCenterArrange(124, "[  ] 도서 관리"));
            Console.Write(hangleCenterArrange(124, "[  ] 도서 대여"));
            Console.Write(hangleCenterArrange(124, "[  ] 도서 반납"));
            Console.Write(hangleCenterArrange(124, "[  ] 종     료"));
        } // method - printFirstMenu

        public void memberMenu()
        {
            // Console 창의 크기를 조절
            Console.SetWindowSize(124, 40);
            Console.Clear();
            title("회원 관리");

            Console.Write(hangleCenterArrange(124, "[  ] 회원 등록"));
            Console.Write(hangleCenterArrange(124, "[  ] 회원 수정"));
            Console.Write(hangleCenterArrange(124, "[  ] 회원 삭제"));
            Console.Write(hangleCenterArrange(124, "[  ] 회원 검색"));
            Console.Write(hangleCenterArrange(124, "[  ] 회원 출력"));
            Console.Write(hangleCenterArrange(124, "[  ] 뒤로 가기"));
        } // method - printFirstMenu



        // ID 관련 출력
        public void enterIdMessage()
        {
            Console.Clear();
            title("ID 입력");
            Console.WriteLine("\n 아이디는 8자 ~ 16자까지 가능합니다");
            Console.WriteLine(" 아이디는 영어와 숫자로만 구성이 가능합니다");
            Console.WriteLine(" 아이디는 중복될 수 없습니다");
            Console.WriteLine(" 등록하실 ID를 입력하세요 (뒤로가시려면 b 를 입력하세요)");
            Console.Write(" → ");
        }

        public void lengthNotSatisfyMessage()
        {
            Console.Clear();
            Console.WriteLine("\n\n\n\n");
            title("ID가 너무 짧습니다");
            Console.ReadKey();
        }

        public void idFirstLetterNoNumMessage()
        {
            Console.Clear();
            Console.WriteLine("\n\n\n\n");
            title("ID의 첫 문자는 숫자로 시작할 수 없습니다");
            Console.ReadKey();
        }

        public void lengthOverMessage()
        {
            Console.Clear();    
            Console.WriteLine("\n\n\n\n");
            title("ID는 14자를 초과할 수 없습니다");
            Console.ReadKey();
        }

        public void idIsNullMessage()
        {
            Console.Clear();
            Console.WriteLine("\n\n\n\n");
            title("ID는 NULL 이거나 공백일 수 없습니다");
            Console.ReadKey();
        }

        public void onlyEnglishAndNumMessage()
        {
            Console.Clear();
            Console.WriteLine("\n\n\n\n");
            title("ID는 영어와 숫자로만 구성이 가능합니다");
            Console.ReadKey();
        }

        public void duplicationIdMessage()
        {
            Console.Clear();
            Console.WriteLine("\n\n\n\n");
            title("중복된 ID는 등록하실 수 없습니다");
            Console.ReadKey();
        }

        // PW 관련 출력
        public void enterPwMessage()
        {
            Console.Clear();
            title("패스워드 설정");
            Console.WriteLine("\n 패스워드를 입력하세요 (뒤로 가시려면 b를 눌러주세요)");
            Console.Write(" → ");
        }

        public void disaccordPw()
        {
            Console.Clear();
            Console.WriteLine("\n\n\n\n");
            title("먼저 입력한 패스워드와 일치하지 않습니다");
            Console.ReadKey();
        }

        public void pwIsNullMessage()
        {
            Console.Clear();
            Console.WriteLine("\n\n\n\n");
            title("패스워드는 NULL 이거나 공백일 수 없습니다");
            Console.ReadKey();
        }

        public void checkPwMessage()
        {
            Console.WriteLine("\n 패스워드를 한번 더 입력하세요");
            Console.Write(" → ");
        }

        // 이름 관련 출력
        public void enterName()
        {
            Console.Clear();
            title("이름 입력");
            Console.WriteLine("\n 이름은 2자부터 6자까지 한글로만 가능합니다");
            Console.WriteLine(" 이름을 입력하세요 (뒤로가시려면 b 를 입력하세요)");
            Console.Write(" → ");
        }

        public void nameErrorMessage()
        {
            Console.Clear();
            Console.WriteLine("\n\n\n\n");
            title("이름 제한조건을 다시 확인하세요");
            Console.ReadKey();
        }

        // 핸드폰 관련 출력
        public void enterPhoneNum()
        {
            Console.Clear();
            title("핸드폰번호 입력");
            Console.WriteLine("\n 핸드폰번호는 10-11자리만 가능합니다");
            Console.WriteLine(" 핸드폰번호를 입력하세요 (뒤로가시려면 b 를 입력하세요)");
            Console.Write(" → ");
        }

        public void phoneNumLengthOverMessage()
        {
            Console.Clear();
            Console.WriteLine("\n\n\n\n");
            title("핸드폰번호 자릿수를 지켜주세요");
            Console.ReadKey();
        }

        public void existsPhoneNumMessage()
        {
            Console.Clear();
            Console.WriteLine("\n\n\n\n");
            title("핸드폰번호가 중복됩니다");
            Console.ReadKey();
        }

        // 결과 출력

        public void idRegisterSccessMessage()
        {
            int memberNumber = sd.MemberList.Count();

            Console.Clear();
            title("정상 등록");
            Console.WriteLine("\n");
            Console.WriteLine(" ID : {0}", sd.MemberList[memberNumber - 1].MemberID);
            Console.WriteLine(" 이름 : {0}", sd.MemberList[memberNumber - 1].MemberName);
            Console.WriteLine(" 핸드폰번호 : {0}", sd.MemberList[memberNumber - 1].PhoneNum);
            Console.WriteLine("\n {0} 에 정상적으로 등록되었습니다", sd.MemberList[memberNumber - 1].CreateTime);
            Console.ReadKey();
        }

        // 종료메뉴
        public void exitMessage()
        {
            Console.Clear();
            Console.WriteLine("\n\n\n");
            title("도서관리 프로그램을 종료합니다");
            Environment.Exit(0);
        }

        // length (총길이), strData (문자열) 을 이용해서
        // 문자열 이외의 부분은 공백으로 정렬하는 메소드
        public string hangleLineUp(int length, string strData)
        {
            string strToPrint = strData;
            int gap = length - Encoding.Default.GetBytes(strToPrint).Length;

            return "".PadLeft(gap) + strToPrint;
        }

        // 한글을 가운데 정렬해주는 메소드
        // length 를 이용해서 길이를 계산한다
        public string hangleCenterArrange(int length, string strData)
        {
            string strToPrint = strData;
            int gap = length - Encoding.Default.GetBytes(strToPrint).Length;

            int frontGap = gap / 2;
            int rearGap = gap - frontGap;

            return "".PadRight(frontGap) + strToPrint + "".PadRight(rearGap);
        }

        // 콘솔창 맨위의 TITLE 을 출력해주는 메소드
        // 안의 문구는 자동으로 가운데정렬을 시켜준다
        public void title(string StrData)
        {
            Console.WriteLine("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
            Console.WriteLine("\n{0}\n", hangleCenterArrange(124, StrData));
            Console.WriteLine("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
        }
    } // Class - PrintMenu
}
