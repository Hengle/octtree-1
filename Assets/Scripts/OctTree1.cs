﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace OctTree1
{

    public static class Vector3Helper
    {
        public static Vector3 MedianPoint(Vector3 vec1, Vector3 vec2)
        {
            return new Vector3((vec1.x + vec2.x) / 2, (vec1.y + vec2.y) / 2, (vec1.z + vec2.z) / 2);
        }
    }

    public static class BoundsHelper
    {
        public static Vector3[] deltas = new Vector3[] { new Vector3(-1, -1, -1), new Vector3(-1, 1, -1), new Vector3(1, -1, -1), new Vector3(1, 1, -1)
                , new Vector3(-1, -1, 1), new Vector3(-1, 1, 1), new Vector3(1, -1, 1), new Vector3(1, 1, 1)};

        public static Bounds SubBounds(Bounds orig, Vector3 center, int index)
        {
            var delta = deltas[index];
            var origSize = orig.size / 4;
            var newCenter = (center + orig.center) / 2 + new Vector3(origSize.x * delta.x, origSize.y * delta.y, origSize.z * delta.z);
            var newSize = -new Vector3(center.x * delta.x, center.y * delta.y, center.z * delta.z)
                + new Vector3(orig.center.x * delta.x, orig.center.y * delta.y, orig.center.z * delta.z)
                + orig.size / 2;
            return new Bounds(newCenter, newSize);
        }
    }

    public class OctNode
    {
        public static int SUB_NODES_COUNT = 8;

        public Bounds Bounds;
        public Vector3 Center;
        public object[] SubNodes = new object[SUB_NODES_COUNT];

        public void Insert(Vector3 pos, object obj)
        {
            int subNodesIndex = GetSubNodesIndex(pos);
            //Debug.Log("subNodesIndex "+ subNodesIndex);
            var cell = SubNodes[subNodesIndex];
            if(cell == null)
            {
                SubNodes[subNodesIndex] = new KeyValuePair<Vector3, object>(pos, obj);
            }
            else if(cell is KeyValuePair<Vector3, object>)
            {
                var existed = (KeyValuePair<Vector3, object>)cell;
                var newNode = new OctNode { Center = Vector3Helper.MedianPoint(pos, existed.Key), Bounds = BoundsHelper.SubBounds(Bounds, Center, subNodesIndex) };
                newNode.Insert(existed.Key, existed.Value);
                newNode.Insert(pos, obj);
                SubNodes[subNodesIndex] = newNode;
            }
            else if(cell is OctNode)
            {
                (cell as OctNode).Insert(pos, obj);
            }
        }

        public string Log(string tab = "")
        {
            return tab + " Bounds(" + Bounds.ToString("F4") + ") Center(" + Center.ToString("F4") + ") Data("
                + SubNodes.Where(sn => sn is KeyValuePair<Vector3, object>).Cast<KeyValuePair<Vector3, object>>()
                .Aggregate("", (ac, pair) => ac + "(pos:" + pair.Key.ToString("F4") + " val:" + pair.Value+") ") + ")\n"
                + SubNodes.Where(sn => sn is OctNode).Cast<OctNode>()
                .Aggregate("", (ac, node) => ac + node.Log(tab+"-"));
        }

        public int GetSubNodesIndex(Vector3 pos)
        {
            int index = 0;
            if (pos.y >= Center.y)
            {
                index += 1;
            }
            if (pos.x >= Center.x)
            {
                index += 2;
            }
            if(pos.z >= Center.z)
            {
                index += 4;
            }
            return index;
        }

    }

}


