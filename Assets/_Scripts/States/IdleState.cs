using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : PlayerState
{
    public override void Enter(PlayerCharacter character)
    {
        //Play idle anim here
        character.playerRb.useGravity = false;
    }

    public override void Exit(PlayerCharacter character)
    {
        //Do nothing here?
    }

    public override void HandleInput(PlayerCharacter character)
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) ||
            Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {            
            character.currentState = new RunState();            
            this.Exit(character);
            character.currentState.Enter(character);
        }
    }

    public override void UpdateState(PlayerCharacter character)
    { 
        //Nothing here
    }

}
