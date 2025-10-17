using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    BoxCollider2D myCollider;
    Animator anim;
    Vector2 moveDirection;
    [SerializeField] private float speed;
    [SerializeField] private float jumpSpeed;
    public LayerMask platformLayer;
    bool canJump;
    bool isFacingRight = false;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        FlipSprite();
        if (myCollider.IsTouchingLayers(platformLayer))
        {
            canJump = true;
        }
        else
        {
            canJump = false;
        }
    }


    void OnMove(InputValue value)
    {
        moveDirection = value.Get<Vector2>();
    }

    void OnJump(InputValue value)
    {
        if (value.isPressed && canJump)
        {
            anim.SetTrigger("jump");
            rb.linearVelocityY += jumpSpeed;
        }

    }
    private void FixedUpdate()
    {
        Walk();
    }

    void Walk()
    {
        Vector2 playerVelocity = new Vector2(moveDirection.x * speed * Time.fixedDeltaTime, 0f);
        rb.linearVelocity += playerVelocity;
        if (Mathf.Abs(moveDirection.x) > 0f)
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }
    }

    void FlipSprite()
    {
        if (moveDirection.x < 0 && isFacingRight)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            isFacingRight = false;
        }
        if (moveDirection.x > 0 && !isFacingRight)
        {
            transform.rotation = Quaternion.Euler(0, 180f, 0);
            isFacingRight = true;
        }
    }
}