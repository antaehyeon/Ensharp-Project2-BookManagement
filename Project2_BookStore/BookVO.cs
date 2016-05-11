using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2_BookStore
{
    class BookVO
    {
        private string bookName;
        private string bookAuthor;
        private int bookPrice;
        private int bookQuantity;
        private string bookRentTime;
        private string bookRentID;

        public BookVO() { }
        public BookVO(string bookName, string bookAuthor, int bookPrice, int bookQuantity, string bookRentTime, string bookRentID)
        {
            this.bookName = bookName;
            this.bookAuthor = BookAuthor;
            this.bookPrice = BookPrice;
            this.bookQuantity = BookQuantity;
            this.bookRentTime = BookRentTime;
            this.bookRentID = bookRentID;
        }

        public string BookName
        {
            get { return bookName; }
            set { bookName = value; }
        }

        public string BookAuthor
        {
            get { return bookAuthor; }
            set { bookAuthor = value; }
        }

        public int BookPrice
        {
            get { return bookPrice; }
            set { bookPrice = value; }
        }

        public int BookQuantity
        {
            get { return bookQuantity; }
            set { bookQuantity = value; }
        }

        public string BookRentTime
        {
            get { return bookRentTime; }
            set { bookRentTime = value; }
        }

        public string BookRentID
        {
            get { return bookRentID; }
            set { bookRentID = value; }
        }
    }
}
