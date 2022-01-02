using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExploreSheep : MonoBehaviour
{
    public GameObject explosion;
    public float minTime, maxTime;
    private float time;

    public int dame;
    public float distance;

    private GameObject player;

    public GameObject effectEnemy;
    // Start is called before the first frame update
    void Start()
    {
        time = Random.Range(minTime, maxTime);
        GameObject effect = Instantiate(effectEnemy, gameObject.transform.position, Quaternion.identity);
        Destroy(effect,time);
        StartCoroutine(Effect());
        // Tìm game object thông qua tag
        player = GameObject.FindGameObjectWithTag("Player");
    }

    IEnumerator Effect()
    {
        // Sau khoảng thời gian ngẫu nhiên thì tạo ra game hiệu ứng nổ
        yield return new WaitForSeconds(time + Random.Range(2, 4));
            Explo();
    }

    void Explo()
    {
        GameObject explo = Instantiate(explosion, gameObject.transform.position, gameObject.transform.rotation);
        Destroy(gameObject);  //sau đó hủy game object và hiệu ứng

        Destroy(explo, 0.5f);

        // Nếu khoảng cách giữa player và game object nhỏ hơn tầm nổ thì gây sát thương
        if (Vector2.Distance(player.transform.position, gameObject.transform.position) <= distance)
        {
            player.GetComponent<PlayerController>().TakeDame(dame);
        }

    }
}
