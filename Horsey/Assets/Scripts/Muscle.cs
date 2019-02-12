using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Muscle : MonoBehaviour {
    public float musclePower;

    private float _localRot;
    private Rigidbody2D _rb;


    private void Start() {
        _localRot = transform.localRotation.eulerAngles.z;
        _rb = GetComponent<Rigidbody2D>();

    }

    private void FixedUpdate() {
        float tempRot = _localRot;
        var angleForce = Mathf.DeltaAngle(transform.localRotation.eulerAngles.z, tempRot);
        var angleDirection = Mathf.Clamp(angleForce, -1f, 1f);
        _rb.AddTorque(angleDirection * musclePower, ForceMode2D.Force);
    }
}
