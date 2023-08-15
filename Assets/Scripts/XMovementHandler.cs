using System;
using ChainCube.Scripts.Utils;
using UnityEngine;
using UnityEngine.Serialization;

namespace ChainCube.Scripts.Handlers
{
    public class XMovementHandler : MonoBehaviour, IMovableObject
    {
      
        [SerializeField]
        private Transform leftBorder;
        
        [SerializeField]
        private Transform rightBorder;

        [SerializeField, Range (0.5f, 1.5f)]
        private float normalizedCoefficient = 1.0f;
        
        private GameObject movableObject;

        private ISwipeDetector swipeDetector;
        
        public void Inject(GameObject dependency)
        {
            movableObject = dependency;
        }
        
        private void Start()
        {
            swipeDetector = GetComponent<ISwipeDetector>();
            Subscribe();
        }

        private void Subscribe()
        {
            if (swipeDetector == null)

                if (swipeDetector != null)
                    swipeDetector.onSwipe += OnSwipe;
            if (swipeDetector != null) 
                swipeDetector.onSwipeEnd += OnSwipeEnd;
        }

        private void OnSwipe(Vector2 delta)
        {
            if (movableObject == null)
            {
                return;
            }

            if (Mathf.Abs(delta.x - Mathf.Epsilon) <= 0)
                return;

            var borderDistance = Mathf.Abs(rightBorder.position.x - leftBorder.position.x);
            var offset = borderDistance * normalizedCoefficient * delta.x / Screen.width;
            var currentPos = movableObject.transform.position;
            
            movableObject.transform.position = new Vector3(currentPos.x + offset, currentPos.y, currentPos.z);
            
            if (movableObject.transform.position.x > rightBorder.position.x)
                movableObject.transform.position = rightBorder.transform.position;
            else if (movableObject.transform.position.x < leftBorder.position.x)
                movableObject.transform.position = leftBorder.transform.position;
        }

        private void OnSwipeEnd(Vector2 delta)
        {
            movableObject = null;
        }

        private void OnDestroy()
        {
            Unsubscribe();
        }

        private void Unsubscribe()
        {
            if (swipeDetector == null)
                return;
            
            swipeDetector.onSwipe -= OnSwipe;
        }
    }
    public interface IMovableObject : IDependency<GameObject> { }
}

