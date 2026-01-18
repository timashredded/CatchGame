using UnityEngine;

public class CourierMovement : MonoBehaviour
{
    public float moveSpeed = 12f;

    private Vector3 targetPosition;
    private float minX;
    private float maxX;

    void Start()
    {
        targetPosition = transform.position;

        float cameraHeight = Camera.main.orthographicSize;
        float cameraWidth = cameraHeight * Camera.main.aspect;

        minX = -cameraWidth + 0.5f;
        maxX = cameraWidth - 0.5f;
    }

    void Update()
    {
        HandleInput();
        Move();
    }

    void HandleInput()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            targetPosition = new Vector3(touchPos.x, transform.position.y, transform.position.z);
        }
    }

    void Move()
    {
        targetPosition.x = Mathf.Clamp(targetPosition.x, minX, maxX);

        transform.position = Vector3.MoveTowards(
            transform.position,
            targetPosition,
            moveSpeed * Time.deltaTime
        );
    }


}
