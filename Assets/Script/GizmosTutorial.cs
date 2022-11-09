using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GizmosTutorial : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        Gizmos.DrawCube(Vector3.zero, Vector3.one);
    }
}
