namespace Array
{
    internal class Program
    {
        // 2차원  배열
        // 아이템이 6개 있고 각 아이템은 5개의 서브아이템을 가진다. 
        // 6개의 행(row), 5개의 열(column)
        // 0 : 길
        // 1 : 벽
        // 2 : 도착지점
        // 3 : 플레이어
        static int[,] map = new int[6, 5]
        {
                { 0, 0, 0, 0, 1},
                { 0, 1, 1, 1, 1},
                { 0, 0, 0, 1, 1},
                { 1, 1, 0, 1, 1},
                { 1, 1, 0, 1, 1},
                { 1, 1, 0, 0, 2},
        };
        static int y, x;

        static void Main(string[] args)
        {
            #region 1 차원 배열 및 반복문
            int[] arr = new int[5];
            arr[0] = 1;
            arr[1] = 3;
            // [ ] 인덱서 : 인덱스 접근하기위한 연산자
            // 0 을 인덱스 : 인덱서에 몇번째 인덱스에 접근할건지에 대한 입력
            // 배열의 인덱스 접근 : "배열참조 주소로부터 + 인덱스 x 자료형크기" 부터 "자료형크기만큼" 접근

            // 배열을 만들때 초기값을 명시하지않으면 전부 default 값으로 초기화됨. 
            // 배열도 멤버 변수, 함수 등을 가지는 클래스 형태임.
            Console.WriteLine(arr[0]);
            Console.WriteLine(arr[1]);
            Console.WriteLine(arr[2]);
            Console.WriteLine(arr[3]);
            Console.WriteLine(arr[4]);
            //Console.WriteLine(arr[5]);  // 배열의 인덱스범위는 0 ~ Array.Length - 1 까지.

            //while (반복할 조건)
            //{
            //    반복할 내용
            //}

           int index = 0; 
            while (index < arr.Length)
            {
                Console.WriteLine(arr[index]);
                index++;
            }

            // do-while 문 : 일단 한번 수행하고 반복할지 말지 조건 체크
            //do
            //{
            //    반복할 내용
            //} while (반복할 조건);

            // for (반복 시작전 실행할 내용; 반복할 조건; 반복수행 완료시마다 실행할 내용)
            // {
            // 
            // }
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
                //break; //현재 구문을 탈출
                //continue; //현재 라인에서 코드흐름 끊고 다시 현재 구문 처음으로 돌아가서 실행
                //return; //현재 할당된 함수를 종료하고 메모리 해제
                Console.WriteLine(arr[i]);
            }
            int[] arr2 = new int[8];
            System.Array.Copy(arr, arr2, arr.Length);

            for (int i = 0; i < arr.Length; i++)
            {
                arr2[i] = arr[i];
            }
            #endregion

            int[][] jaggedArray = new int[3][];

            map[y, x] = 3;
            int goalY = 5;
            int goalX = 4;
            DrawMap();

            while (y != goalY || x != goalX)
            {
                string input = Console.ReadLine();
                input = input.ToUpper();
                if (input == "U") MoveUp();
                else if (input == "D") MoveDown();
                else if (input == "R") MoveRight();
                else if (input == "L") MoveLeft();
                else Console.WriteLine("잘못된 입력. U, D, R, L  중 하나를 입력하세요.");
            }

            Console.WriteLine("보물찾기 끝! 게임종료.");
        }

        static void DrawMap()
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    if (map[i, j] == 0)
                        Console.Write("□");
                    else if (map[i, j] == 1)
                        Console.Write("■");
                    else if (map[i, j] == 2)
                        Console.Write("☆");
                    else if (map[i, j] == 3)
                        Console.Write("▣");
                }
                Console.WriteLine();
            }
        }

        static void MoveUp()
        {
            // 맵 범위 초과하는지 확인
            if (y <= 0)
            {
                Console.WriteLine("해당 방향으로 움직일 수 없습니다. 맵의 경계를 초과합니다.");
                return;
            }

            // 막혀있는지 확인
            if (map[y - 1, x] == 1)
            {
                Console.WriteLine("벽으로 막혀있다.");
                return;
            }

            map[y, x] = 0;
            y--;
            map[y, x] = 3;
            DrawMap();
        }
        static void MoveDown() 
        {
            // 맵 범위 초과하는지 확인
            if (y >= map.GetLength(0) - 1)
            {
                Console.WriteLine("해당 방향으로 움직일 수 없습니다. 맵의 경계를 초과합니다.");
                return;
            }

            // 막혀있는지 확인
            if (map[y + 1, x] == 1)
            {
                Console.WriteLine("벽으로 막혀있다.");
                return;
            }

            map[y, x] = 0;
            y++;
            map[y, x] = 3;
            DrawMap();
        }
        static void MoveLeft() 
        {
            // 맵 범위 초과하는지 확인
            if (x <= 0)
            {
                Console.WriteLine("해당 방향으로 움직일 수 없습니다. 맵의 경계를 초과합니다.");
                return;
            }

            // 막혀있는지 확인
            if (map[y, x - 1] == 1)
            {
                Console.WriteLine("벽으로 막혀있다.");
                return;
            }

            map[y, x] = 0;
            x--;
            map[y, x] = 3;
            DrawMap();
        }

        static void MoveRight()
        {
            // 맵 범위 초과하는지 확인
            if (x >= map.GetLength(1) - 1)
            {
                Console.WriteLine("해당 방향으로 움직일 수 없습니다. 맵의 경계를 초과합니다.");
                return;
            }

            // 막혀있는지 확인
            if (map[y, x + 1] == 1)
            {
                Console.WriteLine("벽으로 막혀있다.");
                return;
            }

            map[y, x] = 0;
            x++;
            map[y, x] = 3;
            DrawMap();
        }
    }
}