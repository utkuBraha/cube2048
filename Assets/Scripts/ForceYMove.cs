using System;
using System.Collections;
using UnityEngine;

namespace Cube2048
{
    public class ForceYMovementSwipeHandler : MonoBehaviour, IMovableObject
    {
        [SerializeField] private float force = 1.0f;
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
            moveRb.AddForce(moveRb.transform.forward * force, ForceMode.Impulse);
            StartCoroutine(ChangeCubeTagAndCheck(moveRb.gameObject));
            moveRb = null;
           
        }
        private IEnumerator ChangeCubeTagAndCheck(GameObject go)
        {
            yield return new WaitForSeconds(1.0f);
        
            if (go == null) yield break;
            go.tag = "ChangedCube";
            Debug.Log("Cube tag changed");
        
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