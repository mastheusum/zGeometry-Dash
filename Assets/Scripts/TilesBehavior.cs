using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilesBehavior : MonoBehaviour
{
    public GameManager gm;

    private Tilemap tilemap;

    private float deltaTime;
    private float maxDeltaTime = 5;
    // Start is called before the first frame update
    void Start()
    {
        tilemap = GetComponent<Tilemap>();
        deltaTime = maxDeltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        deltaTime -= Time.deltaTime;
        if (deltaTime <= 0)
        {
            deltaTime = maxDeltaTime;
            tilemap.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f)); ;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "HurtBox")
        {
            collision.GetComponentInParent<PlataformBehavior>().die = true;
        }
    }
}
