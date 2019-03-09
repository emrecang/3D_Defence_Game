using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public int waves = 1;
    public int waveCount = 5;

    public GameObject[] Monsters;
    public int Monsterindex = 0;

    public GameObject[] spawnPositions;
    public int SpawnPosIndex = 0;
    private Vector3 pos;

    public void Start()
    {
        pos = spawnPositions[0].transform.position;
        StartCoroutine(MonsterSpawner(waves));
    }
   
    IEnumerator MonsterSpawner(int waves)
    {
        if(waves == 1)
        {
            for (int i = 0; i < 10; i++)
            {
                Instantiate(Monsters[Monsterindex], pos, spawnPositions[SpawnPosIndex].transform.rotation);
                yield return new WaitForSeconds(1.0f);
            }
        }
    }
    
}
