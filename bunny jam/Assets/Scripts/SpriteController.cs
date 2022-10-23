using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteController : MonoBehaviour
{
    BoxCollider2D bc;
    SpriteRenderer sr;
    PlayerMovement pm;
    bool inSludge = false;

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
            // increase box collider size
        }
        else if (timeInSludge > initialThreshold)
        {
            sr.sprite = secondSprite;
            pm.jumpingPower = secondJumpingPower;
            // increase box collider size
        }
        else if (timeInSludge > lossThreshold)
        {
            // to do
            Debug.Log("you lost");
        }
    }
}
