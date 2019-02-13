using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IkTargetFollow : MonoBehaviour
{
    public Transform toFollow;
    public bool rotate;
    private Quaternion offset;

    void LateUpdate()
    {
        transform.position = toFollow.position;

        if (rotate) {
            transform.rotation = toFollow.rotation;
        }
    }
}
