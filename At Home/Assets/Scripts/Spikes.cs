using UnityEngine;

public class Spikes : MonoBehaviour
{
    Player player;

    private void Awake()
    {
        player = FindAnyObjectByType<Player>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            player.RespawnPlayerAtCheckpoint();
        }
    }
}
