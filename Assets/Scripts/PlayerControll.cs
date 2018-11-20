using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerControll : MonoBehaviour {

    private int health;
    private int score;
    private int noOfHits;
	private float regainHealthTime;
    private float lastHitTime;
    private float maxComboDelay;
    private float lastComboTime;
    private int comboType;
	private GameObject manager;

    public Text scoreLbl;
    public Text comboLbl;
    public Image healthBar;
	public GameObject healthSymbol;
    public GameObject GameOver;
    public GameObject spawn;
    public GameObject playerBulletObject;

	// Use this for initialization
	void Start () {
        health = 100;
        score = 0;
        noOfHits = 0;
        maxComboDelay = 5;
		regainHealthTime = Time.time;
        lastHitTime = 0;
        lastComboTime = 0;
        comboType = 1;

        setCombo();
        setScore(0);

		manager = (GameObject)GameObject.FindGameObjectWithTag ("Manager");
    }


	// Update is called once per frame
	void Update () {

        if (Time.time - lastHitTime > maxComboDelay)
        {
            noOfHits = 0;
        }

        if(Time.time - lastComboTime > 5f)
        {
            comboType = 1;
            setCombo();
        }

		if (Time.time - regainHealthTime >= 60f) 
		{
			regainHealth ();
		}
    }

    public void gotHit(int amount)
    {
        health -= amount;
        healthBar.fillAmount = health/100f;

        if (health <= 0)
        {   
            endGame();
            return;
        }
			      
    }

	private void regainHealth()
	{
		health = 100;
		healthBar.fillAmount = 1f;

		if (healthSymbol == null)
			return;
		
		healthSymbol.SetActive (true);
		regainHealthTime = Time.time;
		StartCoroutine ("gotHealth");
	}

	private IEnumerator gotHealth()
	{
		yield return new WaitForSeconds(3f);
		healthSymbol.SetActive (false);
	}

    public void FirePlayer()
    {
        
        GameObject obj = (GameObject)Instantiate(playerBulletObject);

        if (obj == null)
            return;
		
		obj.GetComponent<bulletPlayer> ().player = gameObject;
        obj.transform.position = spawn.transform.position;
        obj.transform.rotation = spawn.transform.rotation;


    }

    private void endGame()
    {
		manager.GetComponent<GameManager> ().setMake (false);
        GameOver.SetActive(true);
    }

    public void RestartGame()
    {
		/*GameObject webCameraPlane = (GameObject)GameObject.FindGameObjectWithTag ("BackgroundMarker");
		WebCamTexture webCameraTexture = new WebCamTexture();
		webCameraPlane.GetComponent<Image>().material.mainTexture = webCameraTexture;
		webCameraTexture.Stop ();*/

        //SceneManager.LoadScene(0);
		resetStats();
		GameOver.SetActive(false);
	
    }


	private void resetStats()
	{
		health = 100;
		healthBar.fillAmount = 1f;
		score = 0;
		noOfHits = 0;
		maxComboDelay = 5;
		regainHealthTime = Time.time;
		lastHitTime = 0;
		lastComboTime = 0;
		comboType = 1;

		setCombo();
		setScore(0);
	}


    public void addScore(string type)
    {
        switch(type)
        {
            case "enemy1":
                score += 3;
                score *= comboType;
                setScore(score);
                comboCheck();
                break;
            case "enemy2":
                score += 5;
                score *= comboType;
                setScore(score);
                comboCheck();
                break;
            case "enemy3":
                score += 10;
                score *= comboType;
                setScore(score);
                comboCheck();
                break;
        }
    }

    void setScore(int score)
    {
        scoreLbl.text = "Score: " + score.ToString();
    }

    
    //Call on button click
    void comboCheck()
    {
        lastHitTime = Time.time;
        noOfHits++;

        if (noOfHits == 3)
        {
			if (comboType < 8) 
			{
				comboType++;
				setCombo ();
			}
            lastComboTime = Time.time;
        }

        //limit/clamp no of clicks between 0 and 3 because you have combo for 3 clicks
        noOfHits = Mathf.Clamp(noOfHits, 0, 3);
    }


    void setCombo()
    {
        comboLbl.text = "Combo: x" + comboType.ToString();
    }

}
