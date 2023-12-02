using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    Transform PlayerTrensform;
    Vector3 Offset;
    // Start is called before the first frame update
    void Awake()
    {
        PlayerTrensform = GameObject.FindGameObjectWithTag("Player").transform;
        Offset = transform.position - PlayerTrensform.position;
    }

    void LateUpdate()
    {
        transform.position = PlayerTrensform.position + Offset;
    }
}
