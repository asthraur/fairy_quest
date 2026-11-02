using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FairyDoorScript : MonoBehaviour
{

    private string task1_fairyScene = "FairyForestScene";
    private string task1_humanScene = "ForestScene";
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (!player)
        {
            player = GameObject.FindGameObjectWithTag("Player");
        }
    }


    private void OnMouseDown()
    {
        player.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z);
        if (SceneManager.GetActiveScene().name == task1_humanScene)
        {
            SceneManager.LoadScene(task1_fairyScene);
        }
        else if (SceneManager.GetActiveScene().name == task1_fairyScene)
        {
            SceneManager.LoadScene(task1_humanScene);
        }
    }

}
