using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelManager : MonoBehaviour
{
    public Vector3 startTransform;

    public PullManager pm;

    public LevelGenerator lg;

    public float waitBetweenLevel = 10f;

    public int levelNumberStart;

    public bool waitDuringLevel;

    public Level currentLevel;

    public GraphicsColorBeing gcb;

    private ColorState csAccumulatr;
    private int comboColor;

    public UnityEvent atTheStartOfLevel;

    private int obstacleInt;

    public void Awake()
    {
        currentLevel = lg.listOfLevels[levelNumberStart];
        AttributeColor();
        LaunchCallLevel();
    }
    
    public IEnumerator ChangeLevel()
    {
        waitDuringLevel = true;

        currentLevel = lg.listOfLevels[currentLevel.LevelNumber + 1];

        yield return new WaitForSeconds(waitBetweenLevel);

        atTheStartOfLevel.Invoke();

        waitDuringLevel = false;
    }

    public void TestObstacle()
    {
        obstacleInt++;
        if(obstacleInt >= currentLevel.NumberOfObstacle)
        {
            StartCoroutine(ChangeLevel());
        }
    }

    public void AttributeColor()
    {
        gcb.colorOne = currentLevel.LevelColorOne;
        gcb.colorTwo = currentLevel.LevelColorTwo;
    }

    public void SetObstacleInt(int i)
    {
        obstacleInt = i;
    }

    public void LaunchCallLevel()
    {

        StartCoroutine(CallLevel());
    }

    private IEnumerator CallLevel()
    {
        yield return new WaitWhile(() => waitDuringLevel);

        var delay = currentLevel.TimeBetweenObstacle + Random.Range(-currentLevel.RandomTimeAddBetweenObstacle, currentLevel.RandomTimeAddBetweenObstacle);

        yield return new WaitForSeconds(delay);

        //Check if the last obstacles wasnt the same color
        if(comboColor >= currentLevel.MaxComboColor)
        {
            if(csAccumulatr == ColorState.ColorOne)
            {
                csAccumulatr = pm.GetAvalaibleEnemy().Instantiate(startTransform, currentLevel.ObstacleSpeed, ColorState.ColorTwo);
            }
            else
            {
                csAccumulatr = pm.GetAvalaibleEnemy().Instantiate(startTransform, currentLevel.ObstacleSpeed, ColorState.ColorOne);
            }
            comboColor = 0;
        }
        else
        {
            var tempCs = pm.GetAvalaibleEnemy().Instantiate(startTransform, currentLevel.ObstacleSpeed);
            if (tempCs == csAccumulatr)
            {
                comboColor++;
            }
            else
            {
                comboColor = 0;
                csAccumulatr = tempCs;
            }
        }

        TestObstacle();
        //Equilibre le spawn des obstacle pour eviter d'en avoir 15 de la meme couleur
        StartCoroutine(CallLevel());
    }


}
