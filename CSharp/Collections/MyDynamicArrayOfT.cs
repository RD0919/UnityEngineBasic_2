using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Collections
{
    internal class MyDynamicArray<T>
    {
        public T this[int index]
        {
            get 
            {
                if (index < 0 || index >= Count)
                    throw new IndexOutOfRangeException();
                return _items[index];
            }
            set 
            {
                if (index < 0 || index >= Count)
                    throw new IndexOutOfRangeException();
                _items[index] = value;
            }
        }


        //동젇배열의 용량(현재 잠조하고 있는 배열의 길이)
        public int Capacity => _items.Length;
        public int Count => _count;
        //실제 가지고 있는 자료의 갯수

        private const int DEFALT_SIZE = 1;
        private T[] _items = new T[DEFALT_SIZE];// 동적배열은 배열 기반이기 때문에 아이템을 저장할 배열이 필요함
        private int _count;

        //매치 조건 탐색
        public T Find(Predicate<T> match)
        {
            for (int i = 0; i < _count; i++)
            {
                if (match.Invoke(_items[i]))
                    return _items[i];
            }
            return default;
        }

        //매치 조건 탐색
        public int Findindex(Predicate<T> match)
        {
            for (int i = 0; i < _count; i++) 
            {
                if (match.Invoke(_items[i]))
                    return i;
            }
            return -1;
        }

        //삽입
        public void Add(T item) 
        {
            if(_count >= _items.Length)
            {
                T[] tmp = new T[_count * 2];//2배 더 큰 배열을 만듬
                Array.Copy(_items, tmp, _count);
                _items = tmp;//배열 참조 위치 변경
            }

            _items[_count] = item; //마지막에 아이템 추가
        }
        //삭제
        public void RemoveAt(int index)
        {
            for (int i = index; i < _count - 1; i++)
            {
                _items[i] = _items[i + 1];
            }
            _count--;//하나 뺏으니까 차감
        }

        public bool Remove(T item) 
        {
            int index = Findindex(x => x.Equals(item));
            if (index < 0)
                return false;
            RemoveAt(index);
            return true;
        }
        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerable(true);
        }

        //책을 읽어주는 사람
        public struct Enumerator : IEnumerator<T>
        {
            //현재 페이지 내용
            public T Current => throw new NotImplementedException();

            
            object IEnumerator.Current => throw new NotImplementedException();

            public void Dispose()
            {
                throw new NotImplementedException();
            }
            private readonly MyDynamicArray<T> _data;//책
            private int _index; // 현재 페이지
            public Enumerator(MyDynamicArray<T> data)
            {
                _data = data;
                _index = -1;
            }

            //다음 페이지로
            public bool MoveNext()
            {
                //다음 페이지를 넘길 수 있을 때
                if (_index < _data.Count - 1)
                {
                    _index++;
                    return true;
                }
                return false;
            }
            //책표지 덮기
            public void Reset()
            {
                _index = -1;
            }
        }
    }
}
