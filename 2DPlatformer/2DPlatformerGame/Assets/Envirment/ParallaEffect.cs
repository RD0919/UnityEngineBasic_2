using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaEffect : MonoBehaviour
{

    public Camera cam;
    public Transform followTarget;

    Vector2 startingPosition;//현재 Transform의 Position

    float startingZ;// -1.2, -0.6, -0.24이 값하고 플레이어의 포지션의 z값의 차이

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
        startingZ = transform.position.z - followTarget.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        //카메라의 현재 나의 시작 위치의 차이 Vector2
        Vector2 camMoveSinceStart = (Vector2)cam.transform.position - startingPosition;//카메라와 나의 거리 차이
        //따라다닐 캐릭터의 오브젝트 z축의 거리값
        float zDistasnceFromTarget = transform.position.z - followTarget.transform.position.z;//배경과 캐릭터의 차이
        //삼항 연산자
        //int a = (조건) ? (참) : (거짓)
        //Cam.tranform/Position.z = -10;
        //
        float clippingPlane = ((cam.transform.position.z) + zDistasnceFromTarget) > 0 ? //카메라 위치와 배경과 캐리터의 차이를 더한것을 판단
            cam.farClipPlane : cam.nearClipPlane;
            //0보다 클 떄5000 반환, 0보다 작을 때 0.1 반환

        //-2, 2 = 2
        float parallaFactore = Mathf.Abs(zDistasnceFromTarget) / clippingPlane ;

        Vector2 newPosition = startingPosition + camMoveSinceStart / parallaFactore;

        transform.position = new Vector3(newPosition.x, newPosition.y, startingZ);
        
    }
}
