using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObstacleSpawner : MonoBehaviour
{
    public AnimationCurve spawnCurve;

    public GameObject fishyPrefab;
    public Waveyness waveScript;
    public float spawnMultiplier;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    void SpawnWave(GameObject waveGo)
    {
        var spawnAmount = Math.Ceiling(spawnCurve.Evaluate(waveScript.depth / (float)waveScript.maxDepth) * spawnMultiplier);
        Debug.Log("New wave: " + spawnAmount);
        for (int i = 0; i < spawnAmount; i++)
        {
            var newFishy = Instantiate(fishyPrefab);
            newFishy.transform.parent = waveGo.transform;
            var positionOffset = new Vector3(Random.Range(-6.5f, 6.5f), Random.Range(-5, 4), 0);
            newFishy.transform.position = waveGo.transform.position + positionOffset;
            var scaleFactor = Random.Range(3, 6);
            newFishy.transform.localScale = new Vector3(scaleFactor, 2.4f, 1);
            newFishy.transform.name = $"{waveScript.depth} : {i + 1}/{spawnAmount}";

        }
    }
}

