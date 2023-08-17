using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Cube2048
{
    public class PointsContainer : MonoBehaviour
    { 
        [SerializeField] protected long point;
        public long points
        {
            get => point;
            set
            {
                if (point == value)
                    return;
                point = value;
                onPointsChanged?.Invoke(point);
            }
        }
        public event Action<long> onPointsChanged;
    }
}