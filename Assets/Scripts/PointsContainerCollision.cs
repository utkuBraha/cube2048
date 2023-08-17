using System;
using UnityEngine;

namespace Cube2048
{
    public class PointsContainerCollision : MonoBehaviour
    {
        public event Action<PointsContainer> onCollisionStart;
        public event Action<PointsContainer> onCollisionContinue;

        private void OnCollisionEnter(Collision col)
        {
            var colContainer = col.gameObject.GetComponent<PointsContainer>();

            if (colContainer == null)
                return;
            
            onCollisionStart?.Invoke(colContainer);
            onCollisionContinue?.Invoke(colContainer);
        }
    }
}