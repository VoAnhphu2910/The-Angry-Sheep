using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tornado : MonoBehaviour
{
    public float speed;

    void Start()
    {
        Destroy(this.gameObject, 5);
        speed = PlayerController.speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Nếu chạm vào Enemy
        if (collision.tag == "Player")
        {
            PlayerController.speed = PlayerController.speed * 0.6f;
            StartCoroutine(DefaultSpeed());
            Destroy(gameObject, 5.5f);
            this.enabled = false;
        }
    }

    IEnumerator DefaultSpeed()
    {
        yield return new WaitForSeconds(3f);
        PlayerController.speed = speed;
    }
}
