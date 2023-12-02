using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int scorce;
    public bool isJumping = false;
    public float JumpPower = 1;
    Rigidbody rb;
    AudioSource audio;
    public GameManagerlogic Manager;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            isJumping = true;
            rb.AddForce(new Vector3( 0, JumpPower / 2, 0), ForceMode.Impulse);
        }
    }

    private void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");
        rb.AddForce(new Vector3(h / 5, 0, v / 5), ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Ground")
        {
            isJumping = false;
        }
        else if (collision.gameObject.name == "Fall")
        {
            SceneManager.LoadScene("stage" + Manager.Stage);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item")
        {
            audio.Play();
        }
        else if(other.tag == "Finish")
        {
            if (Manager.TotalScorce == scorce)
            {
                //game clear
                SceneManager.LoadScene("stage" + (Manager.Stage + 1));
            }
            else
            {
                //retry
                SceneManager.LoadScene("stage" + Manager.Stage);
            }
        }
        
    }
    
}
