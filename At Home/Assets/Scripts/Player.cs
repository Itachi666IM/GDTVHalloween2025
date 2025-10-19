using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    BoxCollider2D myCollider;
    [HideInInspector]public Animator anim;
    Vector2 moveDirection;
    LevelManager levelManager;
    [SerializeField] private float speed;
    [SerializeField] private float jumpSpeed;
    public LayerMask platformLayer;
    public bool isDead = false;
    bool canJump;
    bool isFacingRight = false;
    [HideInInspector] public int coins;
    [SerializeField] TMP_Text speedText;
    [SerializeField] TMP_Text coinText;
    private void Awake()
    {
        levelManager = FindAnyObjectByType<LevelManager>();
        rb = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if(!isDead)
        {
            FlipSprite();
        }
        if (myCollider.IsTouchingLayers(platformLayer))
        {
            canJump = true;
        }
        else
        {
            canJump = false;
        }
        speedText.text = "Speed - " + Mathf.Abs(Mathf.Round(rb.linearVelocity.x)).ToString();
        coinText.text = "Coins - " + coins.ToString();
    }


    void OnMove(InputValue value)
    {
        moveDirection = value.Get<Vector2>();
    }

    void OnJump(InputValue value)
    {
        if (value.isPressed && canJump &&!isDead)
        {
            anim.SetTrigger("jump");
            rb.linearVelocityY += jumpSpeed;
        }

    }
    private void FixedUpdate()
    {
        if(!isDead)
        {
            Walk();
        }
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

    public void RespawnPlayerAtCheckpoint()
    {
        anim.SetTrigger("dead");
        isDead = true;
        levelManager.ActivateCheckpointOnDeath();
    }
}