using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2_BookStore
{
    class BookManagement
    {
        private Print print;
        private SharingData sd;
        private Exception exception;
        private Run run;

        private string bookName;
        private string bookAuthor;
        private string bookPrice;
        private string bookQuantity;
        private string publisher;
        private string bookRentTime;
        private string bookRentID;

        public BookManagement(Run run)
        {
            print = new Print();
            this.run = run;
            exception = new Exception();
            sd = SharingData.GetInstance();
        }

        public void registerBookFunction(int mode)
        {
            switch(mode)
            {
                case 1: // 책 이름
                    bookName = this.enterBookNameFunction();
                    this.registerBookFunction(2);
                    break;
                case 2: // 책 저자
                    bookAuthor = this.enterBookAuthorFunction();
                    this.registerBookFunction(3);
                    break;
                case 3: // 책 수량
                    bookQuantity = this.enterBookQuantityFunction();
                    this.registerBookFunction(4);
                    break;
                case 4: // 책 가격
                    bookPrice = this.enterBookPriceFunction();
                    break;
            }

            BookVO bookData = new BookVO(bookName, bookAuthor, bookPrice, bookQuantity);
            sd.BookList.Add(bookData);
            print.bookRegisterSuccessMessage();
            run.bookMenu();
        }

        // 책 이름 입력받는 기능
        public string enterBookNameFunction()
        {
            print.enterBookNameMessage();
            bookName = Console.ReadLine();
            if (bookName == "b") run.bookMenu();
            if(exception.bookNameCheck(bookName))
            {
                this.enterBookNameFunction();
            }
            return bookName;
        }

        // 책 저자 입력받는 기능
        public string enterBookAuthorFunction()
        {
            print.enterBookAuthorMessage();
            bookAuthor = Console.ReadLine();
            if (bookAuthor == "b") run.bookMenu();
            if (exception.bookAuthorCheck(bookAuthor))
            {
                this.enterBookAuthorFunction();
            }
            return bookAuthor;
        }

        // 책 수량 입력기능
        public string enterBookQuantityFunction()
        {
            print.enterBookQuantity();
            bookQuantity = Console.ReadLine();
            if (bookQuantity == "b") run.bookMenu();
            if (exception.bookQuantityCheck(bookQuantity))
            {
                this.enterBookQuantityFunction();
            }
            return bookQuantity;
        }

        // 책 가격 입력기능
        public string enterBookPriceFunction()
        {
            print.enterBookPrice();
            bookPrice = Console.ReadLine();
            if (bookPrice == "b") run.bookMenu();
            if (exception.bookPriceCheck(bookPrice))
            {
                this.enterBookPriceFunction();
            }
            else if (string.IsNullOrWhiteSpace(bookPrice))
            {
                bookPrice = "FREE";
            }
            return bookPrice;
        }

        // 책을 찾는 기능
        public void findBookFunction()
        {
            if (sd.BookList.Count == 0)
            {
                print.noExistBook();
                run.bookMenu();
            }
            print.findBookName();
            bookName = Console.ReadLine();
            print.bookTitle();
            for (int i = 0; i < sd.BookList.Count; i++)
            {
                if(sd.BookList[i].BookName.Contains(bookName))
                {
                    print.bookElement(i);
                    print.bookEndLine();
                }
            }
        }

        public void printBookFunction()
        {

        }

        public void deleteBookFunction()
        {

        }

        public void changeBookFunction()
        {

        }
    } 
}
