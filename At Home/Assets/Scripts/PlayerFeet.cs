using UnityEngine;

public class PlayerFeet : MonoBehaviour
{
    SFX sfx;

    private void Awake()
    {
        sfx = GetComponent<SFX>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            sfx.PlayMySound();
            Destroy(collision.gameObject);
        }
    }
}
