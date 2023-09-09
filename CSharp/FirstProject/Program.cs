﻿namespace FirstProject
{
    class 철수
    {
        //철수 객체 할당할 때 필요한 메모리 : 8byte(멤버 변수 크기 총합)
        int 나이;
        int 돈;
    }

    class 영희
    {
        //전역 변수 : 어떤 클래스에서도 접근 가능한 변수(클래스의 멤버 변수도 전역변수이다)
        //영희 객체 할당할 때 필요한 메모리 : 4byte
        int 나이 = 1; // 변수 선언 부분네 어떤 값을 대입하겠다는 대입연산을 쓰면 해당 값을 초기 데이터로 쓰겠다는 명시 (DataMisalignedException 영역에 할당) = 초기화
        //정적 : 동적의 반대의미. 동적으로 할당할 수 없다. 런타임 중에 메모리에 추가적인 할당이 불가능하다
        //클래스 생성자 : Heap영역에다가 클래스 타입의 객체를 할당 멤버 변수의 초기화를 진행
        static char 성별 = '여';

        //클래스는 캡슐화를 컨셉으로 한 사용자 정의 자료형이다
        // -> 접근 제한자를 명시하지 않으면 외부 접근을 차단하는게 기본 컨셉
        //접근 제한자 Access Modifier : 외부에서 멤버 접근 가능여부를 제한하는 키워드
        //private - 이 클래스 말고 다른 클래스는 해당 멤버 클래스에 접근할 수 없다(- 로 표현) 
        //protected - 이 클래스를 상속 받은 자식클래스만 해당 멤버에 접근할 수 있다(#)
        //intermal - Assembly(코드조각, exe, dll 등) 단위로만 해당 멤버에 접근할 수 있다
        //public - 접근제한 없음.
        public 영희()
        {

        }

        //클래스 소멸자 : 해당 객체가 할당된 메모리 영역을 시스템 반환하는 함수
        //해당 객체가 할당된 메모리영역을 시스템에 반환하는 함수
        //가비지컬렉터가 알아서 소멸시키기 때문에 직접 호출할 필요가 없다
        ~영희() 
        {
            
        }

        //void : 반환 타입이 정해져 있지않음(반환타입 x)
        void SayMyAge()
        {

        }
        //지역변수 : {} 내에서 정의되어 해당 연산 중에만 메모리에 할당되는 변수
        //파라미터도 지역변수의 일종
        bool 나이먹기(int 먹을나이)
        {
            int 예상나이 = 나이 + 먹을나이;
            //if구문 : if(논리형의실행조건)
            //{
            //  샐행조건이 참일때 실핼할 내용
            //}
            //else
            //{
            //  실행조건이 거짓일 떄
            //}
            //만약 예상나이가 음수면 나이를 못 먹는다고 할거임.
            if(예상나이 < 0)
            {
                return false;
            }
            else
            {
                나이 = 예상나이;
                return true;
            }
        }
    }



    internal class Program
    {
        //변수 : 아직 정해지지 않은 값
        //멤버 변수 : 사용자 정의 자료형에서 특정 공간능 구성하는 구성원으로 정의된 변수
        int a;
        uint b;
        short c;
        ushort d;
        long e;
        ulong f;
        char g;
        float h;
        double i;
        bool j;

        
        static void Main(string[] args)//메인 함수, 프로그램 실행시 처음 호출되는(실행되는) 함수
        {
            //new : 동적 할당 키워드 메모리를 동적으로 할당하겠다고 명시할 때 사용하는 키워드
            new 영희();
        }
    }
}