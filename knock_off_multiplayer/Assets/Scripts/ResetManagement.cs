using UnityEngine;
using System.Collections;

public class ResetManagement : MonoBehaviour
{
    private bool[] outtaLives;
    private int playersLeft;

    private Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        outtaLives = new bool[] {false,false,false,false};
        MessageManager.getInstance().RegisterListener(new Listener("LivesRunOut", gameObject, "outOfLives"));
        playersLeft = ScoreKeeper.getInstance().getNumPlayers();
    }

    void OnTriggerExit(Collider col)
    {

        if (col.gameObject.tag == "Player")
        {
            
            //rb = GetComponent<Rigidbody>();
            string temp = col.gameObject.name;
            Debug.Log(temp + "fell");
            int checkThis = int.Parse(temp[8].ToString()) - 1 ;
            Debug.Log(" "+checkThis);
            ScoreKeeper.getInstance().death(checkThis);
            if (!isOutOfLives(checkThis))
            {
                Debug.Log("had enough lives: " + playerMovement.playerBS);
                col.transform.position = playerMovement.initialPosition;
                col.transform.rotation = playerMovement.initialRotation;
                

                rb = col.GetComponent<Rigidbody>();
                rb.velocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;
            }  
            else
            {
                Debug.Log("Out of lives when checked");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(playersLeft <= 1)
        {
            Debug.Log("level over");
            Application.LoadLevel(3);
        }
    }


    bool isOutOfLives(int checka)
    {
        bool result = false;
        if (outtaLives[checka])
            result = true; 
        return result;
    }




    void outOfLives(Message m)
    {
        Debug.Log(m.MessageValue);
        switch (m.MessageValue)
        {
            case "1":
                outtaLives[0] = true;
                playersLeft--;
                break;
            case "2":
                outtaLives[1] = true;
                playersLeft--;
                break;
            case "3":
                outtaLives[2] = true;
                playersLeft--;
                break;
            case "4":
                outtaLives[3] = true;
                playersLeft--;
                break;
            default:
                Debug.Log("passed this to out of lives" + m.MessageValue);
                break;
        }
    }
}
