using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject enemy;
    public Camera cam;

    public int SpawnAmount;
    public int waveNumber;

    public float height;
    public float width;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        waveNumber = 1;
        SpawnAmount = PlayerData.getPlayerLevel() + (waveNumber * 3);
        Debug.Log("spawn amount = " +SpawnAmount);
    }

    // Update is called once per frame
    void Update()
    {
        height = cam.orthographicSize +1;
        width = cam.orthographicSize * cam.aspect + 1;

        if(FindObjectsOfType<enemy1>().Length <= 0)
        {
            StartCoroutine(spawnEnemies());
        }
    }

    IEnumerator spawnEnemies()
    {
        int d = 1;
        for (int i = 0; i < SpawnAmount; i++)
        {
            Instantiate(enemy, new Vector3(cam.transform.position.x + width*d, cam.transform.position.y, 0), Quaternion.identity);
            Debug.Log (i);
            d *= -1;
            yield return new WaitForSeconds(1);
        }
        waveNumber++;
        SpawnAmount = PlayerData.getPlayerLevel() + (waveNumber * 3);
    }
}
