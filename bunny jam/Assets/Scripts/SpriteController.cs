using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteController : MonoBehaviour
{
    SpriteRenderer sr;
    bool inSludge = false;

    public Sprite initialSprite;
    public Sprite secondSprite;
    public Sprite lastSprite;

    public float timeInSludge = 0f;

    public float initialThreshold = 4f;
    public float secondThreshold = 8f;
    public float lossThreshold = 12f;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = initialSprite;

        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
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
        }
        else if (timeInSludge > initialThreshold)
        {
            sr.sprite = secondSprite;
        }
        else if (timeInSludge > lossThreshold)
        {
            // to do
            Debug.Log("you lost");
        }
    }
}
