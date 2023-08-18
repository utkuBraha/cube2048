using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeInputSystem : MonoBehaviour
{
    public float PlayersMovementSPeed;
    private NewControls _inputActionReference; 
    private Rigidbody2D _playersRigidBody;
    [SerializeField] private float force = 1.0f;

    private void Start()
    {
        _playersRigidBody ??= GetComponent<Rigidbody2D>();

        _inputActionReference = new NewControls();
        _inputActionReference.Enable();
        
        _inputActionReference.Ground.Swipe.performed += swipping => { Swipe(swipping.ReadValue<float>()); };

    }


    private void Swipe(float direction)
    {
        _playersRigidBody.velocity = new Vector3(direction * PlayersMovementSPeed, _playersRigidBody.velocity.y);
    }

    private void Relase(Vector2 delta)
    {
        _playersRigidBody.AddForce(_playersRigidBody.transform.forward * force*  (float)ForceMode.Impulse);
    }
}