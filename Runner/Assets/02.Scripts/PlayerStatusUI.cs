using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatusUI : MonoBehaviour
{
    [SerializeField] private Slider _hpBar;
    [SerializeField] private Player _player;

    void Start()
    {
        //Debug.Log("Start");
        //_hpBar = GetComponent<RectTransform>().GetChild(0).GetComponent<Slider>();
        //
        //GetComponentinChildren<Slider>();
        // ��������Ʈ�� ������ GameObject�� ������ ������Ʈ�� �߿� �ش� Ÿ���� ã�Ƽ� ��ȯ��
        //GetComponent<RectTransform>();

        _hpBar.minValue = 0.0f;
        _hpBar.maxValue = _player.hpMax;
        _hpBar.value = _player.hp;
        //_player.onHpChanged += RefreshHPBar;
        //�ζ��� �Լ� : �Լ� ������带 ���̱� ���� ��� �����θ� �ش� ���ο� ���� �����ϴ� �Լ�
        //C#������ �ζ��� �Լ� ���� : �͸��Լ� (���ٽ�) ���� ������.
        //���ٽ� : �����Ϸ��� �Ǵ��� �� �ִ� �ڵ带 ��� �����ϰ� �̸��� ������ �Լ���
        //ex) RefreshHPBar
        //�ζ����Լ��� ���������ڰ� �ǹ� �����Ƿ� private ����
        //�����Ϸ��� �븮���� ������ float �Ķ���� 1���� void ��ȯ�̹Ƿ� void �� float Ÿ�� ����
        //�ζ����̹Ƿ� �̸����� �Լ� �˻��� �� ���� �����Ƿ� �̸� ����
        //������ �����̸� �״����� �ݵ�� �Լ� ������ �Ͼ���ϹǷ� �Լ� ���� ���� �ʿ�����Ƿ� �߰�ȣ ����
        // ���ٽ� ��ø� ���� => �߰�
        _player.onHpChanged += (value) => _hpBar.value = value;
    }
    

    private void RefreshHPBar(float value)
    {
        _hpBar.value = value;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
