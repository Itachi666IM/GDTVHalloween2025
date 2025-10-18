using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class Portal : MonoBehaviour
{
    bool canTP;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            canTP = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            canTP = false;
        }
    }

    private void Update()
    {
        if(canTP)
        {
            if (Keyboard.current.eKey.wasPressedThisFrame)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
        
    }
}
