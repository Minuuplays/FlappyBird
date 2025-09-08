using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    public float MovementSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
   
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * MovementSpeed * Time.deltaTime;

        if (transform.position.x < -15)
        {
            Destroy(gameObject);
        }

    }
}
