using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour
{
    public PlayerState currentState;
    public Rigidbody playerRb;

    // Start is called before the first frame update
    void Start()
    {
        this.playerRb = GetComponent<Rigidbody>();
        this.currentState = new IdleState();
        this.currentState.Enter(this);
    }

    private void HandleInput()
    { 
        
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
