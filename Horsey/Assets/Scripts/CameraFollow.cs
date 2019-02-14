using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    public Transform toFollow;
    public float offset;

    void Start() {
        offset = 1.5f;
    }

    void LateUpdate() {
        if(toFollow != null)
            transform.position = new Vector3(toFollow.position.x + offset, transform.position.y, transform.position.z);
    }
}
