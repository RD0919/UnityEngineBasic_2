using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchingDirections : MonoBehaviour
{
    private bool _isGrounded = true;
    public bool isGrounded
    {
        get { return _isGrounded; }
        set { _isGrounded = value;
            animator.SetBool("IsGrounded", _isGrounded);
            }
    }


    private Vector2 wallCheckDirection => gameObject.transform.localScale.x > 0? Vector2.right : Vector2.left;
    private bool _isOnWall;
    public bool IsOnWall
    {
        get { return _isOnWall; }
        set
        {
            _isOnWall = value;
            animator.SetBool("IsOnWall", _isOnWall);
        }
    }

    private bool _isOnceiling;
    public bool IsOnCeiling
    {
        get { return _isOnceiling; }
        set
        {
            _isOnceiling = value;
            animator.SetBool("IsOnCeiling", _isOnceiling);
        }
    }

    CapsuleCollider2D touchingCol;
    Animator animator;

    public ContactFilter2D cactFilter;
    [SerializeField] private float groundDistance = 0.05f;
    [SerializeField] private float wallDistance = 0.2f;
    [SerializeField] private float ceilingDistance = 0.05f;

    RaycastHit2D[] groundHits = new RaycastHit2D[5];
    RaycastHit2D[] wallHits = new RaycastHit2D[5];
    RaycastHit2D[] ceilingHits = new RaycastHit2D[5];

    private void Awake()
    {
        touchingCol = GetComponent<CapsuleCollider2D>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        isGrounded = touchingCol.Cast(Vector2.down, cactFilter, groundHits, groundDistance) > 0;
        IsOnWall = touchingCol.Cast(wallCheckDirection, cactFilter, wallHits, wallDistance) > 0;
        IsOnCeiling = touchingCol.Cast(Vector2.up, cactFilter, ceilingHits, ceilingDistance) > 0;
        Debug.Log(wallCheckDirection);
    }
}
