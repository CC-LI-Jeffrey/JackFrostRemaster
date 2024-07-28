using System;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Camera camera;
    [SerializeField] private Transform player;
    [SerializeField] private Transform left;
    [SerializeField] private Transform right;
    [SerializeField] private Transform up;
    [SerializeField] private Transform down;

    private void Start()
    {
        camera = Camera.main;
    }

    void Update()
    {
        Vector3 camPos = camera.transform.position;
        camPos.x = player.position.x;
        camPos.y = player.position.y;
        
        if (camPos.x < left.position.x)
            camPos.x = left.position.x;

        if (camPos.x > right.position.x)
            camPos.x = right.position.x;

        if (camPos.y > up.position.y)
            camPos.y = up.position.y;

        if (camPos.y < down.position.y)
            camPos.y = down.position.y;

        camera.transform.position = camPos;
    }
}
