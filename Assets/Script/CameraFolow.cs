using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFolow : MonoBehaviour
{
    [Range(0.01f, 0.1f)]
    [SerializeField] private float cameraMoveSpeed;
    [SerializeField] private Transform target;


    private void LateUpdate()
    {
        Vector3 destination = new Vector3(target.position.x, target.position.y, -10f);
        transform.position =  Vector3.Lerp(transform.position, destination, cameraMoveSpeed);
    }
}
