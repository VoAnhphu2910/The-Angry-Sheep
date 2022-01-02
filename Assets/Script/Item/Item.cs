using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Item : MonoBehaviour
{
    public int item;

    public GameObject shieldEffect;

    public int health;

    public int speed;

    private AudioSource audioSource;

    public PlayerController playerController;

    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        //playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*
        if(collision.tag == "Player")
        {
            if (playerController != null)   // Nếu có mục tiêu thì gây dame
            {
                audioSource.Play();

                if (item == 0)
                {
                    AddShield(collision.transform);
                    playerController.isDefensed = true;
                }
                else if (item == 1)
                {
                    playerController.health += health;
                }
                else if (item == 2)
                {
                    PlayerController.speed += speed;
                }
                else if (item == 3)
                {
                    Weapon.count++;
                }
                Destroy(gameObject, 0.1f);
            }
        }
        */
        playerController = collision.GetComponent<PlayerController>();
        if (playerController != null)
        {
            audioSource.Play();

            if (item == 0)
            {
                AddShield(collision.transform);
                playerController.isDefensed = true;
            }
            else if (item == 1)
            {
                playerController.health += health;
            }
            else if (item == 2)
            {
                PlayerController.speed += speed;
            }
            else if (item == 3)
            {
                Weapon.count++;
            }
            Destroy(gameObject, 0.1f);

        }
        
    }

    void AddShield(Transform trans)
    {
        GameObject shield = Instantiate(shieldEffect, trans.position, trans.rotation);
        shield.transform.parent = trans;
        Destroy(shield, 5f);
    }
}
