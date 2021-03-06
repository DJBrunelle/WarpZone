using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableController : MonoBehaviour
{
    public int multiplier;
    public Stat stat;
    public int duration;

    public float spawnTime;

    public CollectableType type;

    public GameObject timeLeft;

    float totalSpawnTime;


    void Awake()
    {
        totalSpawnTime = spawnTime;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnTime -= Time.deltaTime;
        timeLeft.transform.localScale = new Vector3((spawnTime/(float)totalSpawnTime),0.05f, 1);

        if (spawnTime <= 0)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Friendly")
        {
            col.GetComponent<PlayerController>().Powerup(multiplier, stat, duration);
            Destroy(gameObject);
        }
    }
}

public enum CollectableType{
    PowerUp,
    Pod,
    Scrap
}
