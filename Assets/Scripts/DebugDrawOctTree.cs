using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using OctTree1;

public class DebugDrawOctTree : MonoBehaviour
{

    private OctNode Root;

    void Start()
    {
        Root = new OctNode { Bounds = new Bounds(Vector3.zero, new Vector3(1, 1, 1)), Center = Vector3.zero };
    }

    void Update()
    {

    }
}


