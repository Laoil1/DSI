using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public enum LevelWindowTab
{

}

public class LevelWindow : EditorWindow
{

    private LevelGenerator lg;

    #region Initialisation 
        
    [MenuItem("DSI/LevelManager")]
    public static void Initialisation()
    {
        var win = EditorWindow.GetWindow(typeof(LevelWindow), true, "LevelManager", true);
        var size = new Vector2(500f, 350f);

        win.minSize = size;

        win.Show();

    }
        

    #endregion

    // Start is called before the first frame update
    private void OnEnable()
    {
        LoadRessources();
        if(lg.listOfLevels == null)
        {
            lg.GenerateLevelsBase();
        }
    }

    // Update is called once per frame
    private void OnGUI()
    {
        //LevelNumber
        EditorGUILayout.LabelField("You have " + lg.listOfLevels.Count + " Levels");
        LevelsAddOrRemoveGUI();

        //Divide Level
        DivideLevel();

        //ShowCurrentLevelGroup
        if(lg.currentLevelGroup != null)
        {
            ShowLevelGroupInfo(lg.currentLevelGroup);
        }

        //GenerateLEvelButton
        GenerateLevelGUI();

    }

    private void LoadRessources()
    {
        lg = Resources.Load<LevelGenerator>("lg") ;

    }

    private void LevelsAddOrRemoveGUI()
    {
        EditorGUILayout.BeginHorizontal();

            if(GUILayout.Button("Add 1",EditorStyles.miniButtonLeft))
            {
            lg.AddLevels(1);
            SettingDirty();
        }
            if (GUILayout.Button("Add 10", EditorStyles.miniButtonMid))
            {
                lg.AddLevels(10);
            SettingDirty();
        }
            if (GUILayout.Button("Add 50", EditorStyles.miniButtonMid))
            {
                lg.AddLevels(50);
            SettingDirty();
        }
            if (GUILayout.Button("Remove 1", EditorStyles.miniButtonMid))
            {
                lg.RemoveLevels(1);
            SettingDirty();
        }
            if (GUILayout.Button("Remove 10", EditorStyles.miniButtonMid))
            {
                lg.RemoveLevels(10);
            SettingDirty();
        }
            if (GUILayout.Button("Remove 50", EditorStyles.miniButtonRight))
            {
                lg.RemoveLevels(50);
                SettingDirty();
            }
        EditorGUILayout.EndHorizontal();

    }

    private void DivideLevel()
    {
        EditorGUILayout.BeginHorizontal();

        lg.tempLevelDivide = EditorGUILayout.IntField("You divide per :", lg.tempLevelDivide);

        if (lg.tempLevelDivide<=0)
        {
            lg.tempLevelDivide = 1;
        }

        if(GUILayout.Button("DIVIDE!"))
        {
            lg.SetDivide(lg.tempLevelDivide);
            for (int i = 0; i < lg.levelGroups.Count-1; i ++)
            {
                lg.levelGroups[i].LevelNumber = lg.levelDivide*i;
            }

            lg.levelGroups[lg.levelGroups.Count-1].LevelNumber = lg.listOfLevels.Count-1;
        }

        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();

        if(lg.levelGroups != null)

        foreach (var levelGroup in lg.levelGroups)
        {
            if(GUILayout.Button(levelGroup.LevelNumber.ToString()))
            {
                    lg.currentLevelGroup = levelGroup;
            }
        }

        EditorGUILayout.EndHorizontal();
        

    }

    private void ShowLevelGroupInfo(Level level)
    {
        EditorGUILayout.LabelField("Level " + level.LevelNumber.ToString(), EditorStyles.boldLabel);

        level.LevelColorOne = EditorGUILayout.ColorField("ColorOne ", level.LevelColorOne);
        level.LevelColorTwo = EditorGUILayout.ColorField("ColorTwo ", level.LevelColorTwo);

        level.MaxComboColor = EditorGUILayout.IntField("Max ComboColor", level.MaxComboColor);
        level.NumberOfObstacle = EditorGUILayout.IntField("Number Of Obstacle", level.NumberOfObstacle);

        level.ObstacleSpeed = EditorGUILayout.FloatField("ObstacleSpeed", level.ObstacleSpeed);

        level.TimeBetweenObstacle = EditorGUILayout.FloatField("TimeBetweenObstacle", level.TimeBetweenObstacle);
        level.RandomTimeAddBetweenObstacle = EditorGUILayout.FloatField("RandomTimeAddBetweenObstacle", level.RandomTimeAddBetweenObstacle);

        GetObstacle(level.chunkGroup);

        SettingDirty();

    }
    
    private void GenerateLevelGUI()
    {
        if(GUILayout.Button("GENERATE ALL LEVELS"))
        {
            lg.GenerateLevel();
            SettingDirty();
        }
    }

    private void GetObstacle(List<TypeOfObstacle> chunkGroup)
    {

        for (int i = 0; i < chunkGroup.Count; i++)
        {
            chunkGroup[i] = (TypeOfObstacle)EditorGUILayout.EnumPopup("Obstacles " + i.ToString(), chunkGroup[i]);
        }

        if (GUILayout.Button("+", GUILayout.Width(100)))
        {
            chunkGroup.Add(TypeOfObstacle.Rectangle);
        }

        if (GUILayout.Button("-", GUILayout.Width (100)))
        {
            chunkGroup.RemoveAt(chunkGroup.Count - 1);
        }

        EditorGUILayout.LabelField("");
    }

    private void SettingDirty()
    {
        EditorUtility.SetDirty(lg);
    }
}
