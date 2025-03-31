using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform Target;

    public float Smoothnes = 0.5f;

    void LateUpdate()
    {
        transform.position = Target.position;
        transform.rotation = Target.rotation;
    }
}