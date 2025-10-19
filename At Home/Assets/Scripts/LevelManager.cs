using UnityEngine;

public class LevelManager : MonoBehaviour
{
    Player player;
    [SerializeField] GameObject[] checkPoints;
    [SerializeField] GameObject[] respawnpoints;
    [SerializeField] GameObject transitionPanel;
    GameObject currentCheckPoint;
    GameObject currentRespawnPoint;
    int index = -1;
    public float respawnTime = 1.25f;

    private void Awake()
    {
        player = FindAnyObjectByType<Player>();
    }

    public void ActivateCheckpointOnDeath()
    {
        transitionPanel.SetActive(true);
        Invoke(nameof(SpawnPlayerAtSpawnPoint), respawnTime);
    }

    void SpawnPlayerAtSpawnPoint()
    {
        transitionPanel.SetActive(false);
        player.transform.position = currentRespawnPoint.transform.position;
        player.anim.ResetTrigger("dead");
        player.isDead = false;
    }

    public void UpdateCheckPointAndSpawnPoint()
    {
        if(index + 1 < checkPoints.Length)
        {
            index++;
            currentCheckPoint = checkPoints[index];
            currentRespawnPoint= respawnpoints[index];
        }
    }
}
