using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaEffect : MonoBehaviour
{

    public Camera cam;
    public Transform followTarget;

    Vector2 startingPosition;//���� Transform�� Position

    float startingZ;// -1.2, -0.6, -0.24�� ���ϰ� �÷��̾��� �������� z���� ����

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
        startingZ = transform.position.z - followTarget.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        //ī�޶��� ���� ���� ���� ��ġ�� ���� Vector2
        Vector2 camMoveSinceStart = (Vector2)cam.transform.position - startingPosition;//ī�޶�� ���� �Ÿ� ����
        //����ٴ� ĳ������ ������Ʈ z���� �Ÿ���
        float zDistasnceFromTarget = transform.position.z - followTarget.transform.position.z;//���� ĳ������ ����
        //���� ������
        //int a = (����) ? (��) : (����)
        //Cam.tranform/Position.z = -10;
        //
        float clippingPlane = ((cam.transform.position.z) + zDistasnceFromTarget) > 0 ? //ī�޶� ��ġ�� ���� ĳ������ ���̸� ���Ѱ��� �Ǵ�
            cam.farClipPlane : cam.nearClipPlane;
            //0���� Ŭ ��5000 ��ȯ, 0���� ���� �� 0.1 ��ȯ

        //-2, 2 = 2
        float parallaFactore = Mathf.Abs(zDistasnceFromTarget) / clippingPlane ;

        Vector2 newPosition = startingPosition + camMoveSinceStart / parallaFactore;

        transform.position = new Vector3(newPosition.x, newPosition.y, startingZ);
        
    }
}
