using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FishyMovement : MonoBehaviour
{
    public Sprite movementRight;
    public Sprite movementLeft;

    public static float constantSpeed = 0.01f;

    public float movementSpeed;

    public Vector3 startPosition;
    public float movementRange;


    public float targetX;

    // Start is called before the first frame update
    void Start()
    {
        
        startPosition = transform.position;
        targetX = startPosition.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y >= 5.1)
        {
            Destroy(gameObject);
        }
        if (Math.Abs(transform.position.x - targetX) < .02)
        {
            targetX = Random.Range(-movementRange, movementRange) + startPosition.x;
            if (targetX > transform.position.x)
            {
                GetComponent<SpriteRenderer>().sprite = movementRight;
            }
            else
            {
                GetComponent<SpriteRenderer>().sprite = movementLeft;

            }
        }

        var k = Vector3.Lerp(transform.position, new Vector3(targetX, transform.position.y, 0), Time.deltaTime * movementSpeed);

        k.y = transform.position.y +  constantSpeed;
        transform.position = k;

    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        var tempPos = startPosition;
        tempPos.y = transform.position.y;
        Gizmos.DrawWireSphere( tempPos, movementRange );
    }


}
