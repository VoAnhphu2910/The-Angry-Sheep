using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public static Transform[] points;   // mảng chứa các điểm sinh ra Enemy

    // Start is called before the first frame update
    void Awake()
    {
        points = new Transform[transform.childCount];   // Set số phần tử của mảng bằng với số con của Object

        for (int i = 0; i < points.Length; i++)
        {
            points[i] = transform.GetChild(i);   // Set từng con của Object theo thứ tự vào mảng points
        }

    }

    #region
    /*
    public GameObject enemy;

    private int countEnemy = 0;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        if(countEnemy > 10)
        {
            StopAllCoroutines();
        }
    }

    void Spawn()
    {
        countEnemy++;
        Instantiate(enemy, transform.position, Quaternion.identity);
    }

    IEnumerator SpawnEnemy()
    {
        yield return new WaitForSeconds(2f);
        countEnemy++;
        Instantiate(enemy, transform.position, Quaternion.identity);
        StartCoroutine(SpawnEnemy());
    }
    */
    #endregion

}
