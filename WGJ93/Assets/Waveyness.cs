using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Waveyness : MonoBehaviour
{
    public float speed;
    public List<GameObject> waveyGos = new List<GameObject>();

    public GameObject wavePrefab;

    public int depth = 0;
    public int maxDepth = 20;
    public Gradient grd;

    // Start is called before the first frame update
    void Start()
    {
        waveyGos.Add(AddWave());
    }

    // Update is called once per frame
    void Update()
    {
        var waves = waveyGos.ToList();
        for (var index = 0; index < waves.Count; index++)
        {
            var waveyGo = waves[index];
            waveyGo.transform.position = waveyGo.transform.position + new Vector3(0, speed, 0);
            if (waveyGo.transform.position.y >= 8.9)
            {
                waveyGos.Remove(waveyGo);
                Destroy(waveyGo);


            }

            if (Math.Abs(waveyGo.transform.position.y - (-2.5)) < .001)
            {
                var addWave = AddWave();
                waveyGos.Add(addWave);
                SendMessage("SpawnWave", addWave);
            }
        }
    }

    GameObject AddWave()
    {
        var instantiate = Instantiate(wavePrefab);
        instantiate.transform.position = new Vector3(0, -7, 0);
        instantiate.transform.parent = transform;
        instantiate.GetComponent<SpriteRenderer>().color = grd.Evaluate(depth / (float)maxDepth);
        instantiate.transform.name = $"{depth}";
        depth++;
        return instantiate;
    }
}
