using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private GameObject player;

    public GameObject effectDestroy;

    public int dame = 50;
    public int speed = 20;

    // Start is called before the first frame update
    void Start()
    {
        // Tìm Object thông qua tag
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // Di chuyển object
        transform.Translate(Vector2.right * speed * Time.deltaTime);

        // Nếu Object đi quá khoảng cách sẽ xóa
        if(Vector3.Distance(transform.position, player.transform.position) > 12)
        {
            Destroy();
        }
    }

    void Destroy()
    {
        // Tạo hiểu ứng hủy và xóa hiệu ứng cufgn object
        GameObject effect = Instantiate(effectDestroy, transform.position, transform.rotation);
        Destroy(gameObject);
        Destroy(effect, 0.2f);
    }

    void Dame(Transform enemy)    // Truyền vào mục tiêu
    {
        // Lấy class tại vị trí mà đạn chạm vào và lấy dame
        EnemyController e = enemy.GetComponent<EnemyController>();

        // Nếu trường hợp chạm phải mà có class thì gây dame
        if (e != null)   // Nếu có mục tiêu thì gây dame
        {
            e.TakeDame(dame);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Nếu chạm vào Enemy
        if (collision.tag == "Sheep")
        {
            // Gây sát thương tại Enemy chạm vào
            Dame(collision.transform);
            // Xóa đạn
            Destroy();
        }
    }
}
