using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class FishyCapture : MonoBehaviour
{

    public static float captureMultiplier = 1;


    public float captureTimer;
    public float captureTimeMax;

    public Gradient grd;

    public SpriteRenderer fishCaptureCircle;

    public bool isBeingCaptured;
    // Start is called before the first frame update
    void Start()
    {
        captureTimeMax = Random.Range(1, 3) * transform.localScale.x;
        captureTimer = captureTimeMax;
    }

    // Update is called once per frame
    void Update()
    {
        if (Math.Abs(captureTimer - captureTimeMax) > .05 && !isBeingCaptured)
        {
            captureTimer += Time.deltaTime * 2;
        }

        fishCaptureCircle.color = grd.Evaluate(captureTimer/captureTimeMax);


    }

    void OnTriggerEnter2D(Collider2D col)
    {
        isBeingCaptured = true;
    }

    void OnTriggerStay2D(Collider2D col)
    {
        captureTimer -= Time.deltaTime * captureMultiplier;

        if (!(captureTimer <= 0)) return;

        Debug.Log("Capture complete");
        Scoring.instance.UpdateScore((int)Math.Ceiling(transform.localScale.x));
        Destroy(gameObject);

    }

    void OnTriggerExit2D(Collider2D col)
    {
        isBeingCaptured = false;
    }
}
