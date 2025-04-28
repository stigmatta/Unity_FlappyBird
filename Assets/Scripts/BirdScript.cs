using UnityEngine;

public class BirdScript : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField]
    private float force = 300f;
    public static float health;
    private float healthTimeout = 20.0f;
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        health = 1.0f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * force); 
        }
        transform.eulerAngles = new Vector3(0, 0, 3f * rb.linearVelocityY);
        health -= Time.deltaTime/healthTimeout;

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Pipe"))
        {
            AlertScript.Show("Game Over", "You hit a pipe!", "Restart");
        }
        if (other.CompareTag("Food"))
        {
            Destroy(other.gameObject);
            health = Mathf.Clamp01(health + 20f / healthTimeout);
        }

        if (other.CompareTag("Fruit"))
        {
            Destroy(other.gameObject);
            health = Mathf.Clamp01(health + 30f/healthTimeout);
        }
        if (other.CompareTag("Nut"))
        {
            Destroy(other.gameObject);
            health = Mathf.Clamp01(health + 10f / healthTimeout);
        }
        Debug.Log("Health: " + health);
    }
}
