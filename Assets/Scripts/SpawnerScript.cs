using UnityEngine;

public class SpawnerScript : MonoBehaviour
{

    private static float _difficulty = 0.5f;
    public static float difficulty
    {
        get => _difficulty;
        set
        {
            _difficulty = value;
            foodTimeout = timeout + period *1.5f;
        }
    }
    private static float _pipeDistance = 1f;
    public static float pipeDistance
    {
        get => _pipeDistance;
        set
        {
            _pipeDistance = value;
            Debug.Log($"Pipe distance: {_pipeDistance}");
        }
    }

    [SerializeField]
    private GameObject pipePrefab;
    private float pipeOffsetMax = 2.4f;
    [SerializeField]
    private GameObject foodPrefab;
    [SerializeField]
    private GameObject fruitPrefab;
    [SerializeField]
    private GameObject stats;
    private float foodOffsetMax = 4.3f;
    private static float period => 5f-3.5f * difficulty;
    private static float timeout;
    private static float foodTimeout;

    private TMPro.TextMeshProUGUI pipes;
    private TMPro.TextMeshProUGUI cherries;
    private TMPro.TextMeshProUGUI bugs;

    private int pipeCount = 0;
    private int cherryCount = 0;
    private int bugCount = 0;


    void Start()
    {
        pipes = stats.transform.Find("Pipes/Text").GetComponent<TMPro.TextMeshProUGUI>();
        cherries = stats.transform.Find("Cherries/Text").GetComponent<TMPro.TextMeshProUGUI>();
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
        Transform top = pipe.transform.Find("Top");
        Transform bottom = pipe.transform.Find("Bottom");

        top.localScale = new Vector3(1f, pipeDistance, 1f);
        bottom.localScale = new Vector3(1f, pipeDistance, 1f);

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
