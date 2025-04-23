using UnityEngine;

public class BirdScript : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField]
    private float force = 300f;
    private float health;
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        health = 100f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * force); 
        }
        transform.eulerAngles = new Vector3(0, 0, 3f * rb.linearVelocityY);
        health -= Time.deltaTime;

    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Food"))
        {
            Destroy(other.gameObject);
            health = Mathf.Clamp(health + 20f, 0f, 100f);
        }

        if (other.CompareTag("Fruit"))
        {
            Destroy(other.gameObject);
            health = Mathf.Clamp(health + 30f, 0f, 100f);
        }
        if (other.CompareTag("Nut"))
        {
            Destroy(other.gameObject);
            health = Mathf.Clamp(health + 10f, 0f, 100f);
        }
        Debug.Log("Health: " + health);
    }
}
