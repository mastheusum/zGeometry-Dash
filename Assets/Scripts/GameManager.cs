using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Color spikesColor;
    public float deltaTime = 5;

    public float maxDeltaTime = 5;
    // Start is called before the first frame update
    void Start()
    {
        spikesColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
    }

    // Update is called once per frame
    void Update()
    {
        deltaTime -= Time.deltaTime;
        if (deltaTime <= 0.5)
        {
            deltaTime = maxDeltaTime;
            spikesColor = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        }
    }
}
