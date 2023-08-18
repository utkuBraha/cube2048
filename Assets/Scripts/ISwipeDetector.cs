using System;
using UnityEngine;

namespace Cube2048
{
    public interface ISwipeDetector
    {
        event Action<Vector2> onSwipeStart; 
        event Action<Vector2> onSwipe;
        event Action<Vector2> onSwipeEnd;
    }
}