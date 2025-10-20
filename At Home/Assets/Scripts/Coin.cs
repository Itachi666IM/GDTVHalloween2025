using UnityEngine;

public class Coin : MonoBehaviour
{
    Player player;
    SFX sfx;
    private void Awake()
    {
        player = FindAnyObjectByType<Player>();
        sfx = GetComponent<SFX>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            player.coins++;
            sfx.PlayMySound();
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<CircleCollider2D>().enabled = false;
            Invoke(nameof(DestroyGameObject), 1f);
        }
    }

    void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}
