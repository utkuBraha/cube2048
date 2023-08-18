using System;
using UnityEngine;

namespace Cube2048
{
    public class XMovementHandler : MonoBehaviour, IMovableObject
    {
        [SerializeField]
        private Transform leftBorder;
        [SerializeField]
        private Transform rightBorder;
        [SerializeField, Range (0.5f, 1.5f)]
        private float normalizedCoefficient = 1.0f;
        private GameObject move;
        private ISwipeDetector swipeDetector;
        [SerializeField]private float maxSwipeSpeed = 10.0f;


        public void Inject(GameObject dependency)
        {
            move = dependency;
        }
        private void Start()
        {
            swipeDetector = GetComponent<ISwipeDetector>();
            Subscribe();
        }
        private void Subscribe()
        {
            if (swipeDetector == null)
                throw new NullReferenceException();
            swipeDetector.onSwipe += OnSwipe;
            swipeDetector.onSwipeEnd += OnSwipeEnd;
        }
        private void OnSwipe(Vector2 delta)
        {
            if (move == null)
            {
                return;
            }
            if (Mathf.Approximately(delta.x, 0))
            {
                return;
            }
            var borderDistance = Mathf.Abs(rightBorder.position.x - leftBorder.position.x);
            var offset = borderDistance * normalizedCoefficient * delta.x / Screen.width;
            var currentPos = move.transform.position;
            offset = Mathf.Clamp(offset, -maxSwipeSpeed * Time.deltaTime, maxSwipeSpeed * Time.deltaTime);
            var newPositionX = Mathf.Clamp(currentPos.x + offset, leftBorder.position.x, rightBorder.position.x);
            move.transform.position = new Vector3(newPositionX, currentPos.y, currentPos.z);
        }
        private void OnSwipeEnd(Vector2 delta)
        {
            move = null;
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
}