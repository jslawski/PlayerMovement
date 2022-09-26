using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    public PlayerState currentState;
    
    [HideInInspector]
    public Rigidbody playerRb;
    [HideInInspector]
    public BoxCollider playerCollider;
    
    public LayerMask groundLayer;

    // Start is called before the first frame update
    void Start()
    {
        this.playerRb = GetComponent<Rigidbody>();
        this.playerCollider = GetComponent<BoxCollider>();
        this.currentState = new FallState();
        this.currentState.Enter(this);
    }

    // Update is called once per frame
    void Update()
    {
        this.currentState.HandleInput(this);        
    }

    private void FixedUpdate()
    {
        this.currentState.UpdateState(this);
    }    
}
