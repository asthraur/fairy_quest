using UnityEditor.Tilemaps;
using UnityEngine;

public class DontDestroyOnLoadScript : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject dialogueSystemPrefab;
    public GameObject uiPrefab;

    private GameObject playerInstance;
    private GameObject dialogueSystemInstance;
    private GameObject uiInstance;

    private void Start()
    {
        if(GameObject.FindGameObjectsWithTag("Player").Length == 0)
        {
            playerInstance = Instantiate(playerPrefab);
        }
        else
        {
            playerInstance = GameObject.FindGameObjectWithTag("Player");
        }

        if(GameObject.FindGameObjectsWithTag("DialogueSystemOG").Length != 0 && GameObject.FindGameObjectsWithTag("DialogueSystem").Length != 0)
        {
            Destroy(GameObject.FindGameObjectWithTag("DialogueSystemOG"));
            dialogueSystemInstance = GameObject.FindGameObjectWithTag("DialogueSystem");

        }
        else if(GameObject.FindGameObjectsWithTag("DialogueSystemOG").Length != 0)
        {
            dialogueSystemInstance = GameObject.FindGameObjectWithTag("DialogueSystemOG");
            dialogueSystemInstance.tag = "DialogueSystem";

        }
        else if(GameObject.FindGameObjectsWithTag("DialogueSystem").Length != 0)
        {
            dialogueSystemInstance = GameObject.FindGameObjectWithTag("DialogueSystem");

        }



        if (GameObject.FindGameObjectsWithTag("UI").Length == 0)
        {
            uiInstance = Instantiate(uiPrefab);
        }
        else
        {
            uiInstance = GameObject.FindGameObjectWithTag("UI");
        }

        DontDestroyOnLoad(playerInstance);
        DontDestroyOnLoad(dialogueSystemInstance);
        DontDestroyOnLoad(uiInstance);

    }

}
