using UnityEngine;

namespace ChainCube.Scripts.Cube
{
    [RequireComponent(typeof(PointsContainer), typeof(Rigidbody), typeof(PointsContainerCollision))]
    public class CollisionImpulse : MonoBehaviour
    {
        private PointsContainer pointsContainer;
        private Rigidbody rb;
        private PointsContainerCollision detector;

        private void Start()
        {
            pointsContainer = GetComponent<PointsContainer>();
            rb = GetComponent<Rigidbody>();
            detector = GetComponent<PointsContainerCollision>();
            Subscribe();
        }
        
        private void OnCollisionStart(PointsContainer col)
        {
            if (col.points == pointsContainer.points)
                rb.AddForce(Vector3.up * 10, ForceMode.Impulse);
            
        }

        private void Subscribe()
        {
            detector.onCollisionStart += OnCollisionStart;
        }

        private void Unsubscribe()
        {
            detector.onCollisionStart -= OnCollisionStart;
        }

        private void OnDestroy()
        {
            Unsubscribe();
        }
    }
}