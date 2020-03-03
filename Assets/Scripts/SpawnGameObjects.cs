using UnityEngine;
using System.Collections;

public class SpawnGameObjects : MonoBehaviour
{
	// public variables
	public float secondsBetweenSpawning = 0.1f;
	public float xMinRange = -2.2f;
	public float xMaxRange = 2.2f;
	public float yRange = 6.5f;
    public GameObject speedIncreaser;
	public GameObject[] spawnObjects; // what prefabs to spawn

	private float nextSpawnTime;
    private int randomBool;
    private int speedIncrease;
    private float secondsBetween;

	// Use this for initialization
	void Start ()
	{
		// determine when to spawn the next object
		nextSpawnTime = Time.time+secondsBetweenSpawning;
        randomBool = 1;

        secondsBetween = secondsBetweenSpawning;
	}
	
	// Update is called once per frame
	void Update ()
	{
        if (GameObject.FindGameObjectWithTag("IncreaseSpeed").transform.position.x * 7 < secondsBetweenSpawning / 2)
        {
            secondsBetween = secondsBetweenSpawning - (GameObject.FindGameObjectWithTag("IncreaseSpeed").transform.position.x * 7);
        }
       

        /*
		// exit if there is a game manager and the game is over
		if (GameManager.gm) {
			if (GameManager.gm.gameIsOver)
				return;
		}
        */

        // if time to spawn a new game object
        if (Time.time  >= nextSpawnTime && randomBool == 1) {
			// Spawn the game object through function below
			MakeThingToSpawnRandom();

			// determine the next time to spawn the object
			nextSpawnTime = Time.time+secondsBetween;

            randomBool = 0;
		}
        else if (Time.time >= nextSpawnTime && randomBool == 0)
        {
            // Spawn the game object through function below
            MakeThingToSpawnOnGameObject();

            // determine the next time to spawn the object
            nextSpawnTime = Time.time + secondsBetween;

            randomBool = 1;
        }
    }

	void MakeThingToSpawnRandom ()
	{
		Vector3 spawnPosition;

		// get a random position between the specified ranges
		spawnPosition.x = Random.Range (xMinRange, xMaxRange);
		spawnPosition.y = yRange;
		spawnPosition.z = 0;

		// determine which object to spawn
		int objectToSpawn = Random.Range (0, spawnObjects.Length);

		// actually spawn the game object
		GameObject spawnedObject = Instantiate (spawnObjects [objectToSpawn], spawnPosition, transform.rotation) as GameObject;

        // make the parent the spawner so hierarchy doesn't get super messy
        spawnedObject.transform.parent = gameObject.transform;
	}


    void MakeThingToSpawnOnGameObject()
    {
        Vector3 spawnPosition;

        // get a random position between the specified ranges
        spawnPosition.x = GameObject.FindGameObjectWithTag("Player").transform.position.x;
        spawnPosition.y = yRange;
        spawnPosition.z = 0;

        // determine which object to spawn
        int objectToSpawn = Random.Range(0, spawnObjects.Length);

        // actually spawn the game object
        GameObject spawnedObject = Instantiate(spawnObjects[objectToSpawn], spawnPosition, transform.rotation) as GameObject;

        // make the parent the spawner so hierarchy doesn't get super messy
        spawnedObject.transform.parent = gameObject.transform;
    }
}
