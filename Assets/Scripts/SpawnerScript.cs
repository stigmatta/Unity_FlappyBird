using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    [SerializeField]
    private GameObject pipePrefab;
    private float pipeOffsetMax = 2.4f;
    [SerializeField]
    private GameObject foodPrefab;
    [SerializeField]
    private GameObject fruitPrefab;
    [SerializeField]
    private GameObject nutPrefab;
    private float foodOffsetMax = 4.3f;
    private float period = 1.5f;
    private float timeout;
    private float foodTimeout;
    void Start()
    {
        timeout = 0f;
        foodTimeout = period * period;
    }

    void Update()
    {
        timeout-=Time.deltaTime;
        if (timeout <= 0)
        {
            timeout = period;
            SpawnPipe();
        }
        foodTimeout -= Time.deltaTime;
        if (foodTimeout <= 0)
        {
            foodTimeout = period;
            SpawnFood();
        }
    }

    private void SpawnPipe()
    {
        GameObject pipe = Instantiate(pipePrefab);
        pipe.transform.position = this.transform.position+
            Random.Range(-pipeOffsetMax, pipeOffsetMax) * Vector3.up;
    }

    private void SpawnFood()
    {
        int rndFood = Random.Range(0,4); 
        GameObject food;

        switch (rndFood)
        {
            case 0:
                food = Instantiate(foodPrefab);
                break;
            case 1:
                food = Instantiate(fruitPrefab);
                break;
            case 2:
                food = Instantiate(nutPrefab);
                break;
            case 3:
                food = null;
                break;
            default:
                food = null;
                break;
        }
        if (food == null)
            return;
        food.transform.position = this.transform.position +
            Random.Range(-foodOffsetMax, foodOffsetMax) * Vector3.up;
        food.transform.Rotate(0, 0, Random.Range(0, 360));
    }

}
