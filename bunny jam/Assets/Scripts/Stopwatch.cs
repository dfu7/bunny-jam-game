using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading;

public class Stopwatch : MonoBehaviour
{
    public TextMeshProUGUI stopwatch;
    float timer = 0;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        stopwatch.text = timer.ToString();
    }
}
