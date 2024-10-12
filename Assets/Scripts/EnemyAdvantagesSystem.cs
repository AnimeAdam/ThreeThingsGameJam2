using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyAdvantagesSystem : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    static public bool DoesAttackerHaveAdvantage(UnitType attacker, UnitType defender)
    {
        if (attacker == UnitType.Mage && defender == UnitType.Soldier){
            return true;
        }
        if (attacker == UnitType.Soldier && defender == UnitType.Warrior){
            return true;
        }
        if (attacker == UnitType.Warrior && defender == UnitType.Mage){
            return true;
        }
        return false;
    }
}
