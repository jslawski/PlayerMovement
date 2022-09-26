using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerState
{
    public abstract void Enter(PlayerCharacter character);
    public abstract void Exit(PlayerCharacter character);
    public abstract void HandleInput(PlayerCharacter character);
    public abstract void UpdateState(PlayerCharacter character);
}
