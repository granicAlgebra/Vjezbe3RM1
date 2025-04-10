using UnityEngine;
using UnityEngine.Animations.Rigging;

public class IKcontroller : MonoBehaviour
{
    [SerializeField] private Transform _headTarget;
    [SerializeField] private MultiAimConstraint _headLook;
    [SerializeField] private float _smoothHeadFollow;

    private Vector3 _headTargetStart;
    private Transform _stareTarget;

    private void Start()
    {
        _headTargetStart = _headTarget.localPosition;
    }

    public void StareAt(Transform target, bool start)
    {
        if (start)
        {
            _stareTarget = target;
        }
        else if (_stareTarget == null && _stareTarget.Equals(target))
        {
            _stareTarget = null;
        }
    }

    private void Update()
    {
        if (_stareTarget == null)
        {
            _headTarget.localPosition = Vector3.Lerp(_headTarget.localPosition, _headTargetStart, _smoothHeadFollow * Time.deltaTime);
        }
        else
        {
            _headTarget.position = Vector3.Lerp(_headTarget.position, _stareTarget.position, _smoothHeadFollow * Time.deltaTime * Time.deltaTime);
        }
    }
}
