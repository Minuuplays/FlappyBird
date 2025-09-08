using UnityEngine;

public class PipeMiddleTracker : MonoBehaviour
{
    public ScoreLogic logic;
    public SharpBird logic2; // Reference to the SharpBird script to check if the bird is alive
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<ScoreLogic>();
        //logic2 = GameObject.FindGameObjectWithTag("Logic2").GetComponent<SharpBird>();

        GameObject birdObject = GameObject.FindGameObjectWithTag("Logic2");
        if (birdObject != null)
        {
            logic2 = birdObject.GetComponent<SharpBird>();
        }
        else
        {
            // Debug.LogWarning("PipeMiddleTracker: Bird was not found. Disabling tracker.");
            logic2 = null; // Set to null if the bird is not found
            this.enabled = false; // disable this script entirely
        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if ((collision.gameObject.layer == 3) && logic2.BirdIsAlive)
        {
            logic.addScore(2);
            GameAudio.Instance.PlayScore(); // Play score sound effect
        }
    }

}
