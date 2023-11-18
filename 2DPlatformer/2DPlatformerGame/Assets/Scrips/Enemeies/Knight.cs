using System.Collections;
using System.Collections.Generic;
using System.Drawing.Text;
using UnityEngine;


public enum WalkableDirection
{
    Right,
    Left,
}


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent (typeof(CapsuleCollider2D))]
[RequireComponent(typeof(TouchingDirections))]
public class Knight : MonoBehaviour
{
    float walkSpeed = 3.0f;
    Rigidbody2D rb;
    CapsuleCollider2D capsuleCollider;
    TouchingDirections touchingDirections;
    private WalkableDirection walkableDirection = WalkableDirection.Right;
    private Vector2 walkDirectionVector = Vector2.right;

    public WalkableDirection WalkDirection
    {
        get { return walkableDirection; }
        set
        {
            if (walkableDirection != value)
            {
                gameObject.transform.localScale = new Vector2(gameObject.transform.localScale.x * -1, gameObject.transform.localScale.y);
                if(value == WalkableDirection.Right)
                {
                    walkDirectionVector = Vector2.right;
                    
                }
                else if(value == WalkableDirection.Left)
                {
                    walkDirectionVector = Vector2.left;

                }
            }
            walkableDirection = value;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        touchingDirections = GetComponent<TouchingDirections>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(touchingDirections.isGrounded && touchingDirections.IsOnWall)
        {
            FlipDirection();
        }
        rb.velocity = new Vector2(walkSpeed * walkDirectionVector.x, rb.velocity.y);
    }
    
    private void FlipDirection()
    {
        if(WalkDirection == WalkableDirection.Right)
        {
            WalkDirection = WalkableDirection.Left;
        }
        else if(WalkDirection == WalkableDirection.Left)
        {
            WalkDirection = WalkableDirection.Right;
        }
    }

}
