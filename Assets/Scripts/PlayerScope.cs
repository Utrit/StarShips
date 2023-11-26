using System.Collections;
using System.Collections.Generic;
using FishNet.Object;
using UnityEngine;

public class PlayerScope : NetworkBehaviour
{
    private Camera _playerCamera;
    
    public override void OnStartClient()
    {
        base.OnStartClient();
        if (IsOwner)
        {
            _playerCamera = Camera.main;
            _playerCamera.transform.SetParent(transform);
            _playerCamera.transform.localPosition = new Vector3(0, 1, -5);
            return;
        }
        Destroy(this);
    }

    void Start()
    {
        
    }

    void Update()
    {
        var dir = Input.GetAxis("Horizontal") * Vector3.right;
        dir += Input.GetAxis("Vertical") * Vector3.forward;
        dir.Normalize();
        transform.position += dir * Time.deltaTime;
    }
}
