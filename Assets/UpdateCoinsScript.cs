using TMPro;
using UnityEngine;
using Yarn.Unity;

public class UpdateCoinsScript : MonoBehaviour
{
    private InMemoryVariableStorage variableStorage;
    private DialogueRunner dialogueRunner;

    private System.Single amountOfCoins;
    private TMP_Text textComponent;

    void Start()
    {
        dialogueRunner = UnityEngine.Object.FindFirstObjectByType<DialogueRunner>();
        variableStorage = UnityEngine.Object.FindFirstObjectByType<Yarn.Unity.InMemoryVariableStorage>();

        dialogueRunner.onDialogueComplete.AddListener(UpdateCoins);
        textComponent = gameObject.GetComponent<TMP_Text>();

        
    }



    void UpdateCoins()
    {
        variableStorage.TryGetValue("$coins", out amountOfCoins);
        textComponent.text = $"{amountOfCoins}";

    }
}
