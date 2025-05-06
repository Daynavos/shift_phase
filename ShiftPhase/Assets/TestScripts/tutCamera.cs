using UnityEngine;

public class tutCamera : MonoBehaviour
{
    private GameObject targetCamera;

    private void Start()
    {
        targetCamera = GameObject.FindGameObjectWithTag("targetCamera");

        if (targetCamera == null)
        {
            Debug.LogError("Camera with tag 'targetCamera' not found!");
        }
    }

    void Update()
    {
        if (targetCamera != null)
        {
            Vector3 camPosition = targetCamera.transform.position;
            camPosition.x = transform.position.x;
            targetCamera.transform.position = camPosition;
        }
    }
}