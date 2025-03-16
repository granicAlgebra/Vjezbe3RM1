using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform Target;

    public float Smoothnes = 0.5f;

    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, Target.position, Smoothnes * Time.deltaTime);
        transform.rotation = Target.rotation;
    }
}