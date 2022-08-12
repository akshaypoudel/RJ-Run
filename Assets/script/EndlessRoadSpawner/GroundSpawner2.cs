using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSpawner2 : MonoBehaviour
{
    [SerializeField] private GameObject[] groundTile;
    private int randomNumber;
    private bool canSpawnCityRoad=true;
    [SerializeField]private float MaxPosToSpawnRoad;
    [SerializeField]private float spawnAfterMaxPos;
    public Vector3 nextSpawnPoint;
    List<int> list;
    private int count=0;
    public float rotateValue;
    [SerializeField]private GameObject CityRoad;
    private Transform Player;

    private void Start () {
        list= new List<int>();
        Player=GameObject.Find("Player").transform;
        count=0;
        GenerateRandom();
        randomNumber=list[count++];
        for (int i = 0; i < 4; i++) {
            SpawnTile();
        }
    }
    public void SpawnTile()
    {
        if(Player.position.x>MaxPosToSpawnRoad && canSpawnCityRoad)
        {
            canSpawnCityRoad=false;
            MaxPosToSpawnRoad+=spawnAfterMaxPos;
            GameObject temp=Instantiate(CityRoad,nextSpawnPoint,Quaternion.identity);
            nextSpawnPoint=temp.transform.GetChild(1).transform.position;
        }
        else
        {
            GameObject temp = Instantiate(groundTile[randomNumber],nextSpawnPoint,Quaternion.Euler(0,rotateValue,0));
            nextSpawnPoint = temp.transform.GetChild(1).transform.position;
            if(Player.position.x>MaxPosToSpawnRoad && !canSpawnCityRoad)
                canSpawnCityRoad=true;
        }
        if(count < groundTile.Length)
        {
            randomNumber=list[count];
            ++count;
        }
        else
        {
            count=0;
            GenerateRandom();
            randomNumber=list[count++];
        }
    }

    void GenerateRandom()
    {
        int Rand;
        list.Clear();
        for (int j = 0; j < groundTile.Length; j++)
        {
            Rand = Random.Range(0,groundTile.Length);
            while(list.Contains(Rand))
            {
                Rand = Random.Range(0,groundTile.Length);
            }
            list.Add(Rand);
        }
    }
}
