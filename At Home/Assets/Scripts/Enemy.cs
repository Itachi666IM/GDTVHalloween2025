using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    CapsuleCollider2D myCapsuleCollider;
    public LayerMask platformLayer;
    Rigidbody2D rb;
    Player player;

    private void Awake()
    {
        myCapsuleCollider = GetComponent<CapsuleCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        player = FindAnyObjectByType<Player>();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(speed *  Time.fixedDeltaTime, 0);
    }

    private void Update()
    {
        if (!myCapsuleCollider.IsTouchingLayers(platformLayer))
        {
            FlipSprite();
        }
    }

    void FlipSprite()
    {
        speed = -speed;
        transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if(player!= null)
            {
                player.RespawnPlayerAtCheckpoint();
            }
        }
    }
}
