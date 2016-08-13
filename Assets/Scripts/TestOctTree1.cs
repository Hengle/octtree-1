using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using OctTree1;

public class TestOctTree1 : MonoBehaviour
{

    [ContextMenu("RunTests")]
    public void RunTests()
    {
        Debug.Log("------------------");
        Debug.Log(BoundsHelper.SubBounds(new Bounds(Vector3.zero, Vector3.one), Vector3.zero, 0).ToString("F2"));
        Debug.Log(BoundsHelper.SubBounds(new Bounds(Vector3.zero, Vector3.one), Vector3.zero, 1).ToString("F2"));
        Debug.Log(BoundsHelper.SubBounds(new Bounds(Vector3.zero, Vector3.one), Vector3.zero, 2).ToString("F2"));
        Debug.Log(BoundsHelper.SubBounds(new Bounds(Vector3.zero, Vector3.one), Vector3.zero, 3).ToString("F2"));
        Debug.Log(BoundsHelper.SubBounds(new Bounds(Vector3.zero, Vector3.one), Vector3.zero, 4).ToString("F2"));
        Debug.Log(BoundsHelper.SubBounds(new Bounds(Vector3.zero, Vector3.one), Vector3.zero, 5).ToString("F2"));
        Debug.Log(BoundsHelper.SubBounds(new Bounds(Vector3.zero, Vector3.one), Vector3.zero, 6).ToString("F2"));
        Debug.Log(BoundsHelper.SubBounds(new Bounds(Vector3.zero, Vector3.one), Vector3.zero, 7).ToString("F2"));
        Debug.Log("------------------");
        var v1 = new Vector3(0.25f, 0.25f, 0.25f);
        Debug.Log(BoundsHelper.SubBounds(new Bounds(Vector3.zero, Vector3.one), v1, 0).ToString("F3"));
        Debug.Log(BoundsHelper.SubBounds(new Bounds(Vector3.zero, Vector3.one), v1, 1).ToString("F3"));
        Debug.Log(BoundsHelper.SubBounds(new Bounds(Vector3.zero, Vector3.one), v1, 2).ToString("F3"));
        Debug.Log(BoundsHelper.SubBounds(new Bounds(Vector3.zero, Vector3.one), v1, 3).ToString("F3"));
        Debug.Log(BoundsHelper.SubBounds(new Bounds(Vector3.zero, Vector3.one), v1, 4).ToString("F3"));
        Debug.Log(BoundsHelper.SubBounds(new Bounds(Vector3.zero, Vector3.one), v1, 5).ToString("F3"));
        Debug.Log(BoundsHelper.SubBounds(new Bounds(Vector3.zero, Vector3.one), v1, 6).ToString("F3"));
        Debug.Log(BoundsHelper.SubBounds(new Bounds(Vector3.zero, Vector3.one), v1, 7).ToString("F3"));
        Debug.Log("------------------");
        Debug.Log(Vector3Helper.MedianPoint(Vector3.zero, Vector3.one));
        Debug.Log(Vector3Helper.MedianPoint(new Vector3(1, 1, 1), new Vector3(2, 2, 2)));
        Debug.Log(Vector3Helper.MedianPoint(new Vector3(0, 0, 1), new Vector3(0, 0, 2)));
        Debug.Log("------------------");
    }

}


