using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public Transform toFollow;
    public float offset;

    void Start() {
        offset = 6.0f;
    }

    void LateUpdate(){
        if (toFollow)
        {
            transform.position = new Vector3(toFollow.position.x + offset, transform.position.y, transform.position.z);
        }
    }
}
