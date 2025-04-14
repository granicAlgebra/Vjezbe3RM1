using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using DG.Tweening;

public class DeathController : MonoBehaviour
{
    [SerializeField] private Entity _entity;
    [SerializeField] private AnimationController _animationController;
    [SerializeField] private PlayerControlller _playerController;
    [SerializeField] private CinemachineVirtualCamera _deathCamera;
    [SerializeField] private CanvasGroup _deathScreen;
    [SerializeField] private Transform _weapon;
    
    void Start()
    {
        foreach (var param in _entity.Params)
        {
            if (param.Param.Equals(Param.Health))
            {
                param.OnValueChange.AddListener(OnHealthChange);
            }
        }
    }

    private void OnHealthChange(int value)
    {
        if (value <= 0)
        {
            _playerController.enabled = false;
            _animationController.PlayDeath();

            // Drop weapon
            _weapon.parent = null;
            _weapon.AddComponent<BoxCollider>();
            _weapon.AddComponent<Rigidbody>();

            _deathCamera.Priority = 20;

            DOVirtual.DelayedCall(2, () => _deathScreen.DOFade(1, 0.5f));
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            _entity.ChangeParam(Param.Health, -1000);
        }
    }
}
