using UnityEngine;
using UnityEngine.Serialization;

namespace Cube2048
{
    [RequireComponent(typeof(PointsContainer))]
    public class RandomPointsGenerator : MonoBehaviour
    {
        [SerializeField] private byte minDegree = 1;

        [SerializeField] private byte maxDegree = 4;
        
        private PointsContainer pointsContainer;

        private const byte defaultMinDegree = 1;
        private const byte defaultMaxDegree = 4;

        private void Start()
        {
            NormalizeDegree();
            pointsContainer = GetComponent<PointsContainer>();
            pointsContainer.points = (int)Mathf.Pow(2, Random.Range(minDegree, maxDegree));
        }

        private void NormalizeDegree()
        {
            if (maxDegree > minDegree) return;
            minDegree = defaultMinDegree;
            maxDegree = defaultMaxDegree;
        }
    }
}