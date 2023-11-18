using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    //게임 시작될 때 데이터를 초기화 한다
    //서버와 통신할 때 레벨, 공격력 등등을 서버에서 가져와서 설정한다
    private void Awake()
    {
        Debug.Log("플레이어 설정 완료");
    }

    //게임 오브젝트가 활성화 될 때 호출되는 함수
    private void OnEnable()
    {
        Debug.Log("오브젝트 초기화");
    }
    
    // Start is called before the first frame update
    //게임을 실행 => 몬스터 스폰 맵 불러오기 등
    void Start()
    {
        Debug.Log("게임시작");
    }
     
    //일정 주기마다 캐릭터 움직임의 물리연산을 실행한다
    //CPU의 영향을 받지 않는다
    private void FixedUpdate()
    {
        Debug.Log("캐릭터 움직임");
    }

    // Update is called once per frame
    //게임의 전반적인 로직을 실행한다
    //CPU의 영향을 받지 않는다
    void Update()
    {
        Debug.Log("몬스터 사냥");
    }

    //업데이트의 메소드를 실행하고 나서 나며지 이펙트나 여러 연산을 불러온다
    private void LateUpdate()
    {
        Debug.Log("효과 발생 : 이펙트");
    }

    //게임 오브젝트가 비활성화 될 때 호출되는 함수
    private void OnDisable()
    {
        Debug.Log("오브젝트 초기화 해제");
    }

    //몬스터가 사라질 때 호출되는 함수
    //하이어라키 창에서 게임 오브젝트가 삭제될 때 호출된다
    private void OnDestroy()
    {
        Debug.Log("몬스터가 사라진다");
    }
    
}
