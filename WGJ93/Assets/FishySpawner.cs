using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class FishySpawner : MonoBehaviour
{

    public GameObject fishyPrefab;
    public AnimationCurve curve;
    public Waveyness waveScript;

    public float spawnMultiplier;


    void Update()
    {
        
    }

    void SpawnWave(GameObject waveGo)
    {
        var spawnAmount = Math.Ceiling(curve.Evaluate(waveScript.depth / (float) waveScript.maxDepth) * spawnMultiplier);
        Debug.Log("New wave: " + spawnAmount);
        for (int i = 0; i < spawnAmount; i++)
        {
            var newFishy = Instantiate(fishyPrefab);
            newFishy.transform.parent = waveGo.transform;
            var positionOffset = new Vector3(Random.Range(-6.5f, 6.5f), Random.Range(-5, 4), 0);
            newFishy.transform.position = waveGo.transform.position + positionOffset;
            var scaleFactor = Random.Range(.5f, 3);
            newFishy.transform.localScale = new Vector3(scaleFactor, scaleFactor, 1);
            newFishy.transform.name = $"{waveScript.depth} : {i+1}/{spawnAmount}";

        }
    }
}
