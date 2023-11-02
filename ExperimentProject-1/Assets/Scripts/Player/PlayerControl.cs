using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidbody;

    public float
        sensitivityX,
        sensitivityY;

    private void Awake()
    {
        GetReference();
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    private void GetReference()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    
}
