using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    public GameObject Cloudss;
    public float SpawnRate;// Rate at which clouds are spawned
    public float HeightOffset; // The offset for the height of the clouds
    public float LenghtOffset; // The offset for the length of the clouds
    private float timer; // Timer to control the spawn rate of clouds
    public SharpBird SharpBirdCheck; // Reference to the SharpBird script to check if the bird is alive
    public ScoreLogic logic; // Reference to the ScoreLogic script to access the score logic
    private bool finalCloudSpawned = true; // Flag to check if the final cloud has been spawned
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<ScoreLogic>();
        //  CloudSpawn(); // Initial cloud spawn
    }

    // Update is called once per frame
    void Update()
    {
        if (SharpBirdCheck.BirdIsAlive && logic.GameStarted) // Check if the bird is alive
        {
            finalCloudSpawned = false; // Reset the flag to allow spawning clouds again

            if (timer < SpawnRate)
            {
                timer += Time.deltaTime; // Increment the timer
            }
            else
            {
                CloudSpawn(); // Spawn a cloud
                timer = 0; // Reset the timer
            }
        }
        else
        {
            if (!finalCloudSpawned) // Check if the final cloud has not been spawned yet
            {
                if (timer < SpawnRate)
                {
                    timer += Time.deltaTime; // Increment the timer
                }
                else
                {
                    CloudSpawn(); // Spawn a cloud
                    finalCloudSpawned = true; // Set the flag to true to prevent spawning again
                }
            }
        }


    }

    void CloudSpawn() 
    {
        float lowestheight = transform.position.y - HeightOffset; // Adjust the height offset as needed
        float heightestheight = transform.position.y + HeightOffset; // Adjust the height offset as needed
        float moveright = transform.position.x + LenghtOffset;
        float moveleft = transform.position.x - LenghtOffset;

        Instantiate(Cloudss, new Vector3(Random.Range(moveright,moveleft), Random.Range(heightestheight, lowestheight), 0), transform.rotation);
    }
}
