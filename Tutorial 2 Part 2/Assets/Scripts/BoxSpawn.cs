using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawn : MonoBehaviour {
    public GameObject coin;
    public int amount;
    public float delay;
    public int force;
    private AudioSource source;
    public AudioClip coinClip;
    private float volLowRange = .5f;
    private float volHighRange = 1.0f;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        StartCoroutine("EjectCoins");
    }

    IEnumerator EjectCoins()
    {
        for (int i = 0; i < amount; i++)
        {
            yield return new WaitForSeconds(delay);
            int angle = Random.Range(45, 135);
            GameObject spawned = Instantiate(coin);
            Vector3 dir = Quaternion.AngleAxis(angle, Vector3.forward) * Vector3.right;
            spawned.GetComponent<Rigidbody2D>().AddForce(dir * force);
            float vol = Random.Range(volLowRange, volHighRange);
            source.PlayOneShot(coinClip);
        }
        Destroy(GetComponent<Transform>().parent.gameObject);
    }
    /** public GameObject Coin;
    public GameObject Spawn;
    public Transform playerHitBox;
    private bool playerHit;
    public float playerHitHeight;
    public float playerHitWidth;
     private AudioSource source;
    public AudioClip coinClip;
    private float volLowRange = .5f;
    private float volHighRange = 1.0f;
    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }
    private void FixedUpdate()
    {
        playerHit = Physics2D.OverlapBox(playerHitBox.position, new Vector2(playerHitWidth, playerHitHeight), 0,0);
        if (playerHit == true)
        {
            Instantiate(Coin, Spawn.transform.position, Quaternion.identity);
            float vol = Random.Range(volLowRange, volHighRange);
            source.PlayOneShot(coinClip);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       //if (GetComponent<Collider>().tag == "Player")
       // {
       //     Instantiate(Coin, Spawn.transform.position, Quaternion.identity);
        //    float vol = Random.Range(volLowRange, volHighRange);
        //    source.PlayOneShot(coinClip);
        //}

     }**/

}
