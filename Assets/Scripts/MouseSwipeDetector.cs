using System;
using UnityEngine;

namespace Cube2048
{
    public class MouseSwipeDetector : MonoBehaviour, ISwipeDetector
    {
        public event Action<Vector2> onSwipeStart;
        public event Action<Vector2> onSwipe;
        public event Action<Vector2> onSwipeEnd;

        private bool isSwiping;
        private Vector3 startPosition;
        private Vector3 previousPosition;

        private void Update()
        {
            Vector3 currentPosition = Input.mousePosition;
            bool isMouseButtonPressed = Input.GetMouseButton(0);

            if (!isMouseButtonPressed)
            {
                if (isSwiping)
                {
                    EndSwipe(currentPosition);
                }
            }
            else
            {
                if (!isSwiping)
                {
                    StartSwipe(currentPosition);
                }
                else
                {
                    ContinueSwipe(currentPosition);
                }
            }

            previousPosition = currentPosition;
        }

        private void StartSwipe(Vector3 startPosition)
        {
            isSwiping = true;
            this.startPosition = startPosition;
            previousPosition = startPosition; 
            onSwipeStart?.Invoke(Vector2.zero);
        }

        private void ContinueSwipe(Vector3 currentPosition)
        {
            Vector3 swipeDelta = currentPosition - previousPosition;
            previousPosition = currentPosition;

            onSwipe?.Invoke(swipeDelta);
        }

        private void EndSwipe(Vector3 endPosition)
        {
            isSwiping = false;
            onSwipeEnd?.Invoke(endPosition - startPosition);
        }
    }
}


// using System;
// using UnityEngine;
//
// namespace Cube2048
// {
//     public class MouseSwipeDetector : MonoBehaviour, ISwipeDetector
//     {
//         public event Action<Vector2> onSwipeStart;
//         public event Action<Vector2> onSwipe;
//         public event Action<Vector2> onSwipeEnd;
//         private bool isSwiping;
//         private Vector3 startPosition;
//
//         private void Update()
//         {
//             Vector3 currentPosition = Input.mousePosition;
//             bool isMouseButtonPressed = Input.GetMouseButton(0);
//
//             if (!isMouseButtonPressed)
//             {
//                 if (isSwiping)
//                 {
//                     EndSwipe(currentPosition);
//                 }
//             }
//             else
//             {
//                 if (!isSwiping)
//                 {
//                     StartSwipe(currentPosition);
//                 }
//                 else
//                 {
//                     ContinueSwipe(currentPosition);
//                 }
//             }
//         }
//         private void StartSwipe(Vector3 startPosition)
//         {
//             isSwiping = true;
//             this.startPosition = startPosition;
//             onSwipeStart?.Invoke(Vector2.zero);
//         }
//         private void ContinueSwipe(Vector3 currentPosition)
//         {
//             onSwipe?.Invoke(currentPosition - startPosition);
//         }
//         private void EndSwipe(Vector3 endPosition)
//         {
//             isSwiping = false;
//             onSwipeEnd?.Invoke(endPosition - startPosition);
//         }
//     }
// }