using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashSheep : MonoBehaviour
{
    public int dame;
    public LineRenderer lineRenderer;
    public Transform target;
    private bool move = false;
    private int count;
    public int speed;

    PlayerController playerController;    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();

        //Diểm bắt đầu và kết thúc của đường đi
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, Target().position);

        StartCoroutine(Move());
        Vector2 dir = target.position - transform.position;   // Lấy vector giữa nhân vật và Object
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;    // Lấy góc tan giữa X và Y của vector và tạo ra hướng đi
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);  // Xoay Object về hướng mục tiêu theo vector đã tạo
    }

    // Update is called once per frame
    void Update()
    {
        if (move)
        {
            // Di chuyển Object
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            lineRenderer.SetPosition(0, transform.position);
        }

        // So sánh khoảng cách giữa Object và điểm cuối nếu nhỏ hơn thì Xóa Object
        if(Vector2.Distance(target.position, transform.position) < 0.5f)
        {
            Destroy(gameObject);
        }
    }
   
    // Sau khi Object được tạo sẽ lấy ngẫu nhiên một khoảng thời gian để Object di chuyển
    IEnumerator Move()
    {
        float time = Random.Range(3,5);
        yield return new WaitForSeconds(time);
        move = true;
    }

    Transform Target()
    {
        // Hàm sẽ lặp và random điểm để khoảng cách giữa Object và điểm cuối  phải lớn hơn 6
        while(true)
        {
            count = Random.Range(0, SpawnPoint.points.Length);
            target = SpawnPoint.points[count];
            if (Vector2.Distance(transform.position,target.position ) > 8 & (transform.position.x !=  target.position.x) && (transform.position.y != target.position.y))
            {
                break;
            }
        }
        return target;
    }

    // Chạm vào người chơi thì gây sát thương
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if(collision.tag == "Player")
        {
           playerController.TakeDame(dame);

        }
    }
}
