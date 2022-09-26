using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    public virtual void Enter(PlayerCharacter character) { }

    public virtual void ChangeState(PlayerCharacter character, PlayerState newState)
    {
        character.currentState = newState;
        newState.Enter(character);
    }

    public virtual void HandleInput(PlayerCharacter character) { }
    public virtual void UpdateState(PlayerCharacter character) { }
}
