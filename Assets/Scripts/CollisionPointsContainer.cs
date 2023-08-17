using UnityEngine;

namespace Cube2048
{
    [RequireComponent(typeof(PointsContainerCollision), typeof (PointsContainer))]
    public class CollisionPointsContainer : MonoBehaviour
    {
        private PointsContainer pointsContainer;
        private PointsContainerCollision detector;
        private void Start()
        {
            pointsContainer = GetComponent<PointsContainer>();
            detector = GetComponent<PointsContainerCollision>();
            Subscribe();
        }

        private void OnPointsContainerCollision(PointsContainer col)
        {
            if (col.points == pointsContainer.points)
            {
                pointsContainer.points *= 2;
                Destroy(col.gameObject);
            }
        }
        private void Subscribe()
        {
            detector.onCollisionContinue += OnPointsContainerCollision;
        }
        private void Unsubscribe()
        {
            detector.onCollisionContinue -= OnPointsContainerCollision;
        }
        private void OnDestroy()
        {
            Unsubscribe();
        }
    }
}