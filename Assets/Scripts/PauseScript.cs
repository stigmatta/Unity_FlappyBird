using UnityEngine;

public class PauseScript : MonoBehaviour
{
    private GameObject content;
    void Start()
    {
        Transform c = transform.Find("Content");
        content = c.gameObject;
        if (content.activeInHierarchy)
            Time.timeScale = 0f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (content.activeInHierarchy)
            {
                content.SetActive(false);
                Time.timeScale = 1;
            }
            else
            {
                content.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }

    public void onButtonClick()
    {
        content.SetActive(false);
        Time.timeScale = 1f;
    }

    public void onIntervalValueChanged(System.Single value)
    {
        SpawnerScript.difficulty = value;
    }
    public void onPipeSizeValueChanged(System.Single value)
    {
        SpawnerScript.pipeDistance = value;
    }
}
