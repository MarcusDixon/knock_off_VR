using UnityEngine;
using System.Collections;

public class fistControl : MonoBehaviour
{

    public float thrust;
    public float thrust2 = 45f;
    private Rigidbody rb;
    private float leftright;
    private float thereback;
    public int playerNumber;
    Vector3 offset = new Vector3(0f, 0f, 0f);
    GameObject player;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("player (" + playerNumber + ")");
        offset = transform.position - player.transform.position;
    }



    void Update()
    {
        Vector3 rotPosition;
        rb.angularVelocity = Vector3.zero;
        var rsx = Input.GetAxis("RightStickX" + playerNumber);
        var rsy = Input.GetAxis("RightStickY" + playerNumber);
        Vector3 punchDirection = new Vector3(rb.transform.position.x - player.transform.position.x, 0, rb.transform.position.z - player.transform.position.z);

        if (rsx != 0 || rsy != 0)
        {

            rotPosition = new Vector3(player.transform.position.x + Input.GetAxis("RightStickX" + playerNumber), 0.5f,
                            player.transform.position.z + Input.GetAxis("RightStickY" + playerNumber));


            rb.transform.position = rotPosition;
            offset = transform.position - player.transform.position;

        }
        if (Input.GetAxis("Trigger" + playerNumber) > 0)
        {
            //rb.AddForce(Vector3.forward.normalized * thrust);
            rb.AddForce(punchDirection.normalized * thrust);

        }
        else
        {

            transform.position = player.transform.position + offset;
        }
    }


    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.rigidbody.AddForce(Vector3.one.normalized * thrust2);
            //Debug.Log("hit");
        }
    }

}
