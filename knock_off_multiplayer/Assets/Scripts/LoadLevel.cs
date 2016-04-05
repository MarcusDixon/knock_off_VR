using UnityEngine;
using System.Collections;

public class LoadLevel : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    public void quitGame()
    {
        Application.Quit();
    }

    public void LoadScene(int level)
    {
        Application.LoadLevel(level);
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetButton("ButtonA1"))
        {
            Application.LoadLevel("scenee");
        }*/
    }
}
