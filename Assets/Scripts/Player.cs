using UnityEngine;
//we are writing scripts for flappy bird game
public class Player : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    private int currentSpriteIndex;

    private Vector3 direction;
    public float gravity=-9.81f;
    public float strength = 5f;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    private void Start()
    {
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f);
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            direction = strength*Vector3.up;
        }
        if(Input.touchCount>0)
        {
            Touch touch = Input.GetTouch(0);
            if(touch.phase == TouchPhase.Began)
            {
                direction = strength*Vector3.up;
            }
        }

        direction.y += gravity*Time.deltaTime;
        transform.position += direction*Time.deltaTime;
    }

    private void AnimateSprite()
    {
        currentSpriteIndex++;
        if(currentSpriteIndex>=sprites.Length)
        {
            currentSpriteIndex = 0;
        }
        spriteRenderer.sprite = sprites[currentSpriteIndex];
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Obstacle")
        {
            FindObjectOfType<GameManager>().GameOver();
        }else if(other.gameObject.tag == "Scoring")
        {
            FindObjectOfType<GameManager>().IncrementScore();
        }
    }
}
