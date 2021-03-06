﻿using System.Collections.Generic;
using Common.Game.ObjectsModel;
using UnityEngine;

namespace Common.Game.Props
{
  public interface IGameplayProps
  {
    int MinLane { get; }

    int MaxLane { get; }
    
    IEnumerable<IStairsObject> StairsPrefabs { get; }
    
    int StartDifficulty { get; }
    
    Vector3 PlayerStartPosition { get; }
    
    float PseudoGravity { get; }
    
    int StairsToUpDifficulty { get; }
  }
}
