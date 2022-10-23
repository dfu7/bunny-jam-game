using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SludgeCollider : MonoBehaviour
{
    SpriteController playerSpriteController;
    bool inSludge = false;

    // Start is called before the first frame update
    void Start()
    {
        playerSpriteController = GameObject.FindGameObjectWithTag("Player").GetComponent<SpriteController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inSludge)
        {
            playerSpriteController.timeInSludge += Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        inSludge = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inSludge = false;
    }
}
