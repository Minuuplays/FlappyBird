using System.Runtime.CompilerServices;
using UnityEngine;

public class SharpBird : MonoBehaviour
{
    public Rigidbody2D RigiidBodyy;
    public float FlySpeed;
    public ScoreLogic logic; // Reference to the ScoreLogic script to access the score logic
    public bool BirdIsAlive = true;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        RigiidBodyy.gravityScale = 0f;
        //  RigiidBodyy.name = "Birdy";
        //  logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<ScoreLogic>();
        //  We could also do that if not use the public logic variable
    }

    // Update is called once per frame
    void Update()
    {
        if (logic.GameStarted)
        {
            RigiidBodyy.gravityScale = 3.6f; // Enable gravity when the bird starts flying

            if (Input.GetKeyDown(KeyCode.Space) && BirdIsAlive)
            {
                RigiidBodyy.linearVelocity = new Vector2(0, 2) * FlySpeed;
            }

            if (BirdIsAlive == false)
            {
                transform.Rotate(new Vector3(0f, 0f, 200f) * 100 * Time.deltaTime);
            } 
        }

        if (transform.position.y < -8 || transform.position.y > 12)
        {
            logic.GameOver(); // Call the GameOver method from ScoreLogic
            BirdIsAlive = false;
            gameObject.SetActive(false);
            //print("GAME OVER");
            //GameAudio.Instance.PlayCrush();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.GameOver(); // Call the GameOver method from ScoreLogic
        BirdIsAlive = false;
        GameAudio.Instance.PlayCrush(); // Play crush sound effect

        // transform.Rotate(0f, 0f, 200f * Time.deltaTime);
    }
}