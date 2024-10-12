using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum UnitType {
        Mage,
        Warrior,
        Soldier,
        PlayerTroops
    }

public enum UnitState
{
    MovingToCastle,
    AttackingPlayer,
    AttackingEnemy
}

public enum UnitAttackType{
    Melee,
    Shooter
}