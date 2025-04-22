using UnityEngine;

public class BirdScript : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField]
    private float force = 300f; // max force approx 500f, min force approx 300f
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * force); 
        }
    }
}
