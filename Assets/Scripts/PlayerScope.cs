using System.Collections;
using System.Collections.Generic;
using FishNet.Object;
using NaughtyAttributes;
using UnityEngine;

public class PlayerScope : NetworkBehaviour
{
    [SerializeField] private float _movementSpeed;
    [SerializeField] private Rigidbody _rigidbody;
    private Camera _playerCamera;
    
    public override void OnStartClient()
    {
        if (IsOwner)
        {
            _playerCamera = Camera.main;
            _playerCamera.transform.SetParent(transform);
            _playerCamera.transform.localPosition = new Vector3(0, 2.5f, -5);
            return;
        }
        enabled = false;
    }

    void Start()
    {
        
    }

    void Update()
    {
        var dir = Input.GetAxis("Vertical") * transform.forward;
        var rotation = Input.GetAxis("Horizontal");
        dir.Normalize();
        _rigidbody.AddForce(dir * (Time.deltaTime * _movementSpeed),ForceMode.Acceleration);
        _rigidbody.AddTorque(0,rotation*Time.deltaTime*60f,0);
    }

    [Button]
    private void FindRefs()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
}
