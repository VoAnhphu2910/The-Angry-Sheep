using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private GameObject player;

    //private Vector3 way;

    private float time = 3f;

    // Biến dùng để di chuyển nhân vật
    private bool isMove = true;

    public float speed = 5f;

    Vector3 dir;
    private float t = 3;

    public int minTime, maxTime;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(isMove)
        {
            //transform.Translate(way * 2 * Time.deltaTime);
            dir = player.transform.position - transform.position;   // Lấy vector giữa nhân vật và Object
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;    // Lấy góc tan giữa X và Y của vector và tạo ra hướng đi
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);  // Xoay Object về hướng mục tiêu theo vector đã tạo
            
            // Di chuyển Object
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
        
        // Nếu khoảng cách ban đầu giữa nhân vật và object đã xác định nhỏ hơn 1 thì không di chuyển nữa
        if (t <= 0)
        {
            t = Random.Range(3, 5);
            isMove = false;
            StartCoroutine(Move());
        }
        else
        {
            t -= Time.deltaTime;
        }
        
    }

    // Hàm gọi thực hiện sau một khoảng thời gian
    IEnumerator Move()
    {
        // Lấy thời gian ngẫu nhiên để gọi hàm
        time = Random.Range(minTime, maxTime);
        yield return new WaitForSeconds(time);
        isMove = true;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            isMove = false;
            StartCoroutine(Move());
        }
    }

}
