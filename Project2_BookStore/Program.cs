using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2_BookStore
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "도서관리 프로그램 - 안태현";

            Print p = new Print();
            MemberManagement member = new MemberManagement();
            BookManagement book = new BookManagement();

            Console.SetWindowSize(124, 40);
            p.printFirstMenu();
            string selectMenu = Console.ReadLine();

            switch(selectMenu)
            {
                case "1":
                    break;
            } // switch
        } // Main
    }
}
