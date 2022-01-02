using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePoint;

    private float timeShoot ;

    public float timeBetweenShot;

    public GameController gameController;

    AudioSource audioSource;

    public static int count;

    public GameObject pause;

    private void Start()
    {
        count = 1;
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameController.endGame || pause.activeSelf || gameController.winGame)
        {
            return;
        }

        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;  // Lấy vector giữa tọa độ chuột và vũ khí
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;   // Lấy góc tan giữa X và Y của tọa độ chuột
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ); // Xoay vũ khí theo góc vừa lấy

        if(timeShoot <= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                audioSource.Play();
                StartCoroutine(Attack());
                timeShoot = timeBetweenShot;
            }
        }
        else
        {
            timeShoot -= Time.deltaTime;
        }
    }

    IEnumerator Attack()
    {
        for (int i = 0; i < count; i++)
        {
            Instantiate(bullet, firePoint.position, transform.rotation);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
