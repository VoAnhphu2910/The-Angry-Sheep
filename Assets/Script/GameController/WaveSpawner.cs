using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour
{
    public Wave[] waves; // Mảng chứa đợt tấn công

    //public static int EnemiesAlive = 0; // Số Enemy trên bản đồ

    public float timeBetweenWaves = 5f; // Thời gian giữa các lần sinh enenmy
    private float countDown = 2f;   // Số đếm thời gian sinh enemy đầu tiên

    private int waveIndex = 0;  // Số enemy sinh ra

    public Text waveCountdownText;  // Hiển thị thời gian sinh ra enemy

    public GameController gameController;
    public static int count;
    Wave wave;
    // Update is called once per frame
    void Update()
    {
        if (count > 0)   // Nếu còn Enemy thì không sinh ra nữa
        {
            return;
        }
        
        if (waveIndex == waves.Length && GameController.enemiesAlive <= 0)
        {
            gameController.winGame = true;
            this.enabled = false;
            return;
        }

        if (countDown <= 0f) // Nếu thời gian bằng không thì sinh ra enemy
        {
            StartCoroutine(SpawnWave());
            countDown = timeBetweenWaves;   // Set thời gian trở lại ban đầu
            waveCountdownText.text = "";
            return;
        }

        countDown -= Time.deltaTime;    // Trừ đi thời gian theo mỗi khung hình

        countDown = Mathf.Clamp(countDown, 0f, Mathf.Infinity); // Đảm bảo số không âm

        waveCountdownText.text = string.Format("{0:00.00}", countDown); // Làm tròn các số thập phân hiển thị
    }

    IEnumerator SpawnWave()
    {

        wave = waves[waveIndex];   // Tạo biến chứa Object enemy của class wave

        //GameController.enemiesAlive = wave.count;  // Số lượng Enemy hiện tại bằng với số lượng trong class wave
        //GameController.enemiesAlive = wave.count;  // Số lượng Enemy hiện tại bằng với số lượng trong class wave
        count = wave.count;
        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy); // Truyền biến Enemy từ class wave vào và tạo
            yield return new WaitForSeconds(wave.rate);  // Sau time sẽ sinh ra một enemy
        }

        waveIndex++;    // Cộng số enemy được sinh ra lên
    }

    void SpawnEnemy(GameObject enemy)
    {
        Transform spawnPoint;
        int count = Random.Range(0, SpawnPoint.points.Length);
        spawnPoint = SpawnPoint.points[count];
        Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);    // Sinh ra phần tử enemy ngay vị tró Object

        GameController.enemiesAlive++; //+ mỗi lần sinh ra enemy
    }
}
