using UnityEngine;
using System.Collections;

public class holdCharc : MonoBehaviour {

    private Rigidbody test;
    private GameObject center;
    private float distance = 0;

    void Start()
    {
        center = GameObject.Find("center");
    }

    void OnTriggerStay(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            test = col.GetComponent<Rigidbody>();

            distance = Vector3.Distance(center.transform.position, test.transform.position);

            if (distance < 1.741f)
            {
                col.transform.parent = GameObject.Find("Cylinder004").transform;
            }
            else if (distance < 3.252f)
            {
                col.transform.parent = GameObject.Find("Cylinder003").transform;
            }
            else if (distance < 4.753f)
            {
                col.transform.parent = GameObject.Find("Cylinder002").transform;
            }
            else
            {
                col.transform.parent = gameObject.transform;
            }
        }
    }
}
