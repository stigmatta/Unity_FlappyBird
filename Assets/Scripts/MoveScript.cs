using UnityEngine;

public class MoveScript : MonoBehaviour
{
    [SerializeField]
    private float speed = 13f; //max speed approx 13f, min speed approx 7f
    void Update()
    {
        this.transform.Translate(speed * Time.deltaTime * Vector3.left);
    }
}
