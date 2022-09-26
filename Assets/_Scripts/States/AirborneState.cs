using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirborneState : PlayerState
{
    private float initialJumpForce = 8f;
    private float residualJumpForce = 30f;
    private float residualJumpTime = 0.5f;
    float jumpBuffer = 0.5f;

    bool stillJumping = true;    

    private float moveSpeed = 8f;
    private Vector3 moveDirection = Vector3.zero;

    public override void Enter(PlayerCharacter character)
    {
        //Play jump anim here
        character.playerRb.AddForce(Vector3.up * this.initialJumpForce, ForceMode.Impulse);
        character.playerRb.useGravity = true;
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
        if (Input.GetKeyUp(KeyCode.Space) && this.stillJumping == true)
        {
            this.stillJumping = false;
            character.playerRb.velocity = Vector3.zero;
        }
    }

    public override void UpdateState(PlayerCharacter character)
    {
        if (this.stillJumping == false || this.residualJumpTime <= 0.0f)
        {
            RaycastHit hitInfo;

            float sweepTestDistance = 0.3f;// character.playerRb.velocity.y * Time.fixedDeltaTime;

            if (character.playerRb.SweepTest(Vector3.down, out hitInfo, sweepTestDistance))
            {
                Vector3 correctionPosition = character.playerRb.position + (Vector3.down * sweepTestDistance);
                character.playerRb.MovePosition(correctionPosition);

                this.ChangeState(character, new IdleState());
                return;
            }
        }

        Vector3 targetPosition = character.playerRb.position + (this.moveDirection * this.moveSpeed * Time.fixedDeltaTime);
        character.playerRb.MovePosition(targetPosition);

        if (this.stillJumping == true && this.residualJumpTime > 0.0f)
        {
            character.playerRb.AddForce(Vector3.up * this.residualJumpForce, ForceMode.Force);
            this.residualJumpTime -= Time.fixedDeltaTime;
        }        
    }
}
