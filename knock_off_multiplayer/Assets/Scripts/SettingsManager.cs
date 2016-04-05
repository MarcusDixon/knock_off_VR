using UnityEngine;
using System.Collections;

public class SettingsManager : MonoBehaviour {

    private static SettingsManager instance = null;

    private int level_var = 1;
    private int num_players = 2;
    private int stock;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    protected SettingsManager() { }

    public static SettingsManager getInstance()
    {
        if (instance == null)
        {
            GameObject sam = new GameObject();
            instance = sam.AddComponent<SettingsManager>();
            DontDestroyOnLoad(sam);
        }
        return instance;
    }

    void Awake()
    {
        
    }

    public void setLives(int input)
    {
        Debug.Log("set lives " + input);
        if (input > 0 && input < 11)
            stock = input;
        ScoreKeeper.getInstance().updateLives();
    }

    public void setNumPlayers(int input)
    {
        if (input > 2 && input < 5)
            num_players = input;
    }

    public void setLevel(int input)
    {
        //not implemented until we have more levels
    }

    public int getLives()
    {
        return stock;
    }

    public int getNumPlayers()
    {
        return num_players;
    }

    public int getLevel()
    {
        return level_var;
    }
}
