using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrbit : MonoBehaviour {

    // What to look at and what to orbit around
    public Transform target;

    // stride (or Schrittweite)
    public float horizMove = 1f;
    public float vertMove = 1f;

    public void MoveHorizontal (bool left)
    {
        // direction
        float dir = 1;
        if (!left)
            // right
            dir *= -1;

        // RotateAround( Vector3 point, Vector3 axis, and float angle)
        transform.RotateAround(target.position, Vector3.up, horizMove * dir);
    }

    public void MoveVertical(bool up)
    {
        float dir = 1;
        if (!up)
            dir *= -1;

        transform.RotateAround(target.position, transform.TransformDirection(Vector3.right), vertMove * dir);
    }
}
