using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playermovement : MonoBehaviour
{
    [SerializeField] private LayerMask layermasK;
    [Range( 1, 50),SerializeField] private float jumpingheight;
    [SerializeField] private Rigidbody2D rb;
    [Range( 1, 50), SerializeField] private float speed;
    private bool jump;
    
    
    // Start is called before the first frame update
    void Start()
    {
        jump = true;
    }

    // Update is called once per frame
    void Update()
    {
        jump = Physics2D.OverlapCircle(transform.position - new Vector3(0, 1, 0), .2f, layermasK);

    }

    void OnWalking(InputValue inputValue)
    {
        rb.velocity =inputValue.Get<Vector2>()*  speed;
        Debug.Log(inputValue.Get<Vector2>());
    }

    void OnJumping()
    {
        if (jump== true)
        {
            rb.velocity = new Vector2(0, 1) * jumpingheight;
            jump = false;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position - new Vector3(0, 1, 0), .2f);
    }
}
