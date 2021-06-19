using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Chest", menuName = "ChestItems", order = 52)] // 
public class NewBehaviourScript : ScriptableObject
{
    public enum ChestTypes{
         Common,
         Rare,
         Epic,
         Legendary
    };


}
