using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class menuControl : MonoBehaviour {

    private float players = 2;
    private float stock = 3;
    private float map = 1; 
    private Text numberText;
    private Text stockText;
    private Text mapText;
    private static float stock2;


    // Use this for initialization
    void Start () {
        
        //
        //
    }


	
	// Update is called once per frame
	void Update () {
        //
        //
    }

    public void setPlayerNumber(float players)
    {
        this.players = players;
        SettingsManager.getInstance().setNumPlayers((int)players);
        numberText = GetComponent<Text>();
        setNumberText();
    }

    public void setStockNumber(float stock)
    {
        this.stock = stock;
        SettingsManager.getInstance().setLives((int)stock);
        stockText = GetComponent<Text>();
        setStockText();
    }

    public void setMapNumber(float map)
    {
        this.map = map;
        mapText = GetComponent<Text>();
        setMapText();
    }

    public float getPlayerNumber()
    {
        return players;
    }

    public float getStockNumber()
    {
        return stock;
    }

    public float getMapNumber()
    {
        return this.map;
    }

    void setNumberText()
    {
        numberText.text = players.ToString();
    }

    void setStockText()
    {
        stockText.text = stock.ToString();
    }

    void setMapText()
    {
        mapText.text = map.ToString();
    }
}
