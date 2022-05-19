using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextScaleChanger : MonoBehaviour
{
    RectTransform textScale;
    bool isBig = true;

    public float minSize = 1;
    public float maxSize = 1.1f;
    public float rate = 0.25f;
    float time = 0;

    // Start is called before the first frame update
    void Start()
    {
        textScale = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isBig)
        {
            if(time < 1)
            {
                textScale.localScale = Vector3.Lerp(new Vector3(minSize, minSize, minSize), new Vector3(maxSize, maxSize, maxSize), time += Time.deltaTime * rate);
            }
            else
            {
                isBig = false;
            }
        }
        else
        {
            if (time > 0)
            {
                textScale.localScale = Vector3.Lerp(new Vector3(minSize, minSize, minSize), new Vector3(maxSize, maxSize, maxSize), time -= Time.deltaTime * rate);
            }
            else
            {
                isBig = true;
            }
        }
    }
}
