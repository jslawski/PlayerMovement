using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    protected float distanceToGround = 0.0f;
    
    public virtual void Enter(PlayerCharacter character) { }

    public virtual void ChangeState(PlayerCharacter character, PlayerState newState)
    {
        Debug.LogError(newState);

        character.currentState = newState;
        newState.Enter(character);
    }

    public virtual void HandleInput(PlayerCharacter character) { }
    public virtual void UpdateState(PlayerCharacter character) { }

    public virtual bool IsGrounded(PlayerCharacter character)
    {
        Vector3 leftOrigin = character.playerRb.position - new Vector3(character.playerCollider.bounds.extents.x, 0.0f, 0.0f);
        Vector3 rightOrigin = character.playerRb.position + new Vector3(character.playerCollider.bounds.extents.x, 0.0f, 0.0f);

        float raycastMagnitude = character.playerCollider.bounds.extents.y + (Mathf.Abs(character.playerRb.velocity.y) * Time.fixedDeltaTime);

        RaycastHit hitInfoLeft;
        RaycastHit hitInfoRight;

        bool leftHit = Physics.Raycast(leftOrigin, Vector3.down, out hitInfoLeft, raycastMagnitude, character.groundLayer);
        bool rightHit = Physics.Raycast(rightOrigin, Vector3.down, out hitInfoRight, raycastMagnitude, character.groundLayer);

        if (leftHit == true)
        {
            this.distanceToGround = hitInfoLeft.distance;
        }
        else if (rightHit == true)
        {
            this.distanceToGround = hitInfoRight.distance;
        }

        return (leftHit || rightHit);
    }
}
