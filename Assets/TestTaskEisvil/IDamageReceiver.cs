using System.Collections;
using System.Collections.Generic;
using TestTaskEisvil.Characters;
using UnityEngine;

public interface IDamageReceiver
{
    void ReceiveDamage(int damage, IDamageSource source);
}
