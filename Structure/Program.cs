namespace Structure
{
    // struct 구조체
    // 데이터와 기능을 정의하는 사용자 정의 자료형 
    // C# 에서의 구조체는 
    // 클래스를 값 타입으로 사용하기위한 자료형
    // 
    // 구조체 vs 클래스
    // 1. 멤버변수(데이터) 의 쓰기/읽기가 빈번하게 일어나는 경우 값 타입이 참조타입보다 유리함. 
    // 항상 유리한것은 아니라, 16 byte 이하일때.
    // 2. 확장의 가능성이 없을때.
    public struct Vector3
    {
        // property 
        public float x
        {
            get
            {
                return _x;
            }
            private set 
            {
                _x = value;
            }
        }

        public float y
        {
            get
            {
                return _y;
            }
            set
            {
                _y = value;
            }
        }

        public float z
        {
            get
            {
                return _z;
            }
            set
            {
                _z = value;
            }
        }

        private float _x;
        private float _y;
        private float _z;

        // 구조체 생성자
        // 멤버변수의 초기화 내용을 구현하는 함수
        public Vector3()
        {
            _x = 0;
            _y = 0;
            _z = 0;
        }

        public float GetX()
        {
            return _x;
        }

        public void SetX(float value)
        {
            _x = value;
        }

        public float Magnitude()
        {
            return (float)Math.Sqrt(_x * _x + _y * _y + _z * _z);
        }
    }

    public class Vector2
    {
        public float x;
        public float y;

        // 클래스 생성자
        // 1. Managed Heap 영역에 객체를 만듬. 
        // 2. 멤버변수데이터를 데이터영역에서 참조해서 해당 객체를 초기화
        // 3. 해당 객체 주소를 반환
        public Vector2()
        {

        }

        public float Magnitude()
        {
            return (float)Math.Sqrt(x * x + y * y);
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            Vector2 vector2 = new Vector2();
            Vector3 vector3 = new Vector3();
            vector3.y = 1.0f;
            Console.WriteLine(vector3.y);
        }
    }
}