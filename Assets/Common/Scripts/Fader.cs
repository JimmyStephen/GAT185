using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fader : MonoBehaviour
{
    Material material;
    float alpha;

    void Start()
    {
        material = GetComponent<Renderer>().material;
        //not needed but will set the alpha to 0 regardless of the original alpha
        var color = material.color;
        color.a = 0;

        alpha = 0;

        StartCoroutine(FadeInRoutine());
        //StartCoroutine(Timer(2));
        //StartCoroutine(UpdateAI(0.1f));
    }

    void Update()
    {
    }

    void FadeIn()
    {
        //deltatime / how long
        alpha += (Time.deltaTime / 5);
        alpha = Mathf.Min(alpha, 1);
        Color color = material.color;
        color.a = alpha;
        material.color = color;
    }

    IEnumerator FadeInRoutine()
    {
        while(alpha < 1)
        {
            //deltatime / how long
            alpha += (Time.deltaTime / 5);
            alpha = Mathf.Min(alpha, 1);
            Color color = material.color;
            color.a = alpha;
            material.color = color;

            yield return null;
        }
    }

    IEnumerator Timer(float time)
    {
        print("Hello");
        yield return new WaitForSeconds(time);
        print("World");
        yield return new WaitForSeconds(time);
        print("Goodbye");
        yield return new WaitForSeconds(time);
    }

    IEnumerator UpdateAI(float time)
    {
        //for (; ; ) { }//infinate loop ^.^
        while (true)
        {
            print("Thinking.....");
            yield return new WaitForSeconds(time);
        }
    }
}
