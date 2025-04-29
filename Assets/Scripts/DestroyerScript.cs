using UnityEngine;

public class DestroyerScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        //Transform current = other.transform;
        //while (current != null)
        //{
        //    Transform parent = current.parent;
        //    Destroy(current.gameObject);
        //    current = parent;
        //}

        DeepDestroy(other.gameObject);
    }

    public static void ClearField()
    {
        foreach (var obj in GameObject.FindGameObjectsWithTag("Pipe"))
        {
            DeepDestroy(obj);
        }
        foreach (var obj in GameObject.FindGameObjectsWithTag("Food"))
        {
            DeepDestroy(obj);
        }
        foreach (var obj in GameObject.FindGameObjectsWithTag("Fruit"))
        {
            DeepDestroy(obj);
        }
    }

    private static void DeepDestroy(GameObject obj) {
        Transform current = obj.transform;
        while (current != null)
        {
            Transform parent = current.parent;
            Destroy(current.gameObject);
            current = parent;
        }
    }
}
