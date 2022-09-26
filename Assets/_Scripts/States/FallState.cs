using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallState : AirborneState
{
    public override void Enter(PlayerCharacter character)
    {
        base.Enter(character);
        character.playerRb.velocity = Vector3.zero;
        //Play fall anim here?
    }

    public override void UpdateState(PlayerCharacter character)
    {
        base.UpdateState(character);

        if (this.IsGrounded(character) == true)
        {
            Vector3 correctionPosition = character.playerRb.position + (Vector3.down * this.distanceToGround);
            character.playerRb.MovePosition(correctionPosition);
            this.ChangeState(character, new IdleState());            
        }        
    }
}
