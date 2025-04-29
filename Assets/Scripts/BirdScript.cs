using UnityEngine;
using UnityEngine.SceneManagement;

public class BirdScript : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField]
    private float force = 300f;
    [SerializeField]
    private TMPro.TextMeshProUGUI triesText;
    public static float health;
    private float healthTimeout = 20.0f;
    private int tries;
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        health = 1.0f;
        tries = 3;
        triesText.text = tries.ToString();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Time.timeScale * force* Vector2.up); 
        }
        transform.eulerAngles = new Vector3(0, 0, 3f * rb.linearVelocityY);
        health -= Time.deltaTime/healthTimeout;
        if(health <= 0)
            LostALife("No health!","You ran of a time");

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Pipe"))
        {
            LostALife("Collision", "You hit a pipe!");
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

    private void LostALife(string title,string description)
    {
        tries -= 1;
        triesText.text = tries.ToString();
        if (tries > 0)
        {
            health = 1.0f;
            AlertScript.Show(title, description, "Continue", DestroyerScript.ClearField);
        }
        else
            AlertScript.Show("Game Over", "You hit a pipe!", "Restart", () => SceneManager.LoadScene(0));
    }
}
