using UnityEngine;

public class SetPositionScript : MonoBehaviour
{
    public GameObject originalPrefab;
    void Start()
    {
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, originalPrefab.transform.position.y, gameObject.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
