using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public GameObject player;
	public GameObject startText;
    public GameObject[] enemys;
    public Vector3 spawnValues;
    public int enemyCount;
    public float spawnWait;
    public float startWait = 3f;
    public float waveWait;
    public float radius;

	private IEnumerator corutine;
	private bool make;
	private GameObject enemysContainer;

    // Use this for initialization
    void Start () {
        
		StartGameText ();
		make = true;
       
	}

	public void setMake(bool statement)
	{
		make = statement;

		if (make == false && enemysContainer != null)
			Destroy (enemysContainer);
	
	}

	public void StartGame()
	{
		player.GetComponent<PlayerControll> ().RestartGame();
		StartGameText ();
		make = true;

	}

    IEnumerator SpawnWaves()
    {
		enemysContainer = new GameObject ("enemysContainer");

        yield return new WaitForSeconds(startWait);

		while (make && enemysContainer != null)
        {
			for (int i = 0; i < enemyCount && enemysContainer != null; i++)
            {
				

                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, Random.Range(-spawnValues.z,spawnValues.z));
                if(-radius < spawnPosition.x && spawnPosition.x < radius && -radius < spawnPosition.z && spawnPosition.z < radius)
                {
                    if (spawnPosition.x < 0)
                        spawnPosition.x -= radius;
                    else
                        spawnPosition.x += radius;
                    if (spawnPosition.z < 0)
                        spawnPosition.z -= radius;
                    else
                        spawnPosition.z += radius;
                }

                Quaternion spawnRotation = Quaternion.identity;
                GameObject obj = (GameObject)Instantiate(enemys[getRandomIndex()], spawnPosition, spawnRotation);

				obj.transform.SetParent (enemysContainer.transform);
                obj.AddComponent<enemyControll>().GetComponent<enemyControll>().target = player.transform;
                obj.AddComponent<Patrol>();
                obj.AddComponent<NavMeshAgent>();
                obj.GetComponent<NavMeshAgent>().acceleration = 4f;


                yield return new WaitForSeconds(spawnWait);
            }
				


            yield return new WaitForSeconds(waveWait);
        }
    }
    

    int getRandomIndex()
    {
        int[] indexArr = { 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 3 };
        return indexArr[Random.Range(0, 10)];
    }


	void StartGameText()
	{
		startText.SetActive (true);

		Text countText = (Text)startText.GetComponent<Text> ();

		countText.text = "1";
		corutine = CountTextStart (countText);
		StartCoroutine (corutine);

	}

	IEnumerator CountTextStart(Text countText)
	{
		yield return new WaitForSeconds (1f);
		countText.text = "2";
		yield return new WaitForSeconds (1f);
		countText.text = "3";
		yield return new WaitForSeconds (1f);
		startText.SetActive (false);

		StartCoroutine("SpawnWaves");

	}


}
