using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Item : MonoBehaviour
{
    public float rotateSpeed = 250;

    void Update()
    {
        transform.Rotate(Vector3.up * rotateSpeed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "Player")
        {
            Player player = other.GetComponent<Player>();
            player.scorce++;
            gameObject.SetActive(false);
        }
    }
}
