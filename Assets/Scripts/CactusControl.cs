using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusControl : MonoBehaviour
{
    [SerializeField] GameObject cactus1;
    [SerializeField] GameObject cactus2;
    [SerializeField] GameObject cactus3;
    [SerializeField] List<GameObject> cactusPool1;
    [SerializeField] List<GameObject> cactusPool2;
    [SerializeField] List<GameObject> cactusPool3;

    [SerializeField] float interval;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawCactusPerSec());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawCactusPerSec()
    {
        yield return new WaitForSeconds(interval);
        int rd = Random.Range(1, 4);
        Debug.Log(rd);
        if (rd == 1) CreateCactus1();
        else if (rd == 2) CreateCactus2();
        else CreateCactus3();
        StartCoroutine(SpawCactusPerSec());
    }

    GameObject getCactus1()
    {
        foreach (GameObject c in cactusPool1)
        {
            if (c.gameObject.activeSelf) continue;
            return c;
        }
        GameObject newCactus = Instantiate(cactus1, this.transform.position, Quaternion.identity);
        cactusPool1.Add(newCactus);
        return newCactus;
    }

    public void CreateCactus1()
    {
        GameObject spawnCactus = getCactus1();
        spawnCactus.GetComponent<Cactus>().GenerateSpike();
        spawnCactus.transform.position = this.transform.position;
    }

    GameObject getCactus2()
    {
        foreach (GameObject c in cactusPool2)
        {
            if (c.gameObject.activeSelf) continue;
            return c;
        }
        GameObject newCactus = Instantiate(cactus2, this.transform.position, Quaternion.identity);
        cactusPool2.Add(newCactus);
        return newCactus;
    }

    public void CreateCactus2()
    {
        GameObject spawnCactus = getCactus2();
        spawnCactus.GetComponent<Cactus>().GenerateSpike();
        spawnCactus.transform.position = this.transform.position;
    }

    GameObject getCactus3()
    {
        foreach (GameObject c in cactusPool3)
        {
            if (c.gameObject.activeSelf) continue;
            return c;
        }
        GameObject newCactus = Instantiate(cactus3, this.transform.position, Quaternion.identity);
        cactusPool3.Add(newCactus);
        return newCactus;
    }

    public void CreateCactus3()
    {
        GameObject spawnCactus = getCactus3();
        spawnCactus.GetComponent<Cactus>().GenerateSpike();
        spawnCactus.transform.position = this.transform.position;
    }
}
