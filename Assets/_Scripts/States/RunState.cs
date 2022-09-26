using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunState : PlayerState
{
    private float moveSpeed = 8f;
    private Vector3 moveDirection = Vector3.zero;

    public override void Enter(PlayerCharacter character)
    {
        //Start RunAnim anim here
    }

    public override void Exit(PlayerCharacter character)
    {
        //Do nothing here?
    }

    public override void HandleInput(PlayerCharacter character)
    {
        this.moveDirection = Vector3.zero;

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            this.moveDirection += Vector3.right;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            this.moveDirection += Vector3.left;
        }

        if (!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.RightArrow) &&
            !Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.LeftArrow) &&
            !Input.GetKey(KeyCode.Space))
        {
            character.currentState = new IdleState();
            character.currentState.Enter(character);
        }
    }

    public override void UpdateState(PlayerCharacter character)
    {
        Vector3 targetPosition = character.playerRb.position + (this.moveDirection * this.moveSpeed * Time.fixedDeltaTime);
        character.playerRb.MovePosition(targetPosition);
    }
}
