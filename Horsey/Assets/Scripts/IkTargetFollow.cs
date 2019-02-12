using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IkTargetFollow : MonoBehaviour
{
    public Transform toFollow;

    void LateUpdate()
    {
        transform.position = toFollow.position;
    }
}
