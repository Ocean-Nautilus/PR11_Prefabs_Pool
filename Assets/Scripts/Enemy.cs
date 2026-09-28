
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 2f;     
    public float lifetime = 5f;    
    private float lifeTimer;    
    private SpriteRenderer spriteRenderer;

    void Awake()
    {

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void OnEnable()
    {

        lifeTimer = lifetime;

        transform.localScale = Vector3.one;
    }

    void Update()
    {

        transform.Translate(Vector3.down * speed * Time.deltaTime);


        lifeTimer -= Time.deltaTime;

        if (lifeTimer <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.SetActive(false);
            ScoreManager.Instance.AddScore(1);
            Debug.Log("Враг поймал!");
        }
    }
}