using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Vector3 offset;

    Vector3 targetPos;

    public Transform target;

    Vector3 finalPos;

    public Vector2 limitsY;

    private void Update()
    {
        targetPos = target.position;
    }

    private void LateUpdate()
    {
        finalPos = targetPos + offset;

        finalPos.y = Mathf.Clamp(finalPos.y,limitsY.x,limitsY.y);

        transform.position = finalPos;
    }
}
