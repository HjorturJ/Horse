using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muscle : MonoBehaviour {
    public float musclePower;

    private float localRot;
    private Rigidbody2D rb;


    private void Start() {
        localRot = transform.localRotation.eulerAngles.z;
        rb = GetComponent<Rigidbody2D>();

    }

    private void FixedUpdate() {
        float tempRot = localRot;
        var angleForce = Mathf.DeltaAngle(transform.localRotation.eulerAngles.z, tempRot);
        var angleDirection = Mathf.Clamp(angleForce, -1f, 1f);
        rb.AddTorque(angleDirection * musclePower, ForceMode2D.Force);
    }
}
