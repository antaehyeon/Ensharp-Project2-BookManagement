using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2_BookStore
{
    class MemberManagement
    {
        private PrintMenu print_menu;
        private Exception exception;
        private List<string> memberID;
        private List<string> memberName;
        private List<string> createTime;
        private List<string> PW;
        private List<string>[] phoneNumber;
        public const int CONTINUE = 2222;

        // 나중에 BookManagement ( 도서 대여, 반납 쪽에서 쓰기위한 get/set
        public List<string> MemberID
        {
            get { return memberID; }
            set { memberID = value; }
        }

        public List<string> PW1
        {
            get { return PW; }
            set { PW = value; }
        }

        // 데이터 요소들
        public MemberManagement(PrintMenu print_menu)
        {
            exception = new Exception();
            this.print_menu = print_menu;
            MemberID = new List<string>();
            memberName = new List<string>();
            createTime = new List<string>();
            PW1 = new List<string>();
            phoneNumber = new List<string>[3];
            phoneNumber[0] = new List<string>();
            phoneNumber[1] = new List<string>();
            phoneNumber[2] = new List<string>();
        } // Constructor

        public void start()
        {
            while (true)
            {
                int choiceNumber;
                string inputID, name;
                choiceNumber = print_menu.choiceMenu(11, 6, 6, 2);
                switch (choiceNumber)
                {
                    case 6: // 등록
                        inputID = addID(); // ID를 입력
                        name = addName(); // 이름을 입력
                        addPhone(); // 핸드폰번호 입력
                        PW1.Add(password()); // 패스워드 입력
                        createTime.Add(DateTime.Now.ToString()); // 생성시간
                        print_menu.printMemberResult(inputID, name, null, null, "ADD"); // 등록완료 메세지
                        break;
                    case 7: // 수정
                        modify();
                        break;
                    case 8: // 삭제
                        string checkPW;
                        int index = 0;

                        print_menu.printMemberFunction("DELETE");
                        inputID = Console.ReadLine(); // ID를 입력받고
                        if (duplicationCheck(inputID, MemberID) == "NO_DUPLICATION") // 중복X
                        {
                            print_menu.printMemberResult(null, null, null, null, "DELETE_ERROR"); // 결과출력 - DELETE ERROR
                            continue;
                        }
                        print_menu.printMemberFunction("PASSWORD");
                        checkPW = password(); // 패스워드를 입력받습니다

                        // 아이디를 통해서 index를 찾고
                        foreach(string str in MemberID)
                        {
                            if (str == inputID) { break; }
                            index++;
                        }

                        // 위의 index로 Password List에 접근합니다
                        if(PW1[index] == checkPW) // 패스워드가 맞다면 delete 함수를 이용해 해당 index 의 정보를 전부 지웁니다.
                        {
                            name = delete(inputID);
                            print_menu.printMemberResult(inputID, name, null, null, "DELETE");
                        }
                        else // 패스워드가 틀릴경우
                        {
                            print_menu.printMemberResult(null, null, null, null, "PASSWORD_ERROR"); // 에러메세지를 출력후, 메인메뉴로 다시 나갑니다.
                            continue;
                        }
                        break;
                    case 9: // 검색
                        find();
                        break;
                    case 10: // 멤버출력
                        print_menu.printMemberList(createTime, MemberID, memberName, phoneNumber[0], phoneNumber[1], phoneNumber[2]);
                        Console.ReadKey();
                        break;
                    case 11: // 뒤로가기
                        Console.Clear();
                        print_menu.start();
                        break;
                } // switch choiceNumber
            } // while
        } // Method - start

        public string duplicationCheck(string inputStr, List<string> list)
        {
            foreach (string str in list)
            {
                if(str == inputStr)
                {
                    return "DUPLICATION";
                }
            } // foreach - str in memberID
            return "NO_DUPLICATION";
        } // method - find String

        public string addID()
        {
            while(true)
            {
                string ID;
                print_menu.printMemberFunction("ADD_ID");
                Console.SetWindowSize(52, 16);
                ID = exception.inputString();
                if (ID == "ERROR")
                {
                    continue;
                }
                if (duplicationCheck(ID, MemberID) == "DUPLICATION") // 중복
                {
                    print_menu.printMemberResult(null, null, null, null, "ADD_ERROR");
                    continue;
                }
                else
                {
                    MemberID.Add(ID);
                    return ID;
                }
            } // while
        } // method - addMember

        public string addName()
        {
            while(true)
            {
                string name;
                print_menu.printMemberFunction("ADD_NAME");
                name = exception.inputName();
                if (name == "ERROR") { continue; }
                else
                {
                    memberName.Add(name);
                    return name;
                }
            } // while
        } // method - addName

        public string addPhoneFunction(string str, int param)
        {
            string tempString;
            while (true)
            {
                print_menu.printMemberFunction(str);
                tempString = (param == 3) ? exception.inputPhoneNum(3) : exception.inputPhoneNum(4);
                if (tempString == "ERROR")
                {
                    Console.WriteLine("잘못 입력하셨습니다");
                    Console.ReadKey();
                    continue;
                }
                else
                {
                    return tempString;
                }
            } // while
        }

        public void addPhone()
        {
            List<int> indexList = new List<int>();
            string tmpF, tmpM, tmpL;
            int index = 0;
            while(true)
            {
                tmpF = addPhoneFunction("ADD_PHONE_FIRST", 3);
                tmpM = addPhoneFunction("ADD_PHONE_MIDDLE", 4);
                tmpL = addPhoneFunction("ADD_PHONE_LAST", 4);

                foreach(string str in phoneNumber[1])
                {
                    if(str == tmpM)
                    {
                        indexList.Add(index);
                    }
                    index++;
                } // foreach - phoneNumber[1]

                if (indexList.Count == 0)
                {
                    phoneNumber[0].Add(tmpF);
                    phoneNumber[1].Add(tmpM);
                    phoneNumber[2].Add(tmpL);
                    return;
                }
                else
                {
                    for (int i = 0; i < indexList.Count; i++)
                    {
                        if(phoneNumber[2][indexList[i]] == tmpL)
                        {
                            Console.WriteLine("중복된 번호입니다.");
                            Console.ReadKey();
                            addPhone();
                        }                            
                    } // for - indexList.Count
                    break;
                } // else
            } // while
            phoneNumber[0].Add(tmpF);
            phoneNumber[1].Add(tmpM);
            phoneNumber[2].Add(tmpL);
        } // method - addName

        public string password()
        {
            ConsoleKeyInfo key;

            string pass = "";
            print_menu.printMemberFunction("PASSWORD");
            
            do
            {
                while (true)
                {
                    key = Console.ReadKey(true);
                    if (key.Key == ConsoleKey.Enter && pass.Length == 0)
                    {
                        Console.WriteLine();
                        Console.WriteLine("     패스워드가 입력되지 않았습니다");
                        Console.ReadKey();
                        Console.Clear();
                        print_menu.printMemberFunction("PASSWORD");
                    }
                    else
                        break;
                }

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

        public string delete(string str)
        {
            int index;
            string name;
            
            index = MemberID.FindIndex(x => x == str);

            name = memberName[index];

            MemberID.RemoveAt(index);
            memberName.RemoveAt(index);
            createTime.RemoveAt(index);
            PW1.RemoveAt(index);

            return name; // 네임보다는 return Value
        } // method - delete

        public void find()
        {
            int selectNum, index = 0, count = 0;
            string inputString;
            string phoneString = "";
            selectNum = print_menu.choiceMenu(11, 6, 4, 3);
            
            switch(selectNum)
            {
                case 6: // ID
                    print_menu.printMemberFunction("SEARCH_ID");
                    inputString = Console.ReadLine();
                    if (duplicationCheck(inputString, MemberID) == "NO_DUPLICATION") // 중복이 아니라면
                    {
                        print_menu.printMemberResult(null, null, null, null, "SEARCH_ERROR");
                        find();
                    }
                    index = MemberID.FindIndex(x => x == inputString);
                    phoneString = unionPhoneNumberString(phoneNumber, index);
                    print_menu.printMemberResult(MemberID[index], memberName[index], phoneString, createTime[index], "SEARCH");
                    break;
                case 7: // 이름
                    List<int> indexName = new List<int>();

                    print_menu.printMemberFunction("SEARCH_NAME");
                    inputString = Console.ReadLine();
                    if (duplicationCheck(inputString, memberName) == "NO_DUPLICATION") // 중복이 아니라면
                    {
                        
                        print_menu.printMemberResult(null, null, null, null, "SEARCH_NAME_ERROR");
                    }
                    else // 중복이라면
                    {
                        foreach (string tmpStr in memberName)
                        {
                            if (tmpStr == inputString)
                            {
                                indexName.Add(count);
                            }
                            count++;
                        } // foreach - memberName
                        if (indexName.Count == 1)
                        {
                            index = memberName.FindIndex(x => x == inputString);
                            phoneString = unionPhoneNumberString(phoneNumber, index);
                            print_menu.printMemberResult(MemberID[index], memberName[index], phoneString, createTime[index], "SEARCH");
                            break;
                        }
                        while (true)
                        {
                            string inputPhoneNumLastFour;
                            print_menu.printMemberFunction("SEARCH_NAME_PHONE");
                            Console.SetCursorPosition(13, 8);
                            inputPhoneNumLastFour = exception.inputPhoneNum(4);

                            if (inputPhoneNumLastFour == "ERROR")
                            {
                                continue;
                            } // if

                            for (int i = 0; i < indexName.Count; i++)
                            {
                                if (phoneNumber[2][indexName[i]] == inputPhoneNumLastFour)
                                {
                                    index = indexName[i];
                                } // if 
                            } // for - indexName.Count
                            break;
                        } // while

                        phoneString = unionPhoneNumberString(phoneNumber, index);
                        print_menu.printMemberResult(MemberID[index], memberName[index], phoneString, createTime[index], "SEARCH");
                    } // else
                    break;
                case 8: // 핸드폰번호
                    int j;
                    string firstPhoneNum, midPhoneNum, lastPhoneNum;
                    string tmpPhoneNum = "";
                    string tmpPhoneNum2 = "";
                    List<int> phoneIndex = new List<int>();        

                    while(true)
                    {
                        print_menu.printMemberFunction("ADD_PHONE_FIRST");
                        firstPhoneNum = exception.inputPhoneNum(3);
                        if (firstPhoneNum == "ERROR") { continue; }
                        break;
                    } //while
                    while(true)
                    {
                        print_menu.printMemberFunction("ADD_PHONE_MIDDLE");
                        midPhoneNum = exception.inputPhoneNum(4);
                        if (midPhoneNum == "ERROR") { continue; }
                        break;
                    } // while
                    while(true)
                    {
                        print_menu.printMemberFunction("ADD_PHONE_LAST");
                        lastPhoneNum = exception.inputPhoneNum(4);
                        if (lastPhoneNum == "ERROR") { continue; }
                        break;
                    } //while

                    tmpPhoneNum += firstPhoneNum + midPhoneNum + lastPhoneNum;

                    foreach(string str in phoneNumber[1])
                    {
                        if(str == midPhoneNum)
                        {
                            phoneIndex.Add(count);
                        }
                        count++;
                    } // foreach - phoneNumber[1]

                    for (j = 0; j < phoneIndex.Count; j++)
                    {
                        tmpPhoneNum2 = phoneNumber[0][phoneIndex[j]] + phoneNumber[1][phoneIndex[j]] + phoneNumber[2][phoneIndex[j]];
                        if (tmpPhoneNum == tmpPhoneNum2)
                        {
                            print_menu.printMemberResult(MemberID[phoneIndex[j]], memberName[phoneIndex[j]], tmpPhoneNum, createTime[phoneIndex[j]], "SEARCH");
                            break;
                        }
                    }
                    if (j == phoneIndex.Count)
                    {
                        print_menu.printMemberResult(null, null, null, null, "SEARCH_PHONE_ERROR");
                    }
                    break;
                case 9: // 뒤로가기
                    start();
                    break;
            } // switch - selectNum
        } // method - find

        public string unionPhoneNumberString(List<string>[] str, int index)
        {
            string tempString = "";
            for (int i = 0; i < 3; i++)
            {
                tempString += str[i][index];
            }
            return tempString;
        } // method - unionPhoneNumberString
        

        // 1. 수정할 ID 를 입력받습니다. (예외처리 포함)
        // 2. 아이디의 index를 찾습니다.
        // 3. 비밀번호를 입력받습니다.
        // 4. 2번에서 찾은 index를 이용해 입력받은 비밀번호와 저장되어있는 비밀번호가 같은지 판단합니다. 

        // 4-맞으면
        // 수정항목 2개를 보여줍니다
        // 1. 이름
        // 2. 핸드폰번호
        // 각각의 정보를 받아서 아까 2번에서 구한 index로 교체를 진행합니다.

        // 4-틀리면
        // count를 증가시킵니다.
        // count 이 3, 즉 3번 틀렸을 경우, 메뉴로 돌아갑니다.
        public void modify()
        {
            string inputId, inputPW;
            string inputName, tmpName;
            int selectNum;
            int index = 0;
            int count = 0;

            while (true)
            {
                // 1
                print_menu.printMemberFunction("MODIFY_CURRENT");
                inputId = exception.inputString();
                if (inputId == "ERROR") { continue; }
                if (duplicationCheck(inputId, MemberID) == "DUPLICATION") { }
                else
                {
                    print_menu.printMemberResult(null, null, null, null, "MODIFY_CURRENT_ERROR");
                    start();
                }

                // 2
                foreach (string str in MemberID)
                {
                    if(str == inputId) { break; }
                    index++;
                } // foreach - memberID
                break;
            } // while
            
            while(true)
            {
                // 3
                inputPW = password();

                // 4
                if (PW1[index] == inputPW) { break; }
                else
                {
                    count++;
                    Console.WriteLine();
                    Console.WriteLine("       {0} 번 틀리셨습니다", count);
                    Console.WriteLine("       3 번 틀리실 경우");
                    print_menu.setConsoleColor("       메인메뉴로 돌아갑니다");
                    Console.ReadKey();
                }

                // 4 - 틀리면
                if (count == 3) { start(); }
            } // while

            // 4-맞으면
            selectNum = print_menu.choiceMenu(11, 6, 3, 4);

            switch(selectNum)
            {
                case 6: // 이름
                    while (true)
                    {
                        print_menu.printMemberFunction("MODIFY_NAME");
                        inputName = exception.inputName();
                        if (inputName == "ERROR") { continue; }
                        else if (inputName == "ERROR_HANGLE_OVER_2")
                        {
                            print_menu.printMemberResult(null, null, null, null, "ADD_NAME_ERROR_2");
                            continue;
                        }
                        tmpName = memberName[index];
                        memberName[index] = inputName;
                        print_menu.printMemberResult(tmpName, inputName, null, null, "MODIFY_NAME");
                        break;
                    } // true
                    break;
                case 7: // 핸드폰번호
                    string firstPhoneNum, midPhoneNum, lastPhoneNum;
                    string inputPhoneNum, tmpPhoneNum;

                    tmpPhoneNum = unionPhoneNumberString(phoneNumber, index);

                    while (true)
                    {
                        print_menu.printMemberFunction("ADD_PHONE_FIRST");
                        firstPhoneNum = exception.inputPhoneNum(3);
                        if (firstPhoneNum == "ERROR") { continue; }
                        phoneNumber[0][index] = firstPhoneNum;
                        break;
                    } //while
                    while (true)
                    {
                        print_menu.printMemberFunction("ADD_PHONE_MIDDLE");
                        midPhoneNum = exception.inputPhoneNum(4);
                        if (midPhoneNum == "ERROR") { continue; }
                        phoneNumber[1][index] = midPhoneNum;
                        break;
                    } // while
                    while (true)
                    {
                        print_menu.printMemberFunction("ADD_PHONE_LAST");
                        lastPhoneNum = exception.inputPhoneNum(4);
                        if (lastPhoneNum == "ERROR") { continue; }
                        phoneNumber[2][index] = lastPhoneNum;
                        break;
                    } //while

                    inputPhoneNum = firstPhoneNum + midPhoneNum + lastPhoneNum;

                    print_menu.printMemberResult(tmpPhoneNum, null, inputPhoneNum, null, "MODIFY_PHONE");

                    break;
                case 8:
                    start();
                    break;
            } // switch - selectNum
        } // method - Modify
    } // MemberManagement Class
}
