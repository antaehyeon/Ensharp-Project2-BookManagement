using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2_BookStore
{
    class BookManagement
    {
        PrintMenu printmenu;
        MemberManagement membermanage;
        private List<string> bookName;
        private List<string> bookAuthor;
        private List<int> bookPrice;
        private List<int> bookQuantity;
        private List<string> bookRentTime;
        private List<string> bookRentID;

        public BookManagement(PrintMenu printmenu, MemberManagement membermanage)
        {
            this.printmenu = printmenu;
            this.membermanage = membermanage;
            bookName = new List<string>();
            bookAuthor = new List<string>();
            bookPrice = new List<int>();
            bookQuantity = new List<int>();
            bookRentTime = new List<string>();
            bookRentID = new List<string>();
        } // Constructor


        // 1. 도서 등록
        // 2. 도서 찾기
        // 3. 도서 출력
        // 4. 도서 삭제
        // 5. 도서 변경
        // 6. 뒤로 가기
        public void start()
        {
            int inputNum;
            while (true)
            {
                inputNum = printmenu.choiceMenu(19, 6, 6, 5);

                switch (inputNum)
                {
                    // 1. 도서 등록
                    case 6:
                        addBook();
                        addBookAuthor();
                        addBookPrice();
                        addBookQuantity();
                        addBookRentTime();
                        bookRentWho();
                        printmenu.printBookManageResult(null, null, 0, 0, "ADD_BOOK_RESULT");
                        break;
                    // 2. 도서 찾기
                    case 7:
                        bookFind();
                        break;
                    // 3. 도서 출력
                    case 8:
                        printmenu.printBookList(bookName, bookAuthor, bookPrice, bookQuantity, bookRentTime, bookRentID);
                        break;
                    // 4. 도서 삭제
                    case 9:
                        deleteBook();
                        break;
                    // 5. 도서 변경
                    case 10:
                        changeBook();
                        break;
                    // 6. 뒤로 가기
                    case 11:
                        printmenu.start();
                        break;
                } // switch - inputNum
            } // while
        } // method - start

        // 1-1. 도서명 (string)
        // 책 글자 15자제한
        // 특수문자 불가
        public void addBook()
        {
            string inputBookName;

            printmenu.printBookManageFunction("ADD_BOOK");
            inputBookName = Console.ReadLine();
            bookName.Add(inputBookName);
        } // method - addBook

        // 1-2. 도서저자 (string)
        // 한글과 영어만 가능
        // 특수문자 숫자 불가능
        public void addBookAuthor()
        {
            string inputBookAuthor;

            printmenu.printBookManageFunction("ADD_BOOK_AUTHOR");
            inputBookAuthor = Console.ReadLine();
            bookAuthor.Add(inputBookAuthor);
        } //metohd - addBookAuthor

        // 1-3. 가격 (int)
        // 숫자만 가능
        // 100만원까지만 가능
        public void addBookPrice()
        {
            string inputBookPrice;

            printmenu.printBookManageFunction("ADD_BOOK_PRICE");
            inputBookPrice = Console.ReadLine();
            bookPrice.Add(Convert.ToInt32(inputBookPrice));
        } // method - addBookPrice

        // 1-4. 수량
        // 숫자만 가능(int)
        // 수량 제한 99개
        public void addBookQuantity()
        {
            string inputbookQuantity;

            printmenu.printBookManageFunction("ADD_BOOK_QUANTITY");
            inputbookQuantity = Console.ReadLine();
            bookQuantity.Add(Convert.ToInt32(inputbookQuantity));
        } // method - addBookQuantity

        // 1-5. 책이 빌려진 시간
        // 이 데이터는 대여할 때 쓰는것인데 index에 미리 내용을 채워넣어 Insert 함수를 사용할때 에러를 방지하기 위함임
        public void addBookRentTime()
        {
            bookRentTime.Add("");
        }

        // 1-6. 책을 누가빌려갔는지 
        // 이 데이터도 대여할 떄 쓰는것인데 이유는 addBookRentTime 과 같음
        public void bookRentWho()
        {
            bookRentID.Add("");
        }


        // 하기전에 도서명을 입력받을것인지, 저자를 입력받을것인지 switch
        public void bookFind()
        {
            int selectNum;

            selectNum = printmenu.choiceMenu(21, 7, 3, 6);

            switch (selectNum)
            {
                case 7: // 이름
                    bookFindName();
                    break;
                case 8: // 저자
                    bookFindAuthor();
                    break;
                case 9:
                    this.start();
                    break;
            } // switch - choicemenu


        } // method - bookFind

        // 2-1. 도서명을 입력받는다
        //      도서명으로 bookName 의 list에서 index를 찾는다
        //          예외처리
        //          책 이름이 중복될 수도 있으나 일단은.. 고려안함
        //          -1 : 책이 존재하지 않음
        //      위의 index 로 전부 출력해준다

        public void bookFindName()
        {
            string inputBookName;
            int index = 0;

            printmenu.printBookManageFunction("FIND_BOOK_NAME");
            inputBookName = Console.ReadLine();        
            index = findIndex(bookName, inputBookName);

            if(index == -1)
            {
                printmenu.printBookManageResult(null, null, 0, 0, "FIND_BOOK_NAME_ERROR");
                return;
            }
            printmenu.printBookManageResult(bookName[index], bookAuthor[index], bookPrice[index], bookQuantity[index], "FIND_BOOK_RESULT");
        } // method - bookFindName

        // 2-2. 저자를 입력받는다
        //      저자에 해당하는 index를 전부 구한다(중복적으로 index list 에 저장)
        //          예외처리
        //          -1 : 책이 존재하지 않음
        //      index 와 list.count 를 가지고 전부 출력해준다
        public void bookFindAuthor()
        {
            string inputBookAuthor;
            int index = 0;

            printmenu.printBookManageFunction("FIND_BOOK_AUTHOR");
            inputBookAuthor = Console.ReadLine();
            index = findIndex(bookAuthor, inputBookAuthor);

            if (index == -1)
            {
                printmenu.printBookManageResult(null, null, 0, 0, "FIND_BOOK_AUTHOR_ERROR");
                return;
            }
            printmenu.printBookManageResult(bookName[index], bookAuthor[index], bookPrice[index], bookQuantity[index], "FIND_BOOK_RESULT");
        } // method - bookFindAuthor

        // 4-1. 삭제할 도서명을 입력받는다
        //      도서명의 index 를 찾는다
        //          예외처리
        //          -1 : 책이 존재하지 않음
        //      index 와 list.count 를 이용해 전부 삭제시킨다
        public void deleteBook()
        {
            int index;
            string inputDeleteBookName;

            printmenu.printBookManageFunction("DELETE_BOOK");
            inputDeleteBookName = Console.ReadLine();
            index = findIndex(bookName, inputDeleteBookName);

            if (index == -1)
            {
                printmenu.printBookManageResult(null, null, 0, 0, "FIND_BOOK_NAME_ERROR");
                return;
            }
            deleteBookFunction(index, bookName, bookAuthor, bookPrice, bookQuantity);
            printmenu.printBookManageResult(null, null, 0, 0, "DELETE_BOOK_RESULT");
        } // method - deleteBook

        // 5-1. 변경할 도서명을 입력받는다
        //      index를 찾는다
        //          예외처리
        //          -1 : 책이 존재하지 않는다
        //      무엇을 변경할지 입력받는다
        //          1. 책 이름
        //          2. 책 저자
        //          3. 가격
        //          4. 수량
        //          5. 전체
        public void changeBook()
        {
            int selectNum, index;
            string inputBookName;
            string returnString;

            printmenu.printBookManageFunction("MODIFY_BOOK");
            inputBookName = Console.ReadLine();
            index = findIndex(bookName, inputBookName);

            if(index == -1)
            {
                printmenu.printBookManageResult(null, null, 0, 0, "FIND_BOOK_NAME_ERROR");
                return;
            }

            selectNum = printmenu.choiceMenu(19, 7, 6, 7);

            switch (selectNum)
            {
                case 7: // 책 이름
                    returnString = changeBookName(index);
                    if(returnString == "SUCCESS") { printmenu.printBookManageResult(null, null, 0, 0, "MODIFY_BOOK_RESULT"); }
                    break;
                case 8: // 책 저자
                    returnString = changeBookAuthor(index);
                    if (returnString == "SUCCESS") { printmenu.printBookManageResult(null, null, 0, 0, "MODIFY_BOOK_RESULT"); }
                    break;
                case 9: // 가격
                    returnString = changeBookPrice(index);
                    if (returnString == "SUCCESS") { printmenu.printBookManageResult(null, null, 0, 0, "MODIFY_BOOK_RESULT"); }
                    break;
                case 10: // 수량
                    returnString = changebookQuantity(index);
                    if (returnString == "SUCCESS") { printmenu.printBookManageResult(null, null, 0, 0, "MODIFY_BOOK_RESULT"); }
                    break;
                case 11: // 전체
                    returnString = changeAll(index);
                    if (returnString == "SUCCESS") { printmenu.printBookManageResult(null, null, 0, 0, "MODIFY_BOOK_RESULT"); }
                    break;
                case 12: // 뒤로가기
                    this.start();
                    break;
            } // switch - selectNum
        } // method - changeBook

        // 5-1-1. 책이름 (인자로는 index 를 받는다)
        //        수정할 책 이름을 입력받는다
        //        인자로 받은 index의 List 에 접근해서 입력받은 데이터를 대입시킨다
        //        문구출력
        public string changeBookName(int index)
        {
            string inputBookName;
            printmenu.printBookManageFunction("MODIFY_BOOK_WHAT");

            inputBookName = Console.ReadLine();

            bookName[index] = inputBookName;

            return "SUCCESS";
        } // method - changeBookName

        // 5-1-2. 책 저자
        public string changeBookAuthor(int index)
        {
            string inputBookAuthor;
            printmenu.printBookManageFunction("ADD_BOOK_AUTHOR");

            inputBookAuthor = Console.ReadLine();

            bookAuthor[index] = inputBookAuthor;

            return "SUCCESS";
        } // metohd - changeBookAuthor

        // 5-1-3. 책 가격
        public string changeBookPrice(int index)
        {
            string inputBookPrice;
            printmenu.printBookManageFunction("ADD_BOOK_PRICE");

            inputBookPrice = Console.ReadLine();

            bookPrice[index] = Convert.ToInt32(inputBookPrice);

            return "SUCCESS";
        } // metohd - changeBookPrice

        // 5-1-4. 책 수량
        public string changebookQuantity(int index)
        {
            string inputbookQuantity;
            printmenu.printBookManageFunction("ADD_BOOK_QUANTITY");

            inputbookQuantity = Console.ReadLine();

            bookQuantity[index] = Convert.ToInt32(inputbookQuantity);

            return "SUCCESS";
        } // changeBookQuantitiy

        public string changeAll(int index)
        {
            changeBookName(index);
            changeBookAuthor(index);
            changeBookPrice(index);
            changebookQuantity(index);

            return "SUCCESS";
        } // changeAll

        // 해당 요소의 index 를 찾는다
        // -1 : 해당하는 요소가 없을시
        public int findIndex(List<string> list, string inputData)
        {
            int count = 0;
            foreach (string str in list)
            {
                if (str == inputData)
                {
                    return count;
                }
                count++;
            } // foreach
            return -1;
        } // method - findIndex

        // List[index] 를 이용해 전부 삭제한다
        public void deleteBookFunction(int index, List<string> bookName, List<string> bookAuthor, List<int> price, List<int> quantitiy)
        {
            bookName.RemoveAt(index);
            bookAuthor.RemoveAt(index);
            price.RemoveAt(index);
            quantitiy.RemoveAt(index);
        } // method - deleteBookFunction


        // 1.책 빌리기
        // 로그인
        //      MemberManagement 의 ID 와 PW 를 get 으로 불러오기
        // ID 를 입력받는다 (string)
        // 위에서 Member Class의 memberID List 에서 입력받은 ID에 해당하는 index를 찾는다
        //      예외처리
        //        -1 : ID가 없는경우
        // 비밀번호를 입력받는다 (string)
        // 위에서 찾은 index 로 Member Class의 PW List 에 접근해서 같은지 비교한다
        //      예외처리
        //        -1 : 비밀번호가 틀린경우
        // 책을 입력받는다
        // BookName 의 index 를 찾는다
        // 위에서 구한 index 를 가지고, Book Rent Check List 에 접근하여 대여자의 ID를 넣는다.
        // 대여완료
        // 책의 수량을 -1 해준다
        // Time 함수를 이용해 대여시간을 측정한다
        //      대여시간을 List ADD

        // 대여자, 대여시간 출력에 추가
        public void rentBook()
        {
            List<string> memberID, password;

            memberID = membermanage.MemberID;
            password = membermanage.PW1;

            printmenu.printBookManageFunction("RENT_BOOK_ID");

            string inputID;
            inputID = Console.ReadLine();

            int index;
            index = findIndex(memberID, inputID);
            if(index == -1) { printmenu.printBookManageResult(null, null, 0, 0, "NOT_EXIST_ID"); return; }

            printmenu.printBookManageFunction("RENT_BOOK_PW");

            string inputPW;
            inputPW = membermanage.password();
            if (password[index] != inputPW) { printmenu.printBookManageResult(null, null, 0, 0, "INCORRECT_PASSWORD"); return; }

            printmenu.printBookManageFunction("RENT_BOOK_NAME");

            string inputBookName;
            inputBookName = Console.ReadLine();
            index = findIndex(bookName, inputBookName);

            bookRentID[index] = inputID;
            printmenu.printBookManageResult(inputBookName, null, 0, 0, "RENT_OK");

            bookQuantity[index]--;

            bookRentTime.Insert(index, DateTime.Now.ToString());

        } // Method - rentBook


        // 책 반납하기
        // 책 이름을 입력받는다
        // 책 이름으로 index를 구한다
        // 책이 대여상태인지 확인한다
        //      위에서 구한 index로 bookRentID 이 "" 인지 확인한다
        //      책이 대여상태가 아닌경우 메인메뉴로 돌아간다
        // 책 수량을 1 증가시킨다
        // bookRentID 쪽을 다시 "" 로 만들어준다
        // bookRentTime 쪽도 다시 "" 로 만들어준다
        public void returnBook()
        {
            printmenu.printBookManageFunction("RETURN_BOOK_NAME");

            string inputBookName;
            inputBookName = Console.ReadLine();

            int index;
            index = findIndex(bookName, inputBookName);

            if(bookRentID[index] == "") { printmenu.printBookManageResult(null, null, 0, 0, "BOOK_STATE_NORENT"); return; }

            bookQuantity[index]++;

            bookRentID[index] = "";
            bookRentTime[index] = "";

            printmenu.printBookManageResult(inputBookName, null, 0, 0, "RETURN_OK");
        } // method - returnBook
    } // BookManagement Class
}
