using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEnemy : MonoBehaviour
{
    public GameObject effectEnemy;
    
    public GameObject[] enemy;

    public float minTime;
    public float maxTime;
    
    // Start is called before the first frame update
    void Start()
    {
        // Thực hiện chạy và đệ quy vòng lặp
        StartCoroutine(Load());
    }
    
    // Lấy ngẫu nhiên vị trí là tọa độ trên
    Vector2 RandomTransform()
    {
        Vector2 tranform;
        tranform.x = Random.Range(-8, 8);
        tranform.y = Random.Range(-4, 4);

        return tranform;
    }


    IEnumerator SpawnEnemy()
    {
        
        // Thời gian ngẫu nhiên để xuất hiện Object 
        float time = Random.Range(minTime, maxTime);


        // Random Enemy
        int a = 0;
        a = Random.Range(0,3);

        // Sau thời gian time ngẫu nhiên Enemy sẽ được tạo
        yield return new WaitForSeconds(time);
        if(a == 2)
        {
            Transform spawnPoint;
            int count = Random.Range(0, SpawnPoint.points.Length);
            spawnPoint = SpawnPoint.points[count];
            Instantiate(enemy[a], spawnPoint.position, gameObject.transform.rotation);
        }
        else
        {
            Instantiate(enemy[a], RandomTransform(), gameObject.transform.rotation);
        }

        StartCoroutine(Load());
    }

    // Sau khoảng thời gian thì hàm này sẽ bắt đầu thực hiện việc random Enemy
    IEnumerator Load()
    {
        yield return new WaitForSeconds(10);

        StartCoroutine(SpawnEnemy());
    }
}
