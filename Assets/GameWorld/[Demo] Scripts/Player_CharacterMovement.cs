using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class character_Movement : MonoBehaviour
{
    private float horizontal;
    private float vertical;
    public float speed;

    private bool isMoving;

    private Vector3 direction;

    public Animator animator;

    //get input from player
    //apply movement to sprite
    private void Update()
    {
        if (!isMoving)
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            vertical = Input.GetAxisRaw("Vertical");

            direction = new Vector3(horizontal, vertical, 0);

            animateMovement(direction);

        }
    }

    private void FixedUpdate()
    {
        this.transform.position += direction.normalized * speed * Time.deltaTime;
        /*if (!isMoving)
        {
            var targetPosition = transform.position;
            targetPosition.x += direction.x;
            targetPosition.y += direction.y;

            StartCoroutine(Move(targetPosition));
        }*/
    }

    void animateMovement(Vector3 direction)
    {
        if (animator != null)
        {
            if (direction.magnitude > 0)
            {
                animator.SetBool("isMoving", true);

                animator.SetFloat("horizontal", direction.x);
                animator.SetFloat("vertical", direction.y);
            }
            else
            {
                animator.SetBool("isMoving", false);
            }
        }
    }


    /*IEnumerator Move(Vector3 targetPosition)
    {
        isMoving = true;
        while ((targetPosition - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPosition;
        isMoving = false;
    }*/
}