using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject Pipe;     
    public float SpawnRate;       
    private float timer; // Timer to control the spawn rate of pipes
    public float heightoffset; // The offset for the height of the pipes
    public SharpBird SharpBirdCheck; // Reference to the SharpBird script to check if the bird is alive
    public ScoreLogic logic; // Reference to the ScoreLogic script to access the score logic
   // private bool finalPipeSpawned = true; // Flag to check if the final pipe has been spawned

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<ScoreLogic>();
       // SpawnPipe();  
    }

    void Update()
    {
        if (SharpBirdCheck.BirdIsAlive && logic.GameStarted )  
        {
            //finalPipeSpawned = false; // Reset the flag to allow spawning pipes again
           
            if (timer < SpawnRate)
            { 
                timer += Time.deltaTime;    
            }
            else
            {
                SpawnPipe();
                timer = 0;
            }
        }
       /* else
        {
            if (!finalPipeSpawned) // Check if the final pipe has not been spawned yet
            {
                if (timer < SpawnRate)
                {
                    timer += Time.deltaTime;
                }
                else
                {
                    SpawnPipe();
                    finalPipeSpawned = true; // Set the flag to true to prevent spawning again
                }
                
            }
        }*/
    }

    void SpawnPipe()
    {
        float lowestheight = transform.position.y - heightoffset; 
        float heightestheight = transform.position.y + heightoffset;
        Instantiate(Pipe, new Vector3(transform.position.x,Random.Range(lowestheight,heightestheight),0 ), transform.rotation);
    }
}
