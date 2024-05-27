using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interaction : MonoBehaviour
{
    private PlayerInput _playerInput;
    private Transform _transform;

    [SerializeField] private Transform _crossHairTrans;
    
    private void Awake()
    {
        _transform = transform;
        _playerInput = GetComponent<PlayerInput>();
    }

    private void OnEnable()
    {
        _playerInput.actions["Interact"].performed += OnInteractP;
    }
    private void OnDisable()
    {
        _playerInput.actions["Interact"].performed -= OnInteractP;
    }

    private void OnInteractP(InputAction.CallbackContext callbackContext)
    {
        Debug.Log("Interact");
        //raycast
        Physics.Raycast(_crossHairTrans.position, _transform.forward, out var hit, 1.5f);
    }
}
