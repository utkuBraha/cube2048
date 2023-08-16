using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace ChainCube.Scripts.Cube
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