using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompareLocalPositoin : MonoBehaviour
{
    public Transform[] compareTransformCubes;
    
    void Start()
    {
        Debug.Log($"LocalPosition : {compareTransformCubes[0].localPosition}, {compareTransformCubes[1].localPosition}");
        var worldPosCube1 = compareTransformCubes[0].TransformDirection(compareTransformCubes[0].position);
        var worldPosCube2 = compareTransformCubes[1].TransformDirection(compareTransformCubes[1].position);
        Debug.Log($"TransformDircetion => WorldPosition : {worldPosCube1}, {worldPosCube2} ");
        Debug.Log($"No Normalized : {worldPosCube2-worldPosCube1}");
        Debug.Log($"Normalized : {(worldPosCube2-worldPosCube1).normalized}");
        Debug.Log($"Magnitude : {(worldPosCube2-worldPosCube1).magnitude}");
        Debug.Log($"SqrMagnitude : {(worldPosCube2-worldPosCube1).sqrMagnitude}");



    }
}
