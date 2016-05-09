using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace Project2_BookStore
{
    class PrintMenu
    {
        MemberManagement member_manage;
        BookManagement book_manage;

        public PrintMenu()
        {
            member_manage = new MemberManagement(this);
            book_manage = new BookManagement(this, member_manage);
        } // Constructor

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// PRINT

        // 프로그램이 처음 시작하는 부분
        public void start()
        {
            switch (choiceMenu(11, 6, 5, 1)) // Cursor 를 이용한 입력을 int형으로 반환받습니다
            {
                case 6: // 사용자 관리
                    member_manage.start();
                    break;
                case 7: // 도서 관리
                    book_manage.start();
                    break;
                case 8: // 도서 대여
                    book_manage.rentBook();
                    break;
                case 9: // 도서 반납
                    book_manage.returnBook();
                    break;
                case 10: // 프로그램 종료
                    printExit();
                    break;
            } // switch
        } // start method



        //////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// Function



        // 처음 시작하는 부분
        // p = parameter
        public int choiceMenu(int pWidth, int pHeight, int menuNumber, int pMode)
        {
            ConsoleKeyInfo cki;
            int width = pWidth, height = pHeight; // width, height 정보를 이용해 화살표를 찍어줍니다.
            int mode = pMode;

            while (true)
            {
                Console.Clear();
                switch (mode) // 숫자를 이용한 mode 분류
                {
                    case 1: // 처음메뉴 출력
                        printFirstMenu();
                        break;
                    case 2: // 멤버관리메뉴 출력
                        printMemberManagement();
                        break;
                    case 3: // 검색메뉴 출력
                        printSearchMenu();
                        break;
                    case 4: // 수정메뉴 출력
                        printModifyMenu();
                        break;
                    case 5: // 책 관리메뉴 출력
                        printBookManagement();
                        break;
                    case 6: // 책 검색메뉴 출력
                        printSelectBookFind();
                        break;
                    case 7: // 책 수정메뉴 출력
                        printSelectBookModify();
                        break;
                } // mode switch

                Console.SetCursorPosition(width, height);
                Console.Write('→');

                // KEY 를 입력받는 부분입니다
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
                } // cki.key switch

                // 맨 위에서 아래로 가는 기능과 그 반대의 기능을 구현한 부분입니다
                if (height == pHeight - 1)
                {
                    height = pHeight + menuNumber - 1;
                }
                else if (height == pHeight + menuNumber)
                {
                    height = pHeight;
                }
            } // while
        } // choiceMenu method

        // 텍스트 가운데정렬 후 출력
        public void centerArrangement(int length, string str)
        {
            Console.WriteLine(string.Format("{0}", str).PadLeft(length-(length/2-(str.Length / 2))));
        } // center method

        // 처음 선택메뉴 출력
        public void printFirstMenu()
        {
            // Console 창의 크기를 조절
            Console.SetWindowSize(36, 16);

            Console.Clear();

            Console.WriteLine();

            Console.WriteLine("━━━━━━━━━━━━━━━━━━");
            centerArrangement(28, "도서관리 프로그램");
            Console.WriteLine("━━━━━━━━━━━━━━━━━━");

            Console.WriteLine();
            Console.WriteLine(); // \n 을 이용해서 코드를 간략화하기...

            centerArrangement(30, "[  ] 회원 관리");
            centerArrangement(30, "[  ] 도서 관리");
            centerArrangement(30, "[  ] 도서 대여");
            centerArrangement(30, "[  ] 도서 반납");
            centerArrangement(32, "[  ] 종     료");

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("━━━━━━━━━━━━━━━━━━");
        } // method - printFirstMenu

        public void printExit()
        {
            Console.SetWindowSize(60, 12);

            Console.Clear();

            Console.WriteLine();

            Console.WriteLine("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
            centerArrangement(52, "도서관리 프로그램");
            Console.WriteLine("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");

            Console.WriteLine();
            Console.WriteLine();

            centerArrangement(49, "이용해주셔서 감사합니다.");

            Console.WriteLine();
            Console.WriteLine();

            Environment.Exit(0);
        } // method - printExit

        public void printMemberManagement()
        {
            Console.Clear();

            // Console 창의 크기를 조절
            Console.SetWindowSize(36, 16);

            Console.WriteLine();

            Console.WriteLine("━━━━━━━━━━━━━━━━━━");
            centerArrangement(28, "도서관리 프로그램");
            Console.WriteLine("━━━━━━━━━━━━━━━━━━");

            Console.WriteLine();
            Console.WriteLine();

            centerArrangement(30, "[  ] 회원 등록");
            centerArrangement(30, "[  ] 회원 수정");
            centerArrangement(30, "[  ] 회원 삭제");
            centerArrangement(30, "[  ] 회원 검색");
            centerArrangement(30, "[  ] 회원 출력");
            centerArrangement(30, "[  ] 뒤로 가기");

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("━━━━━━━━━━━━━━━━━━");
        } // methond - printMemberManagement

        public void printSearchMenu()
        {
            Console.Clear();

            // Console 창의 크기를 조절
            Console.SetWindowSize(36, 14);

            Console.WriteLine();

            Console.WriteLine("━━━━━━━━━━━━━━━━━━");
            centerArrangement(28, "도서관리 프로그램");
            Console.WriteLine("━━━━━━━━━━━━━━━━━━");

            Console.WriteLine();
            Console.WriteLine();

            centerArrangement(28, "[  ] ID");
            centerArrangement(28, "[  ] 이름");
            centerArrangement(30, "[  ] 핸드폰번호");
            centerArrangement(30, "[  ] 뒤로가기");

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("━━━━━━━━━━━━━━━━━━");
        } // methond - printMemberManagement

        public void printModifyMenu()
        {
            Console.Clear();

            // Console 창의 크기를 조절
            Console.SetWindowSize(36, 14);

            Console.WriteLine();

            Console.WriteLine("━━━━━━━━━━━━━━━━━━");
            centerArrangement(28, "도서관리 프로그램");
            Console.WriteLine("━━━━━━━━━━━━━━━━━━");

            Console.WriteLine();
            Console.WriteLine();

            centerArrangement(28, "[  ] 이름");
            centerArrangement(30, "[  ] 핸드폰번호");
            centerArrangement(30, "[  ] 뒤로가기");

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("━━━━━━━━━━━━━━━━━━");
        } // method - printModifyMenu

        public void printMemberFunction(string mode)
        {
            Console.Clear();

            // Console 창의 크기를 조절
            Console.SetWindowSize(36, 16);

            Console.WriteLine();

            Console.WriteLine("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
            centerArrangement(28, "도서관리 프로그램");
            Console.WriteLine("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");

            Console.WriteLine();
            Console.WriteLine();

            switch(mode)
            {
                case "ADD_ID":
                    Console.Clear();
                    Console.WriteLine();

                    Console.WriteLine("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                    centerArrangement(44, "도서관리 프로그램");
                    Console.WriteLine("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");

                    Console.WriteLine();
                    //Console.SetCursorPosition(0, 5);
                    Console.WriteLine("    등록할 ID를 입력해주세요");
                    Console.WriteLine("    ID는 영어와 숫자조합과 14자 까지만 가능하며");
                    setConsoleColor("    변경 불가합니다");
                    break;
                case "ADD_NAME":
                    centerArrangement(28, "이름을 입력해주세요");
                    Console.WriteLine(" 한글 2글자 이상부터 입력가능합니다");
                    break;
                case "ADD_PHONE_FIRST":
                    Console.WriteLine(" 핸드폰번호 첫번째자리를 입력하세요");
                    Console.Write("         ");
                    setConsoleColor("010");
                    Console.Write(" - 0000 - 0000");
                    break;
                case "ADD_PHONE_MIDDLE":
                    Console.WriteLine(" 핸드폰번호 두번째자리를 입력하세요");
                    Console.Write("         010 - ");
                    setConsoleColor("0000");
                    Console.Write(" - 0000");
                    break;
                case "ADD_PHONE_LAST":
                    Console.WriteLine(" 핸드폰번호 세번째자리를 입력하세요");
                    Console.Write("         010 - 0000 - ");
                    setConsoleColor("0000");
                    break;
                case "DELETE":
                    centerArrangement(26, "삭제할 ID를 입력해주세요");
                    break;
                case "PASSWORD":
                    centerArrangement(26, "패스워드를 입력해주세요");
                    break;
                case "MODIFY_CURRENT":
                    centerArrangement(26, "ID를 입력해주세요");
                    break;
                case "MODIFY_NAME":
                    centerArrangement(26, "수정할 이름을 입력해주세요");
                    break;
                case "SEARCH_ID":
                    centerArrangement(26, "검색할 ID를 입력해주세요");
                    break;
                case "SEARCH_NAME":
                    centerArrangement(26, "검색할 이름을 입력해주세요");
                    break;
                case "SEARCH_NAME_PHONE":
                    Console.SetCursorPosition(0, 5);
                    centerArrangement(27, "이름이 중복됩니다");
                    Console.WriteLine(" 핸드폰번호 세번째자리를 입력하세요");
                    Console.Write("        Ex) 010 - 0000 - ");
                    setConsoleColor("0000");
                    break;
            } // switch str

            Console.SetCursorPosition(10, 8);
            Console.Write("→ ");
        } // printMemberFunction method

        public void printMemberResult(string ID, string name, string phone, string createTime, string mode)
        {
            Console.Clear();

            // Console 창의 크기를 조절
            Console.SetWindowSize(36, 16);

            Console.WriteLine();

            Console.WriteLine("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
            centerArrangement(28, "도서관리 프로그램");
            Console.WriteLine("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");

            Console.WriteLine();
            Console.WriteLine();

            switch (mode)
            {
                case "ADD":
                    Console.WriteLine("    {0}({1}) 님", ID, name);
                    Console.WriteLine("    정상적으로 등록 되었습니다");
                    break;
                case "DELETE":
                    Console.WriteLine("    {0}({1})님", ID, name);
                    Console.WriteLine("    정상적으로 삭제 되었습니다");
                    break;
                case "MODIFY_NAME":
                    Console.WriteLine("    이름이 {0} 에서", ID);
                    Console.WriteLine("           {0} 으로", name);
                    Console.WriteLine("    수정 되었습니다");
                    break;
                case "MODIFY_PHONE":
                    Console.WriteLine("       핸드폰번호가");
                    Console.WriteLine("       {0} 에서", ID);
                    Console.WriteLine("       {0} 으로", phone);
                    Console.WriteLine("       수정 되었습니다");
                    break;
                case "SEARCH":
                    Console.Clear();
                    Console.SetWindowSize(44, 16);
                    Console.WriteLine();

                    Console.WriteLine("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");
                    centerArrangement(36, "도서관리 프로그램");
                    Console.WriteLine("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");

                    Console.WriteLine();
                    Console.WriteLine();

                    Console.WriteLine("    ID : {0}", ID);
                    Console.WriteLine("    이름 : {0}", name);
                    Console.WriteLine("    핸드폰번호 : {0}", phone);
                    Console.WriteLine("    생성일자 : {0}", createTime);

                    Console.WriteLine();
                    Console.WriteLine("━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━");

                    Console.WriteLine();
                    Console.WriteLine("  전 단계로 돌아가려면 아무키나 누르세요");
                    break;
                case "ADD_ERROR":
                    centerArrangement(28, "이미 중복된 ID 입니다");
                    centerArrangement(28, "전 메뉴로 돌아갑니다");
                    break;
                case "ADD_NAME_ERROR":
                    centerArrangement(28, "한글만 입력가능합니다");
                    break;
                case "ADD_NAME_ERROR_2":
                    centerArrangement(28, "한글 2글자 이상으로");
                    centerArrangement(28, "입력해주세요");
                    break;
                case "DELETE_ERROR":
                    centerArrangement(24, "삭제할 ID가 존재하지 않습니다");
                    centerArrangement(28, "전 메뉴로 돌아갑니다");
                    break;
                case "PASSWORD_ERROR":
                    centerArrangement(24, "패스워드가 맞지 않습니다.");
                    centerArrangement(28, "전 메뉴로 돌아갑니다");
                    break;
                case "MODIFY_CURRENT_ERROR":
                    centerArrangement(24, "수정할 ID가 존재하지 않습니다");
                    centerArrangement(28, "전 메뉴로 돌아갑니다");
                    break;
                case "SEARCH_ERROR":
                    centerArrangement(24, "검색한 ID가 존재하지 않습니다");
                    centerArrangement(28, "전 메뉴로 돌아갑니다");
                    break;
                case "SEARCH_NAME_ERROR":
                    centerArrangement(24, "검색한 이름이 존재하지 않습니다");
                    centerArrangement(28, "전 메뉴로 돌아갑니다");
                    break;
                case "SEARCH_PHONE_ERROR":
                    centerArrangement(24, "검색한 번호가 존재하지 않습니다");
                    centerArrangement(28, "전 메뉴로 돌아갑니다");
                    break;
            } // switch str

            Console.ReadKey();

        } // method - printMenuResult


        public void printAddResult(string ID, string name)
        {
            Console.Clear();

            // Console 창의 크기를 조절
            Console.SetWindowSize(36, 16);

            Console.WriteLine();

            Console.WriteLine("━━━━━━━━━━━━━━━━━━");
            centerArrangement(28, "도서관리 프로그램");
            Console.WriteLine("━━━━━━━━━━━━━━━━━━");

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("    {0}({1}) 님", ID, name);
            Console.WriteLine("    정상적으로 등록되었습니다.");

            Console.ReadKey();
        }

        public void printModifyResult(string beforeID, string afterID)
        {
            Console.Clear();

            // Console 창의 크기를 조절
            Console.SetWindowSize(36, 16);

            Console.WriteLine();

            Console.WriteLine("━━━━━━━━━━━━━━━━━━");
            centerArrangement(28, "도서관리 프로그램");
            Console.WriteLine("━━━━━━━━━━━━━━━━━━");

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("    {0} 님에서", beforeID);
            Console.WriteLine("    {0} 님으로", afterID);
            Console.WriteLine("    수정 되었습니다");

            Console.ReadKey();
        } // method - printModifyResult

        public void setConsoleColor(string str)
        {
            var Color = ConsoleColor.Red;
            Console.ForegroundColor = Color;

            Console.Write(str);
            Console.ResetColor();
        } // method - setConsoleColor

        public void printMemberList(List<string> creatTime, List<string> id, List<string> name, List<string> FirstPNum, List<string> MidPNum, List<string> LastPNum)
        {
            int count = 0;
            int height = 8;

            foreach(string str in creatTime)
            {
                count++;
                height += 2;
            } // foreach - creatTime

            Console.Clear();
            Console.SetWindowSize(80, height);

            Console.WriteLine("┏━━━━━━━━━━━━┳━━━━━━━━┳━━━━━━━┳━━━━━━━┓");
            Console.Write("┃");
            Console.Write("        생성 시간       ");
            Console.Write("┃");
            Console.Write("       ID       ");
            Console.Write("┃");
            Console.Write("     이름     ");
            Console.Write("┃");
            Console.Write("  핸드폰 번호 ");
            Console.WriteLine("┃");

            for (int i = 0; i < count; i++)
            {
                string strToPrint = name[i];
                int padLen = 14 - Encoding.Default.GetBytes(strToPrint).Length;

                Console.WriteLine("┣━━━━━━━━━━━━╋━━━━━━━━╋━━━━━━━╋━━━━━━━┫");
                Console.Write("┃");
                Console.Write(string.Format("{0,-22}", creatTime[i]));
                Console.Write(string.Format("┃{0,-16}", id[i]));
                Console.Write("┃{0}", strToPrint + "".PadRight(padLen));
                Console.Write(string.Format("┃{0,-3}", FirstPNum[i]));
                Console.Write(string.Format("-{0,-4}", MidPNum[i]));
                Console.Write(string.Format("-{0,-5}", LastPNum[i]));
                Console.WriteLine("┃");
            }
            Console.WriteLine("┗━━━━━━━━━━━━┻━━━━━━━━┻━━━━━━━┻━━━━━━━┛");
        } // method - printMemberList

        /// <summary>
        /// ////////////////////////////////////////////////// BOOK MANAGEMENT //////////////////////////////////////////////////////////
        /// </summary>

        public void printBookManagement()
        {
            Console.SetWindowSize(52, 16);

            Console.Clear();

            Console.WriteLine();

            Console.WriteLine("━━━━━━━━━━━━━━━━━━━━━━━━━━");
            centerArrangement(44, "도서관리 프로그램");
            Console.WriteLine("━━━━━━━━━━━━━━━━━━━━━━━━━━");

            Console.WriteLine();
            Console.WriteLine();

            centerArrangement(46, "[  ] 도서 등록");
            centerArrangement(46, "[  ] 도서 찾기");
            centerArrangement(46, "[  ] 도서 출력");
            centerArrangement(46, "[  ] 도서 삭제");
            centerArrangement(46, "[  ] 도서 변경");
            centerArrangement(46, "[  ] 뒤로 가기");

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("━━━━━━━━━━━━━━━━━━━━━━━━━━");
        } // method - printBookManagement

        public void printSelectBookFind()
        {
            Console.SetWindowSize(52, 16);

            Console.Clear();

            Console.WriteLine();

            Console.WriteLine("━━━━━━━━━━━━━━━━━━━━━━━━━━");
            centerArrangement(44, "도서관리 프로그램");
            Console.WriteLine("━━━━━━━━━━━━━━━━━━━━━━━━━━");

            Console.WriteLine();
            Console.WriteLine();

            centerArrangement(44, "무엇으로 찾을지 선택하세요");
            centerArrangement(50, "[  ] 책  이름");
            centerArrangement(50, "[  ] 책  저자");
            centerArrangement(50, "[  ] 뒤로가기");

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("━━━━━━━━━━━━━━━━━━━━━━━━━━");
        } // method - printBookManagement


        public void printBookManageFunction(string mode)
        {
            Console.SetWindowSize(52, 16);

            Console.Clear();

            Console.WriteLine();

            Console.WriteLine("━━━━━━━━━━━━━━━━━━━━━━━━━━");
            centerArrangement(44, "도서관리 프로그램");
            Console.WriteLine("━━━━━━━━━━━━━━━━━━━━━━━━━━");

            Console.WriteLine();
            Console.WriteLine();

            switch(mode)
            {
                case "ADD_BOOK":
                    centerArrangement(36, "등록할 책 이름을 입력해주세요");
                    break;
                case "ADD_BOOK_AUTHOR":
                    centerArrangement(36, "책 저자의 이름을 입력해주세요");
                    break;
                case "ADD_BOOK_PRICE":
                    centerArrangement(42, "책 가격을 입력해주세요");
                    break;
                case "ADD_BOOK_QUANTITY":
                    centerArrangement(42, "책 수량을 입력해주세요");
                    break;
                case "FIND_BOOK_NAME":
                    centerArrangement(36, "찾으실 책 이름을 입력해주세요");
                    break;
                case "FIND_BOOK_AUTHOR":
                    centerArrangement(34, "찾으실 책 저자이름을 입력해주세요");
                    break;
                case "DELETE_BOOK":
                    centerArrangement(34, "삭제할 책 이름을 입력해주세요");
                    break;
                case "MODIFY_BOOK":
                    centerArrangement(34, "수정할 책 이름을 입력해주세요");
                    break;
                case "MODIFY_BOOK_WHAT":
                    centerArrangement(34, "무엇으로 수정하시겠습니까?");
                    break;
                case "RENT_BOOK_NAME":
                    centerArrangement(34, "대여할 책 이름을 입력해주세요");
                    break;
                case "RENT_BOOK_ID":
                    centerArrangement(38, "ID로 책을 빌리실 수 있습니다");
                    centerArrangement(42, "ID를 입력해주세요");
                    break;
                case "RENT_BOOK_PW":
                    centerArrangement(38, "비밀번호를 입력해주세요");
                    break;
                case "RETURN_BOOK_NAME":
                    centerArrangement(38, "반납할 책 이름을 입력해주세요");
                    break;
            } // switch - mode

            Console.SetCursorPosition(16, 8);
            Console.Write("→ ");

        } // method - printBookManageFunction

        public void printBookManageResult(string name, string author, int price, int quantity, string mode)
        {
            Console.SetWindowSize(52, 16);

            Console.Clear();

            Console.WriteLine();

            Console.WriteLine("━━━━━━━━━━━━━━━━━━━━━━━━━━");
            centerArrangement(44, "도서관리 프로그램");
            Console.WriteLine("━━━━━━━━━━━━━━━━━━━━━━━━━━");

            Console.WriteLine();
            Console.WriteLine();

            switch (mode)
            {
                case "ADD_BOOK_RESULT":
                    centerArrangement(36, "정상적으로 등록되었습니다");
                    break;
                case "FIND_BOOK_RESULT":
                    centerArrangement(38, "찾으신 책에 대한 결과입니다");
                    Console.WriteLine("              책 이름 : {0}", name);
                    Console.WriteLine("              책 저자 : {0}", author);
                    Console.WriteLine("              가   격 : {0}", price);
                    Console.WriteLine("              수   량 : {0}", quantity);

                    Console.WriteLine();
                    Console.WriteLine();

                    Console.WriteLine("━━━━━━━━━━━━━━━━━━━━━━━━━━");
                    break;
                case "DELETE_BOOK_RESULT":
                    centerArrangement(38, "책이 정상적으로 삭제되었습니다");
                    break;
                case "MODIFY_BOOK_RESULT":
                    centerArrangement(38, "책이 정상적으로 수정되었습니다");
                    break;
                case "FIND_BOOK_NAME_ERROR":
                    centerArrangement(38, "수정할 책이 존재하지 않습니다");
                    centerArrangement(40, "메인메뉴로 돌아갑니다");
                    break;
                case "FIND_BOOK_AUTHOR_ERROR":
                    centerArrangement(38, "책의 저자가 존재하지 않습니다");
                    centerArrangement(40, "메인메뉴로 돌아갑니다");
                    break;
                case "NOT_EXIST_ID":
                    centerArrangement(38, "입력하신 ID가 존재하지 않습니다");
                    break;
                case "INCORRECT_PASSWORD":
                    centerArrangement(38, "입력하신 패스워드가 맞지 않습니다");
                    break;
                case "RENT_OK":
                    Console.WriteLine("         {0} 이 정상적으로 대여되었습니다", name);
                    break;
                case "BOOK_STATE_NORENT":
                    centerArrangement(38, "책이 대여상태가 아닙니다");
                    break;
                case "RETURN_OK":
                    Console.WriteLine("         {0} 이 정상적으로 반납되었습니다", name);
                    break;
            } //switch - mode
            Console.ReadKey();
        } // method - printBookManageResult

        public void printBookList(List<string> name, List<string> author, List<int> price, List<int> quantity, List<string> creatTime, List<string> rentID)
        {
            int count = 0;
            int height = 8;

            foreach (string str in name)
            {
                count++;
                height += 2;
            } // foreach - creatTime

            Console.Clear();
            Console.SetWindowSize(124, height);

            Console.WriteLine("┏━━━━━━━━━━┳━━━━━━━━━━┳━━━━━━━┳━━━━━━━┳━━━━━━━━━━━━┳━━━━━━━━┓");
            Console.Write("┃");
            Console.Write("       책 이름      ");
            Console.Write("┃");
            Console.Write("       책 저자      ");
            Console.Write("┃");
            Console.Write("    가  격    ");
            Console.Write("┃");
            Console.Write("    수  량    ");
            Console.Write("┃");
            Console.Write("       대여 시간        ");
            Console.Write("┃");
            Console.Write("   대여한사람   ");
            Console.WriteLine("┃");

            for (int i = 0; i < count; i++)
            {
                string nameToPrint = name[i];
                int nameLength = 20 - Encoding.Default.GetBytes(nameToPrint).Length;

                string authorToPrint = author[i];
                int authorLength = 20 - Encoding.Default.GetBytes(authorToPrint).Length;

                string timeToPrint = creatTime[i];
                int creatTimeLength = 24 - Encoding.Default.GetBytes(timeToPrint).Length;

                Console.WriteLine("┣━━━━━━━━━━╋━━━━━━━━━━╋━━━━━━━╋━━━━━━━╋━━━━━━━━━━━━╋━━━━━━━━┫");
                Console.Write("┃");
                Console.Write("{0}", nameToPrint + "".PadRight(nameLength));
                Console.Write("┃{0}", authorToPrint + "".PadRight(authorLength));
                Console.Write(string.Format("┃{0, 14}", price[i]));
                Console.Write(string.Format("┃{0, 14}", quantity[i]));
                Console.Write("┃{0}", timeToPrint + "".PadRight(creatTimeLength));
                Console.Write("┃{0, -16}", rentID[i]);

                Console.WriteLine("┃");
            }
            Console.WriteLine("┗━━━━━━━━━━┻━━━━━━━━━━┻━━━━━━━┻━━━━━━━┻━━━━━━━━━━━━┻━━━━━━━━┛");

            Console.ReadKey();
        } // method - printMemberList

        public void printSelectBookModify()
        {
            //Console.SetWindowSize(52, 16);

            Console.Clear();

            Console.WriteLine();

            Console.WriteLine("━━━━━━━━━━━━━━━━━━━━━━━━━━");
            centerArrangement(44, "도서관리 프로그램");
            Console.WriteLine("━━━━━━━━━━━━━━━━━━━━━━━━━━");

            Console.WriteLine();
            centerArrangement(42, "수정할 항목을 선택하세요");
            Console.WriteLine();

            centerArrangement(46, "[  ] 도서 명");
            centerArrangement(46, "[  ] 도서 저자");
            centerArrangement(46, "[  ] 도서 가격");
            centerArrangement(46, "[  ] 도서 수량");
            centerArrangement(46, "[  ] 전체 수정");
            centerArrangement(46, "[  ] 뒤로 가기");

            Console.WriteLine();
            Console.WriteLine("━━━━━━━━━━━━━━━━━━━━━━━━━━");
        } // Method - printSelectBookModify


    } // PrintMenu Class
}
