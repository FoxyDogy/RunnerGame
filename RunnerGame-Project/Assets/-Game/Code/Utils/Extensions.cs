﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = System.Random;

namespace Foxy.Utils
{
    public static class Extensions
    {
        public static Vector3 Clamp(this Vector3 point, Boundaries boundaries)
        {
            var clampedValue = point;
            clampedValue.x = Mathf.Clamp(point.x, boundaries.xmin, boundaries.xmax);
            clampedValue.y = Mathf.Clamp(point.y, boundaries.ymin, boundaries.ymax);
            clampedValue.z = Mathf.Clamp(point.z, boundaries.zmin, boundaries.zmax);
            return clampedValue;
        }
    }
    [Serializable]
    public class Boundaries
    {
        public float xmin = float.NegativeInfinity;
        public float xmax = float.PositiveInfinity;
        public float ymin = float.NegativeInfinity;
        public float ymax = float.PositiveInfinity;
        public float zmin = float.NegativeInfinity;
        public float zmax = float.PositiveInfinity;
    }
}