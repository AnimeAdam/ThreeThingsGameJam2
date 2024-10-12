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
    AttackingEnemy,
    AttackingCastle
}

public enum UnitAttackType{
    Melee,
    Shooter
}

public enum CastleSelection{
    CastlePointA = 0,
    CastlePointB = 1,
    CastlePointC = 2,
    CastlePointD = 3,
}