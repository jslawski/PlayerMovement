using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlideState : AirborneState
{
    public override void Enter(PlayerCharacter character)
    {
        //Play glide anim here
        this.moveSpeed = 5f;
        this.maxFallSpeed = 0.5f;
    }

    public override void HandleInput(PlayerCharacter character)
    {
        base.HandleInput(character);

        if (Input.GetKeyUp(KeyCode.Space))
        {
            this.ChangeState(character, new FallState());
        }
    }

    public override void Exit(PlayerCharacter character)
    {
        if (this.distanceToGround > 0.0f)
        {
            Vector3 correctionPosition = character.playerRb.position + (Vector3.down * this.distanceToGround);
            character.playerRb.MovePosition(correctionPosition);
        }

        base.Exit(character);
    }

    public override void UpdateState(PlayerCharacter character)
    {
        if (this.IsGrounded(character) == true)
        {            
            this.ChangeState(character, new IdleState());
            return;
        }

        base.UpdateState(character);
    }
}
