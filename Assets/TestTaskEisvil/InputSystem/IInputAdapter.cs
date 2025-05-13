using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInputAdapter
{
    bool IsShootInput { get; }
    bool IsMenuButton { get; }
    bool IsEnabled { set; }
    Vector2 GetMovementInput();

    int ChangeWeaponInput();
}