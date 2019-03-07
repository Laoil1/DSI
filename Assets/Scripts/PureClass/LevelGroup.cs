using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class LevelGroup
{
    public int minLevelInt;
    public int maxLevelInt;

    public Level minLevel;
    public Level maxLevel;

    public LevelGroup ()
    {
        minLevelInt = 0;
        maxLevelInt = 1;

        minLevel = new Level(0, 1.5f, 0.5f, Color.white, Color.black, 7f, 3);
        maxLevel = new Level(0, 1.5f, 0.5f, Color.white, Color.black, 7f, 3);
    }

    public void SetLevelsInt(int minInt, int maxInt)
    {
        minLevelInt = minInt;
        maxLevelInt = maxInt;

        minLevel.LevelNumber = minInt;
        maxLevel.LevelNumber = maxInt;
    }
}
