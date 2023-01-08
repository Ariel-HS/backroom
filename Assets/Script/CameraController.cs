using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    private float currentPosY;
    private Vector3 velocity = Vector3.zero;

    private void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, new Vector3(transform.position.x, currentPosY, transform.position.z), 
        ref velocity, speed);
    }

    public void MoveToNewRoom(Transform _newRoom)
    {
        currentPosY = _newRoom.position.y;
    }
}
