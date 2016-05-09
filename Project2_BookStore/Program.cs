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

            PrintMenu print_menu = new PrintMenu();

            print_menu.start();
        }
    }
}
