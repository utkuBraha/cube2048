using UnityEngine;

namespace Cube2048
{
    public class CubeTriggerAndValue : MonoBehaviour
    {
       
        public StartGame start;

        public void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("ChangedCube"))
            {

                start.GameOver(); 
                Debug.Log("trigger");
           }
        }
    }
}

        