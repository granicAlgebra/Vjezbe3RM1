using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    public GameObject CoinObject;
    public BoxCollider BoxCollider;

    public AudioSource AudioSource;

    public ParticleSystem VFX;

    public Param _param = Param.Gold;
    public int _change = 1;

    private void OnTriggerEnter(Collider other)
    {
        var entity = other.GetComponent<Entity>();
        if (entity != null)
        {
            entity.ChangeParam(_param, _change);
            CoinObject.SetActive(false);
            BoxCollider.enabled = false;

            VFX.Play();
            AudioSource.Play();
        }
    }
}