using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteController : MonoBehaviour
{
    SpriteRenderer sr;
    PlayerMovement pm;
    bool inSludge = false;

    public AudioSource AS0;
    public AudioSource AS1;
    public AudioSource AS2;

    public float fadetime = 2f;
    private Coroutine activeman;
    private bool start;
    private bool start2;

    public AudioLibrary audioLibrary;

    public Sprite initialSprite;
    public Sprite secondSprite;
    public Sprite lastSprite;

    public float timeInSludge = 0f;

    public float initialThreshold = 4f;
    public float secondThreshold = 8f;
    public float lossThreshold = 12f;

    public float initialJumpingPower = 20f;
    public float secondJumpingPower = 25f;
    public float lastJumpingPower = 33f;

    public float secondBoxColliderSize = 0f;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = initialSprite;

        pm = GetComponent<PlayerMovement>();

        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;

        audioLibrary.MStage0Play(AS0);
        audioLibrary.MStage1Play(AS1);
        audioLibrary.MStage2Play(AS2);

        AS1.volume = 0f;
        AS2.volume = 0f;
        start = true;
        start2 = true;
    }

    // Update is called once per frame
    void Update()
    {
        checkSludge();

        if (inSludge)
        {
            timeInSludge += Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "sludge")
        {
            inSludge = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "sludge")
        {
            inSludge = false;
        }
    }

    void checkSludge()
    {
        if (timeInSludge > secondThreshold)
        {
            sr.sprite = lastSprite;
            pm.jumpingPower = lastJumpingPower;
            if (start)
            {
                StartCoroutine(FadeIn());
                start = false;
            }
        }
        else if (timeInSludge > initialThreshold)
        {
            sr.sprite = secondSprite;
            pm.jumpingPower = secondJumpingPower;
            if (start2)
            { 
                StartCoroutine(FadeIn2());
                start2 = false;
            }
            
        }
        else if (timeInSludge > lossThreshold)
        {
            // to do
            Debug.Log("you lost");
        }
    }

    IEnumerator FadeIn()
    {
        float timepassed = 0f;
        while(timepassed < fadetime)
        {
            AS2.volume = Mathf.Lerp(0, 0.5f, timepassed / fadetime);
            timepassed += Time.deltaTime;
            yield return null;
        }
        AS2.volume = 0.5f;
        }

    IEnumerator FadeIn2()
    {
        float timepassed = 0f;
        while (timepassed < fadetime)
        {
            AS1.volume = Mathf.Lerp(0, 0.7f, timepassed / fadetime);
            timepassed += Time.deltaTime;
            yield return null;
        }
        AS1.volume = 0.7f;
    }
}
