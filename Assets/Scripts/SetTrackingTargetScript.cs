using Unity.Cinemachine;
using UnityEngine;

public class SetTrackingTargetScript : MonoBehaviour
{
    private GameObject player;
    private CinemachineCamera cinemachineCamera;

    private void Update()
    {
        if (!player)
        {
            if (GameObject.FindGameObjectWithTag("Player"))
            {
                SetTarget();
            }
        }
    }
    private void SetTarget()
    {
        cinemachineCamera = gameObject.GetComponent<CinemachineCamera>();
        player = GameObject.FindGameObjectWithTag("Player");

        cinemachineCamera.Follow = player.transform;
        cinemachineCamera.LookAt = player.transform;
    }

}
