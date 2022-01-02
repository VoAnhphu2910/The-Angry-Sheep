using UnityEngine;
using UnityEngine.UI;

public class EnemyController : MonoBehaviour
{
    public Image healthBar;

    public float health;

    public float starHealth = 100;

    public int dame = 20;

    public GameObject deathEffect;

    //PlayerController player;

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        //GameController.enemiesAlive++;
        audioSource = gameObject.GetComponent<AudioSource>();
        // Gán máu bằng lượng máu ban đầu đã cho
        health = starHealth;
        //player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    // Hàm gây dame cho Object
    public void TakeDame(int dame)
    {
        health -= dame;
        audioSource.Play();
        // Giảm lượng máu theo phần trăm dựa vào số máu hiện tại và máu ban đầu
        healthBar.fillAmount = health / starHealth;
        if(health <= 0)
        {
            Death();
        }
    }

    void Death()
    {

        // Giảm số lượng Enemy
        GameController.enemiesAlive--;
        WaveSpawner.count--;
        // Tạo hiệu ứng bị hủy của Object
        GameObject effect = Instantiate(deathEffect, transform.position, transform.rotation);
        GameController.enemyTotal += 1;
        // Xóa object và hiệu ứng của object

        Destroy(effect, 1f);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {        
        if (collision.GetComponent<PlayerController>() != null)
        {
            collision.GetComponent<PlayerController>().TakeDame(dame);
        }
        
    }

}
