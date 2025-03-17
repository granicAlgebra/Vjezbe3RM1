using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public List<ParamData> Params = new List<ParamData>();

    private ParamData GetParam(Param param)
    {
        foreach ( var p in Params)
        {
            if (p.Param == param)
            {
                return p;
            }
        }

        Debug.Log(name + " does not have param " + param);
        return null;
    }

    public bool ChangeParam(Param param, int change)
    {
        var paramData = GetParam(param);
        if (paramData == null)
        {
            return false;
        }
        paramData.SetValue(paramData.Value + change);
        return true;
    }
}
