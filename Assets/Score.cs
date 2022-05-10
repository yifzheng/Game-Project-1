using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Score
{
    public float score;
    public string playerName;

    public Score(string name, float score)
    {
        this.playerName = name;
        this.score = score;
    }
}