
using UnityEngine;

public class Swaitch : MonoBehaviour
{
    public ScriptedMovement Door;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Door.OpenDoor(true);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Door.OpenDoor(false);
        }
    }
}
