using UnityEngine;
using System.Collections;

public class ScoreKeeper : MonoBehaviour {

    private static ScoreKeeper instance = null;
    //public AudioClip clip;
    private int[] livesLeft = new int[4];
    private int numPlyrs;

    public class Kill
    {
        public int killerID;
        public int victimID;

        public Kill(int kID, int vID)
        {
            killerID = kID;
            victimID = vID;
        }
    }

    public ArrayList kills = new ArrayList();

	// Use this for initialization
	void Start () {
        if (instance == null)
            instance = this;


        DontDestroyOnLoad(gameObject);
        MessageManager.getInstance().RegisterListener(new Listener("KillMessage", gameObject, "HandleKill"));
        updateLives();
        Debug.Log("start method");
        switch (numPlyrs)
        {
            case 2:
                Destroy(GameObject.Find("player (4)"));
                Destroy(GameObject.Find("player (3)"));
                Debug.Log("2 players, destroyed player 4 + 3");
                break;
            case 3:
                Destroy(GameObject.Find("player (4)"));
                Debug.Log("3 players, destroyed player 4");
                break;
            case 4:
                Debug.Log("4 players");
                break;
            default:
                Debug.Log("default case you fuckwad");
                break;
        }
    }
	
	// Update is called once per frame
	void Update () {
        //SoundManager.getInstance().playSound(clip, Vector3.zero);
	}

    protected ScoreKeeper() { }

    public void updateLives()
    {
        int allLives = SettingsManager.getInstance().getLives();
        Debug.Log("lives read in by score keeper: " + allLives);
        numPlyrs = SettingsManager.getInstance().getNumPlayers();
        Debug.Log("num of players" + numPlyrs);
        livesLeft[0] = allLives;
        livesLeft[1] = allLives;
        livesLeft[2] = allLives;
        livesLeft[3] = allLives;

        Debug.Log(livesLeft[0].ToString());
    }

    public static ScoreKeeper getInstance()
    {
        if (instance == null)
        {
            GameObject sam = new GameObject();
            instance = sam.AddComponent<ScoreKeeper>();
            DontDestroyOnLoad(sam);
        }

        return instance;
    }

    public int getNumPlayers()
    {
        return numPlyrs;
    }

    void Awake()
    {
        
    }
    
    public bool death(int playa)
    {
        bool result = true;
        switch (++playa)
        {
            case 1:
                livesLeft[0]--;
                Debug.Log("1 is vic. lives left: " + livesLeft[0]);
                if (livesLeft[0] < 0)
                {
                    MessageManager.getInstance().SendToAllListeners(new Message(gameObject, "LivesRunOut", "1"));
                    Debug.Log("player 1 out of lives");
                }
                break;
            case 2:
                livesLeft[1]--;
                Debug.Log("2 is vic. lives left: " + livesLeft[1]);
                if (livesLeft[1] < 0)
                {
                    MessageManager.getInstance().SendToAllListeners(new Message(gameObject, "LivesRunOut", "2"));
                    Debug.Log("player 2 out of lives");
                }
                break;
            case 3:
                livesLeft[2]--;
                Debug.Log("3 is vic. lives left: " + livesLeft[2]);
                if (livesLeft[2] < 0)
                {
                    MessageManager.getInstance().SendToAllListeners(new Message(gameObject, "LivesRunOut", "3"));
                    Debug.Log("player 3 out of lives");
                }
                break;
            case 4:
                livesLeft[3]--;
                Debug.Log("4 is vic. lives left: " + livesLeft[3]);
                if (livesLeft[3] < 0)
                {
                    MessageManager.getInstance().SendToAllListeners(new Message(gameObject, "LivesRunOut", "4"));
                    Debug.Log("player 4 out of lives");
                }
                break;
            default:
                break;
        }

        return result;
    }
    
     
    public void HandleKill(Message m)
    {
        string text = m.MessageValue;
        int kIDt = text[0];
        int vIDt = text[2];
        kills.Add(new Kill(kIDt, vIDt));
        switch (vIDt)
        {
            case 1:
                Debug.Log("1 is vic");
                livesLeft[0]--;
                if(livesLeft[0] < 0)
                    MessageManager.getInstance().SendToAllListeners(new Message(gameObject, "outOfLives", ""+1));
                break;
            case 2:
                Debug.Log("2 is vic");
                livesLeft[1]--;
                if (livesLeft[1] < 0)
                    MessageManager.getInstance().SendToAllListeners(new Message(gameObject, "outOfLives", ""+2));
                break;
            case 3:
                Debug.Log("3 is vic");
                livesLeft[2]--;
                if (livesLeft[2] < 0)
                    MessageManager.getInstance().SendToAllListeners(new Message(gameObject, "outOfLives", ""+3));
                break;
            case 4:
                Debug.Log("4 is vic");
                livesLeft[3]--;
                if (livesLeft[3] < 0)
                    MessageManager.getInstance().SendToAllListeners(new Message(gameObject, "outOfLives", ""+4));
                break;
            default:
                break;
        }

    }
}
