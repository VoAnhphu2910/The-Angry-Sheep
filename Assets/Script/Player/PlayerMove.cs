using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Vector2 limitTranform;
    
    private float speed;

    Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Tạo các điểm giới hạn biên
        if (transform.position.x > 8.5)
        {
            limitTranform.x = 8.5f;
            limitTranform.y = transform.position.y;
            transform.position = limitTranform;
        }
        else if(transform.position.x < -8.5)
        {
            limitTranform.x = -8.5f;
            limitTranform.y = transform.position.y;
            transform.position = limitTranform;
        }
        else if (transform.position.y > 4.5)
        {
            limitTranform.y = 4.5f;
            limitTranform.x = transform.position.x;
            transform.position = limitTranform;
        }
        else if (transform.position.y < -4.5)
        {
            limitTranform.y = -4.5f;
            limitTranform.x = transform.position.x;
            transform.position = limitTranform;
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        // Di chuyển object bằng bàn phím và set Animation
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            animator.SetBool("isRun", true);
            transform.Translate(Vector2.right * PlayerController.speed * Time.deltaTime);
        }
        else
        {
            animator.SetBool("isRun", false);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            animator.SetBool("isRun", true);
            transform.Translate(Vector2.left * PlayerController.speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            animator.SetBool("isRun", true);
            transform.Translate(Vector2.up * PlayerController.speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            animator.SetBool("isRun", true);
            transform.Translate(Vector2.down * PlayerController.speed * Time.deltaTime);
        }
    }
}
