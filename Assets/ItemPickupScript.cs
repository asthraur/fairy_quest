using UnityEngine;
using Yarn.Unity;

public class ItemPickupScript : MonoBehaviour
{
    private InMemoryVariableStorage variableStorage;


    private GameObject itemContainer;
    public GameObject itemPrefab;

    private bool hasItem = false;

    private GameObject itemInstance;


    void Start()
    {
        variableStorage = UnityEngine.Object.FindFirstObjectByType<Yarn.Unity.InMemoryVariableStorage>();

    }

    private void OnMouseDown()
    {
        //variableStorage.TryGetValue($"${gameObject.name}", out inInventory);
        Debug.Log("Clicked");
        variableStorage.SetValue($"${gameObject.transform.parent.gameObject.name}", true);
        Destroy(gameObject.transform.parent.gameObject);

        UpdateItems();
    }

    void UpdateItems()
    {
        itemContainer = GameObject.FindGameObjectWithTag("ItemContainer");
        variableStorage.TryGetValue($"${itemPrefab.name}", out hasItem);
        if (hasItem && !itemInstance)
        {
            itemInstance = Instantiate(itemPrefab);
            //itemInstance.transform.parent = itemContainer.transform;
            itemInstance.transform.SetParent(itemContainer.transform, false);
        }
    }
}
