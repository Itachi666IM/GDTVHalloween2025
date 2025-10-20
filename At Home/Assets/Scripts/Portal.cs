using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class Portal : MonoBehaviour
{
    bool canTP;
    SFX sfx;

    private void Awake()
    {
        sfx = GetComponent<SFX>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            canTP = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            canTP = false;
        }
    }

    private void Update()
    {
        if (canTP)
        {
            if (Keyboard.current.eKey.wasPressedThisFrame)
            {
                sfx.PlayMySound();
                Invoke(nameof(Teleport), 1f);
            }
        }

    }

    void Teleport()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
