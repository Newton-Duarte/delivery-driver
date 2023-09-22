using UnityEngine;

public class LoopUpAndDown : MonoBehaviour
{
    void Update()
    {
        float y = Mathf.Sin(Time.time * 5f) * 0.0015f + transform.position.y;
        transform.position = new Vector3(transform.position.x, y, transform.position.z);
    }
}
