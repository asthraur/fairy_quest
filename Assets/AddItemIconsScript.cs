using UnityEngine;
using Yarn.Unity;

public class AddItemIconsScript : MonoBehaviour
{
    private InMemoryVariableStorage variableStorage;
    private DialogueRunner dialogueRunner;

    public GameObject itemContainer;
    public GameObject itemPrefab;

    private bool hasItem = false;

    private GameObject itemInstance;




    void Start()
    {
        dialogueRunner = UnityEngine.Object.FindFirstObjectByType<DialogueRunner>();
        variableStorage = UnityEngine.Object.FindFirstObjectByType<Yarn.Unity.InMemoryVariableStorage>();

        dialogueRunner.onDialogueComplete.AddListener(UpdateItems); 
    }

    void UpdateItems()
    {
        variableStorage.TryGetValue($"${itemPrefab.name}", out hasItem);
        if(hasItem && !itemInstance)
        {
            itemInstance = Instantiate(itemPrefab);
            itemInstance.transform.parent = itemContainer.transform;
        }
    }
}
