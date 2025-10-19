using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    LevelManager levelManager;
    private void Awake()
    {
        levelManager = FindAnyObjectByType<LevelManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            levelManager.UpdateCheckPointAndSpawnPoint();
            gameObject.SetActive(false);
        }
    }
}
