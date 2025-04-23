using UnityEngine;

public class MoveScript : MonoBehaviour
{
    private float speed = 8f; //max speed approx 13f, min speed approx 7f
    void Update()
    {
        this.transform.Translate(speed * Time.deltaTime * Vector3.left,Space.World);
    }
}
