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
    //[SerializeField]
    //private GameObject nutPrefab;
    [SerializeField]
    private GameObject stats;
    private float foodOffsetMax = 4.3f;
    private float period = 1.5f;
    private float timeout;
    private float foodTimeout;

    private TMPro.TextMeshProUGUI pipes;
    private TMPro.TextMeshProUGUI cherries;
    //private TMPro.TextMeshProUGUI nuts;
    private TMPro.TextMeshProUGUI bugs;

    private int pipeCount = 0;
    private int cherryCount = 0;
    private int nutCount = 0;
    private int bugCount = 0;


    void Start()
    {
        pipes = stats.transform.Find("Pipes/Text").GetComponent<TMPro.TextMeshProUGUI>();
        cherries = stats.transform.Find("Cherries/Text").GetComponent<TMPro.TextMeshProUGUI>();
        //nuts = stats.transform.Find("Nuts/Text").GetComponent<TMPro.TextMeshProUGUI>();
        bugs = stats.transform.Find("Bugs/Text").GetComponent<TMPro.TextMeshProUGUI>();

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
        pipes.text = $"x{(++pipeCount)}";
    }

    private void SpawnFood()
    {
        int rndFood = Random.Range(0,4); 
        GameObject food;

        switch (rndFood)
        {
            case 0:
                food = Instantiate(foodPrefab);
                bugs.text = $"x{(++bugCount)}";
                break;
            case 1:
                food = Instantiate(fruitPrefab);
                cherries.text = $"x{(++cherryCount)}";
                break;
            case 2:
                food = null;
                //food = Instantiate(nutPrefab);
                //nuts.text = $"x{(++nutCount)}";
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
