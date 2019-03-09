using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public List<int> waves = new List<int>();

    public int waveCount = 5;
    
    public GameObject[] Monsters;
    public int Monsterindex = 0;

    public GameObject[] spawnPositions;
    private Vector3 pos;

    private void Start()
    {
        pos = spawnPositions[0].transform.position;
        for (int i = 0; i < waveCount; i++)
        {
            waves.Add(i);
            MonsterSpawner(waves[i]);
        }

    }

    public void MonsterSpawner(int waves)
    {
        switch (waves)
        {
            case 0:
                Instantiate(Monsters[Monsterindex], pos, spawnPositions[0].transform.rotation);
                break;
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            default:
                break;

        }
    }
}
