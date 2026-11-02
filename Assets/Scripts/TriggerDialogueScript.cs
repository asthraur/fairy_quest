using System;
using UnityEngine;
using Yarn.Unity;
using TMPro;

public class TriggerDialogueScript : MonoBehaviour
{
    private DialogueRunner dialogueRunner;
    public GameObject pressE;

    private InMemoryVariableStorage variableStorage;


    private void Start()
    {
        dialogueRunner = UnityEngine.Object.FindFirstObjectByType<DialogueRunner>();
        variableStorage = UnityEngine.Object.FindFirstObjectByType<Yarn.Unity.InMemoryVariableStorage>();

    }

    private void OnTriggerStay(Collider other)
    {
        
        if (dialogueRunner.IsDialogueRunning == true)
        {
            pressE.SetActive(false);
        }
        else
        {
            pressE.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if(dialogueRunner.IsDialogueRunning == false)
            {
                dialogueRunner.StartDialogue($"{gameObject.name}_Quest");
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        pressE.SetActive(false);
    }

    
}
