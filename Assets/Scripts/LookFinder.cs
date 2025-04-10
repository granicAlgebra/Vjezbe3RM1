using UnityEngine;

public class LookFinder : MonoBehaviour
{
    [SerializeField] private IKcontroller _ikController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            _ikController.StareAt(other.transform, true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            _ikController.StareAt(other.transform, false);
        }
    }
}
