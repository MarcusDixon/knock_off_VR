using UnityEngine;
using System.Collections;

public class rotateStage : MonoBehaviour {

    public float rotation;

    void Start()
    {
    }
    void FixedUpdate()
    {

        transform.Rotate(new Vector3(0, 0, rotation) * Time.deltaTime);
    }
}