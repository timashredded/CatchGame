using UnityEngine;

public class BackgroundFollow : MonoBehaviour
{
    void LateUpdate()
    {
        transform.position = new Vector3(
            Camera.main.transform.position.x,
            Camera.main.transform.position.y,
            transform.position.z
        );
    }
}
