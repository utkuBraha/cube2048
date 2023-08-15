using System;
using ChainCube.Scripts.Utils;
using UnityEngine;

namespace ChainCube.Scripts.Handlers
{
    public class ForceYMovementSwipeHandler : MonoBehaviour, IMovableObject
    {
        [SerializeField]
        private float _force = 1.0f;
        
        private Rigidbody moveRb;
        private ISwipeDetector swipeDetector;
        
        public void Inject(GameObject dependency)
        {
            moveRb = dependency.GetComponent<Rigidbody>();
        }

        private void Start()
        {
            swipeDetector = GetComponent<MouseSwipeDetector>();
            Subscribe();
        }

        private void Subscribe()
        {
            if (swipeDetector == null)
                throw new NullReferenceException();

            swipeDetector.onSwipeEnd += OnSwipeEnd;
        }

        private void OnSwipeEnd(Vector2 delta)
        {
            if (moveRb == null)
                return;
            
            moveRb.AddForce(moveRb.transform.forward * _force, ForceMode.Impulse);
            moveRb = null;
        }

        private void OnDestroy()
        {
            Unsubscribe();
        }

        private void Unsubscribe()
        {
            if (swipeDetector == null)
                return;

            swipeDetector.onSwipeEnd -= OnSwipeEnd;
        }
    }
}
