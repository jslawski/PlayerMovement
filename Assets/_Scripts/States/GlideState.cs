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

    public override void UpdateState(PlayerCharacter character)
    {
        base.UpdateState(character);

        if (this.IsGrounded(character) == true)
        {
            Vector3 correctionPosition = character.playerRb.position + (Vector3.down * this.distanceToGround);
            character.playerRb.MovePosition(correctionPosition);
            this.ChangeState(character, new IdleState());
            return;
        }
    }
}
