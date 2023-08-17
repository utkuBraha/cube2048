using System.Collections;
using UnityEngine;

namespace Cube2048
{
    public class CubeSpawner : MonoBehaviour
    {
        [SerializeField] private float spawnDelay = 0.3f;
        [SerializeField] private GameObject cubePrefab;
        [SerializeField] private GameObject swipeDetectorObject;
        private CubeController[] cubeDependencies;
        private ISwipeDetector swipeDetector;
        private Coroutine spawnRoute;
        
        private void Start()
        {
            swipeDetector = swipeDetectorObject.GetComponent<ISwipeDetector>();
            cubeDependencies = FindObjectsOfType<CubeController>();
            Subscribe();
        }
        private void Subscribe()
        {
            swipeDetector.onSwipeEnd += OnSwipeEnd;
        }
        private void Unsubscribe()
        {
            swipeDetector.onSwipeEnd -= OnSwipeEnd;
        }
        private void OnSwipeEnd(Vector2 delta)
        {
            if (spawnRoute == null)
                spawnRoute = StartCoroutine(SpawnWithDelay());
        }
        private IEnumerator SpawnWithDelay()
        {
            yield return null;
            yield return new WaitForSeconds(spawnDelay);
            var instance = Instantiate(cubePrefab, transform.position, Quaternion.identity);
            InjectCube(instance.gameObject);
            spawnRoute = null;
        }
        private void InjectCube(GameObject cube)
        {
            foreach (var dependency in cubeDependencies)
            {
                dependency.Cube = cube;
            }
        }
        private void OnDestroy()
        {
            Unsubscribe();
        }
    }
}