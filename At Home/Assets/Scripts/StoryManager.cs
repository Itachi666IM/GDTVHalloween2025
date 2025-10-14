using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using System.Collections;

public class StoryManager : MonoBehaviour
{
    [SerializeField] GameObject dad;
    [SerializeField] GameObject son;
    public string[] dialogs;
    [SerializeField] GameObject nextButton;
    [SerializeField] TMP_Text dialogueText;
    [SerializeField] TMP_Text speakerText;
    public float typingSpeed;
    string currentDialog;
    int index = 0;

    private void Awake()
    {
        dialogueText.text = "";
        currentDialog = dialogs[index];
        son.SetActive(true);
        speakerText.text = "Son";
        StartCoroutine(WriteSentence());
    }

    IEnumerator WriteSentence()
    {
        dialogueText.text = "";
        foreach( char c in currentDialog.ToCharArray() )
        {
            dialogueText.text += c;
            yield return new WaitForSeconds(typingSpeed);
        }
        yield return new WaitForSeconds(typingSpeed);
        nextButton.SetActive(true);
    }

    public void NextSentence()
    {
        nextButton.SetActive(false);
        if(index +1 < dialogs.Length)
        {
            index++;
            if(speakerText.text == "Son")
            {
                speakerText.text = "Dad";
                son.SetActive(false);
                dad.SetActive(true);
            }
            else if(speakerText.text == "Dad")
            {
                speakerText.text = "Son";
                dad.SetActive(false);
                son.SetActive(true);
            }

            currentDialog = dialogs[index];
            StartCoroutine(WriteSentence());
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    public void SkipStory()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
