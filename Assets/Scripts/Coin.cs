using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public Param _param = Param.Gold;
    public int _change = 1;

    private void OnTriggerEnter(Collider other)
    {
        var entity = other.GetComponent<Entity>();
        if (entity != null)
        {
            entity.ChangeParam(_param, _change);
            gameObject.SetActive(false);
        }
    }
}
