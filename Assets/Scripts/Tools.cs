using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Tools
{

    public static void Shuffle<T>(IList<T> ts)
    {
        var count = ts.Count;
        var last = count - 1;
        for (var i = 0; i < last; ++i)
        {
            var r = UnityEngine.Random.Range(i, count);
            var tmp = ts[i];
            ts[i] = ts[r];
            ts[r] = tmp;
        }
    }
    public static float GetMaxSizeParameterOfGameObjectByCollider(GameObject obj)
    {
        Collider col = obj.GetComponent<Collider>();
        if (col != null)
            return Mathf.Max(col.bounds.size.x, col.bounds.size.z);
        else
        {
            Debug.LogError("No collider in object " + obj.name);
            return 0f;
        }
        
    }
    public static void ResizeGameObjectByCollider(GameObject obj, float unityUnitsSize)
    {
        var curSize = GetMaxSizeParameterOfGameObjectByCollider(obj);
        obj.transform.localScale *= (unityUnitsSize / curSize);
    }
}
