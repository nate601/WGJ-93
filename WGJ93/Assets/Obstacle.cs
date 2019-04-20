using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    public static float constantMovement = .01f;

    public float speedRemoval;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        var newPosition = transform.position + new Vector3(0, constantMovement, 0);
        transform.position = newPosition;


    }

    void OnTriggerEnter2D(Collider2D col)
    {
        col.gameObject.GetComponentInChildren<HookControl>().speed -= speedRemoval;
    }

    void OnTriggerExit2D(Collider2D col)
    {

        col.gameObject.GetComponentInChildren<HookControl>().speed += speedRemoval;
    }
}
