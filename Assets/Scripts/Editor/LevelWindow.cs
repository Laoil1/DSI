using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public enum LevelWindowTab
{
    Level,
    ChunkGroups
}

public class LevelWindow : EditorWindow
{
    private LevelWindowTab lwt = LevelWindowTab.Level;
    private LevelGenerator lg;

    #region Initialisation 
        
    [MenuItem("DSI/LevelManager")]
    public static void Initialisation()
    {
        var win = EditorWindow.GetWindow(typeof(LevelWindow), false, "LevelManager", true);
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
        LevelWindowGUI();
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

        level.chunkRandom = EditorGUILayout.Toggle("Are Chunks Randoms ?", level.chunkRandom);
        if(level.chunkRandom)
            level.NumberOfChunks = EditorGUILayout.IntField("Number Of Chunks if Random", level.NumberOfChunks);

        //level.ObstacleSpeed = EditorGUILayout.FloatField("ObstacleSpeed", level.ObstacleSpeed);

        //level.TimeBetweenObstacle = EditorGUILayout.FloatField("TimeBetweenObstacle", level.TimeBetweenObstacle);
        //level.RandomTimeAddBetweenObstacle = EditorGUILayout.FloatField("RandomTimeAddBetweenObstacle", level.RandomTimeAddBetweenObstacle);


        GetChunkGroup(level.chunksGroup);

        SettingDirty();

    }
    
    private void GenerateLevelGUI()
    {
        if(GUILayout.Button("GENERATE ALL LEVELS"))
        {
            Debug.Log("generateLevels");
            lg.GenerateLevel();
            SettingDirty();
        }
    }

    private void GetChunkGroup(List<ChunkGroup> chunkGroup)
    {

        for (int i = 0; i < chunkGroup.Count; i++)
        {
            chunkGroup[i] = EditorGUILayout.ObjectField("Chunk Group" + i.ToString(),chunkGroup[i],typeof(ChunkGroup),false) as ChunkGroup;
        }

        if (GUILayout.Button("+", GUILayout.Width(100)))
        {
            chunkGroup.Add(null);
        }

        if (GUILayout.Button("-", GUILayout.Width (100)))
        {
            chunkGroup.RemoveAt(chunkGroup.Count - 1);
        }

        SettingDirty();

        EditorGUILayout.LabelField("");
    }


    private void ChunkGroupWindowGUI()
    {
        ChunckGroupChoice();
        if(lg.currentChunkGroup != null)
        {
            ChunckGroupInfo(lg.currentChunkGroup);
        }
    }

    private void ChunckGroupChoice()
    {
        if (lg.currentChunkGroup != null && lg.chunkGroups != null && lg.chunkGroups.Count > 0)
        {
            lg.currentChunkGroup = GetChunkGroupFromList("CurrentChunkGroup", lg.chunkGroups, lg.chunkGroups.IndexOf(lg.currentChunkGroup));
        }

        EditorGUILayout.BeginHorizontal();

        if (GUILayout.Button("+"))
        {
            lg.AddChunkGroup();
            lg.currentChunkGroup = lg.chunkGroups[lg.chunkGroups.Count - 1];
            SettingDirty();
        }

        if (GUILayout.Button("-"))
        {
            lg.chunkGroups.RemoveAt(lg.chunkGroups.Count - 1);
            SettingDirty();
        }
        EditorGUILayout.EndHorizontal();
    }

    private void ChunckGroupInfo(ChunkGroup chunkGroup)
    {

        chunkGroup.name = EditorGUILayout.TextField("Name", chunkGroup.name);

        for (int i = 0; i < chunkGroup.typeOfObstacle.Count; i++)
        {
            chunkGroup.typeOfObstacle[i] = (TypeOfObstacle)EditorGUILayout.EnumPopup("Obstacles " + i.ToString(), chunkGroup.typeOfObstacle[i]);
        }

        if (GUILayout.Button("+", GUILayout.Width(100)))
        {
            chunkGroup.typeOfObstacle.Add(TypeOfObstacle.Rectangle);
        }

        if (GUILayout.Button("-", GUILayout.Width(100)))
        {
            chunkGroup.typeOfObstacle.RemoveAt(chunkGroup.typeOfObstacle.Count - 1);
        }

        SettingDirty();
    }

    private void ChooseWindowGUI()
    {
        EditorGUILayout.BeginHorizontal();
        
        if(GUILayout.Button("Levels"))
        {
            lwt = LevelWindowTab.Level;
        }

        if (GUILayout.Button("ChunkGroups"))
        {
            lg.currentChunkGroup = lg.chunkGroups[0];
            lwt = LevelWindowTab.ChunkGroups;
        }

        EditorGUILayout.EndHorizontal();
    }

    private void LevelWindowGUI()
    {
        //LevelNumber
        EditorGUILayout.LabelField("You have " + lg.listOfLevels.Count + " Levels");
        LevelsAddOrRemoveGUI();

        //Divide Level
        DivideLevel();

        //ShowCurrentLevelGroup
        if (lg.currentLevelGroup != null)
        {
            ShowLevelGroupInfo(lg.currentLevelGroup);
        }

        //GenerateLEvelButton
        GenerateLevelGUI();
    }

    private ChunkGroup GetChunkGroupFromList (string label, List<ChunkGroup> list,int index)
    {
        string[] _nameList = new string[list.Count];
        for (int i = 0; i < list.Count; i++)
        {
            _nameList[i] = list[i].name;
        }

        //var index = list.IndexOf(currentchunkGroup);
        var _targetIndex = EditorGUILayout.Popup(label, index, _nameList);

        return list[_targetIndex];
    }
    private void SettingDirty()
    {
        EditorUtility.SetDirty(lg);
    }

}
