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

    public Level currentLevel;

    public GraphicsColorBeing gcb;

    private ColorState csAccumulatr;
    private int comboColor;

    public UnityEvent atTheStartOfLevel;

    private int obstacleInt;
    private bool isChunkLaunched;

    public void Awake()
    {
        currentLevel = lg.listOfLevels[levelNumberStart];

        isChunkLaunched = false;

        AttributeColor();
        LaunchCallLevel();
    }
    
    public void ChangeLevel()
    {
        
        currentLevel = lg.listOfLevels[currentLevel.LevelNumber + 1];

        atTheStartOfLevel.Invoke();

        LaunchCallLevel();
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
        if(currentLevel.chunkRandom)
        {
            foreach (var chunkGroup in currentLevel.chunksGroup)
            {
                yield return new WaitWhile(() => isChunkLaunched);
                isChunkLaunched = true;
                StartCoroutine(CallChunkGroup(chunkGroup));
            }

        }
        else
        {
            for (int i = 0; i < currentLevel.NumberOfChunks; i++)
            {
                yield return new WaitWhile(() => isChunkLaunched);
                isChunkLaunched = true;
                var _randInt = Random.Range(0, currentLevel.chunksGroup.Count);
                StartCoroutine(CallChunkGroup(currentLevel.chunksGroup[_randInt]));
            }
        }

        yield return new WaitWhile(() => isChunkLaunched);
        StartCoroutine(CallLevel(TypeOfObstacle.ChangeLevel));
    }

    private IEnumerator CallChunkGroup(ChunkGroup chunkGroup)
    {
        for (var i = 0; i< chunkGroup.typeOfObstacle.Count; i++)
        {
            var delay = chunkGroup.timeBeforeNext[i];

            //Check if the last obstacles wasnt the same color
            if (comboColor >= currentLevel.MaxComboColor)
            {
                if (csAccumulatr == ColorState.ColorOne)
                {
                    csAccumulatr = pm.GetAvalaibleEnemy(chunkGroup.typeOfObstacle[i]).Instantiate(startTransform, chunkGroup.speed[i]*currentLevel.ObstacleSpeed, ColorState.ColorTwo);
                }
                else
                {
                    csAccumulatr = pm.GetAvalaibleEnemy(chunkGroup.typeOfObstacle[i]).Instantiate(startTransform, chunkGroup.speed[i] * currentLevel.ObstacleSpeed, ColorState.ColorOne);
                }
                comboColor = 0;
            }
            else
            {
                var tempCs = pm.GetAvalaibleEnemy(chunkGroup.typeOfObstacle[i]).Instantiate(startTransform, chunkGroup.speed[i] * currentLevel.ObstacleSpeed);
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

            yield return new WaitForSeconds(delay);
        }

        isChunkLaunched = false;
    }


    private IEnumerator CallLevel(TypeOfObstacle typeOfObstacle)
    {
        var delay = currentLevel.TimeBetweenObstacle + Random.Range(-currentLevel.RandomTimeAddBetweenObstacle, currentLevel.RandomTimeAddBetweenObstacle);

        yield return new WaitForSeconds(delay);

        csAccumulatr = pm.GetAvalaibleEnemy(typeOfObstacle).Instantiate(startTransform, 7, ColorState.ColorOne);
    }

}
