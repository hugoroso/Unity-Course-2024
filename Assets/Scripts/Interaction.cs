using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interaction : MonoBehaviour
{
    private PlayerInput _playerInput;
    private Transform _transform;

    [SerializeField] private Transform crossHairTrans;
    [SerializeField] private LayerMask interactableLayer;
    
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
        //raycast if didn't hit exit function
        if(!Physics.Raycast(crossHairTrans.position, crossHairTrans.forward, out var hit, 2.5f,interactableLayer)) return;
        
        if(!hit.transform.TryGetComponent(out InteractableObject interactible)) return;
        interactible.Interact();
        
        Debug.Log("I hit: " + hit.transform.gameObject.name);
    }

    void Update()
    {
        Debug.DrawRay(crossHairTrans.position, crossHairTrans.forward, Color.red);
    }
}
