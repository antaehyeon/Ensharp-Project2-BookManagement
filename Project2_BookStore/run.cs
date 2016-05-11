using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2_BookStore
{
    class Run
    {
        Print print;
        MemberManagement member;
        

        public Run()
        {
            print = new Print();
            member = new MemberManagement(this);
        }

        // 처음 프로그램 시작 메뉴
        public void start()
        {
            Console.SetWindowSize(124, 40);
            int selectMenu = print.moveArrow(56, 8, 5, 1);

            switch (selectMenu)
            {
                case 8: // 회원등록
                    this.startMember();
                    break;
                case 9: // 도서관리
                    break;
                case 10: // 도서대여
                    break;
                case 11: // 도서반납
                    break;
                case 12: // 종료
                    print.exitMessage();
                    break;
            } // switch
        }

        // 멤버관리 메뉴
        public void startMember()
        {
            while (true)
            {
                switch (print.moveArrow(56, 8, 6, 2))
                {
                    case 8: // 회원등록
                        member.registerID(1);
                        break;
                    case 9: // 회원수정
                        break;
                    case 10: // 회원삭제
                        break;
                    case 11: // 회원검색
                        break;
                    case 12: // 멤버출력
                        break;
                    case 13: // 뒤로가기
                        this.start();
                        break;
                }
            }
        } // Method - startMember
    }
}
