using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class playerMovement : NetworkBehaviour {

    public float thrust;
    private Rigidbody rb;
    private float leftright;
    private float thereback;
    public int player;
    public static int playerBS;
    public static Vector3 initialPosition;
    public static Quaternion initialRotation;
    public int lastHitter;

    // Use this for initialization
    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        initialPosition = transform.position;
        initialRotation = transform.rotation;
        MessageManager.getInstance().RegisterListener(new Listener("ResetPlayer", gameObject, "reset"));
        playerBS = player;
    }


        // Update is called once per frame
    void Update ()
    {
		if (isLocalPlayer) {
			return;
		}

        leftright = Input.GetAxisRaw("Horizontal" + player);
        thereback = Input.GetAxisRaw("Vertical" + player);
        rb.AddForce(new Vector3(leftright, 0f, thereback).normalized * thrust);
    }

    void reset(Message m)
    {
        //reset to original position
        transform.position = initialPosition;
        transform.rotation = initialRotation;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }

    void onCollisionEnter(Collision col)
    {
        Rigidbody gb = col.gameObject.GetComponent<Rigidbody>();
        string temp = gb.tag;
        if (temp[6] > 0 && temp[6] < 5)
        {
            int plNum = temp[6];
        }
    }

    //Networking stuff

	public override void OnStartLocalPlayer(){

		//only runs on the local player's avatar
		GetComponent<MeshRenderer>().material.color = Color.blue;
	}
}
