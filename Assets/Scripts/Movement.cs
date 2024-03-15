using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float boostForce = 1000f;
    [SerializeField] float rotateForce = .001f;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        BoostInput();
        RotateInput();
        
    }

    void BoostInput(){
        if(Input.GetKey(KeyCode.Space)){
            rb.AddRelativeForce(boostForce * Time.deltaTime * Vector3.up);
        }
    }

    public void RotateInput(){

        if(Input.GetKey(KeyCode.A)){
            ApplyRotation(1.0f);
        }   

        if(Input.GetKey(KeyCode.D)){
            ApplyRotation(-1.0f);
        }
    }

    private void ApplyRotation(float direction){
        rb.freezeRotation = true;
        transform.Rotate(direction * rotateForce * Time.deltaTime * Vector3.forward);
    }

    private void OnCollisionEnter(Collision other) {
        if(other.collider.CompareTag("Starting") || other.collider.CompareTag("Landing")){
            rb.freezeRotation = false;
        }else{
            Debug.Log("Oooops, you loose!");
            rb.freezeRotation = false;
        }
    }
}
