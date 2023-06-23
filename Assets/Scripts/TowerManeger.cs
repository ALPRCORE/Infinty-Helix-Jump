using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TowerManeger : MonoBehaviour
{


    [SerializeField] List<GameObject> ringsList;
    public int no0fRings;
    public float ringDistance = 6f;
    float yPos;

    void Start()
    {
        no0fRings = GameManager.inLevelIndex + 20;
        int lastIndex = ringsList.Count - 1; // last ring index
        for (int i = 0; i < no0fRings - 1; i++)
        {
            if (i == 0)
            {
                SpawnRings(0);
            }
            else
            {
                SpawnRings(Random.Range(1, ringsList.Count - 1));
            }
        }
        // last ring spawnlama
        SpawnRings(lastIndex);
    }

    void SpawnRings(int index)
    {
        GameObject newRing = Instantiate(ringsList[index], new Vector3(transform.position.x, yPos, transform.position.z), Quaternion.identity);
        yPos -= ringDistance;
        newRing.transform.parent = transform;
    }








































    /* //public GameObject[] rings;
    [SerializeField] List<GameObject> ringsList;
    //public GameObject[] lastRing;
    public int no0fRings;
    public float ringDistance = 6f;
    float yPos;
    private void Start()
    {
        no0fRings = GameManager.inLevelIndex + 10;
        for (int i = 0; i < no0fRings; i++)
        {
            if (i == 0)
            {
                SpawnRings(0);

            }
            else
            {
                SpawnRings(Random.Range(1, ringsList.Count - 1));
            }

            SpawnRings(ringsList.Count - 1);
        }
    }
    void SpawnRings(int index)
    {
        GameObject newRing = Instantiate(ringsList[index], new Vector3(transform.position.x, yPos, transform.position.z), Quaternion.identity);
        yPos -= ringDistance;
        newRing.transform.parent = transform;
    }*/
}
