using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform follow;
    [SerializeField] bool followX = true, followY = true, followZ = true;

    Vector3 offset;

    private void Start()
    {
        offset = follow.position - transform.position;
    }

    void Update()
    {
        CameraMove();
    }

    void CameraMove()
    {
        Vector3 newPos;
        newPos.x = followX ? follow.position.x - offset.x : transform.position.x;
        newPos.y = followY ? follow.position.y - offset.y : transform.position.y;
        newPos.z = followZ ? follow.position.y - offset.z : transform.position.z;
        transform.position = newPos;
    }
}
