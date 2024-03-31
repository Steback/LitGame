using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameInstanceData", menuName = "ScriptableObjects/GameInstanceData", order = 1)]
public class GameInstanceData : ScriptableObject
{
    public string defaultAnimationState = "House";
}
