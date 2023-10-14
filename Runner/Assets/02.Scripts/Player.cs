using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Operatable<T>
{
    public static Operatable<T> operator +(Operatable<T> a, Operatable<T> b)
    {
        return a;
    }
}
public class Player : MonoBehaviour
{
    public float hp
    {
        get
        {
            return _hp;
        }
        set
        {
            if (value == _hp)
                return;

            _hp = value;
            onHpChanged(value);
        }
    }
    [SerializeField] private float _hp;
    public float hpMax
    {
        get
        {
            return _hpMax;
        }
    }
    [SerializeField] private float _hpMax = 100;
    public delegate void OnHpChangedHandler(float vlaue);
    //public event OnHpChangedHandler OnHpChanged;
    public event OnHpChangedHandler onHpChanged;

    // Action �븮��
    //�Ķ���͸� 0 ~ 16������ ���� �� �ִ� void�� ��ȯ�ϴ� ������ �븮��
    public Action<int, float, string> action;

    //Func �븮��
    //�Ķ���͸� 0 ~ 16������ ���� �� �ִ�
    //���׸�Ÿ���� ��ȯ�ϴ� ������ �븮��.
    public Func<int, float, string> func;

    //Predicate �븮��
    //�Ķ���͸� 1�� �ް�,
    //bool Ÿ���� ��ȯ�ϴ� ������ �븮��
    //� �������� match ������ �˻��� �� �����(�ڷᱸ������ Ư�� �ڷ� Ž���� �ؾ��Ҷ� �ַ� ��)
    public Predicate<int> match;

    //Generic
    //� Ÿ���� �Ϲ�ȭ�ϴ� ��������� ����

    //where ������
    //GenericŸ���� � Ÿ������ ������������ ���ѰŴ� ������
    //public T Sum<T>(T a, T b)
    //    where T : Operatable<T>
    //    (a + b);

    public int Sum(int a, int b)
        => a + b;

    public float Sum(float a, float b)
        => a + b;
    public double Sum(double a, double b)
        => a + b;

    public void DepleteHp(float amout)
    {
        hp -= amout;
    }
}
