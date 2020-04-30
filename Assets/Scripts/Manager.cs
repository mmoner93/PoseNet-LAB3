using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public GameObject sphere;
    public GameObject wr;
    public GameObject wl;
    public Text CountText;
    public static Manager instance;
    int counter = 0;
    float d = 0;
    Color colorStart = Color.white;
    Color colorAlpha = Color.red;
    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        d = distance();
        var cubeRenderer = sphere.GetComponent<Renderer>();
        float lerp = mapValue(d, 0, 600, 0f, 1f);
        //Call SetColor using the shader property name "_Color" and setting the color to red
        cubeRenderer.material.color = Color.Lerp(colorStart, colorAlpha, lerp);
        if (counter == 8) {
            
            sphere.transform.localScale = new Vector3(d,d,d);
            //Get the Renderer component from the new cube
            float h = heigh();
            lerp = mapValue(h, 0, 600, 0f, 1f);
            //Call SetColor using the shader property name "_Color" and setting the color to red
            cubeRenderer.material.color = Color.Lerp(colorStart, colorAlpha, lerp);
        }
    }
    float mapValue(float mainValue, float inValueMin, float inValueMax, float outValueMin, float outValueMax)
    {
        return (mainValue - inValueMin) * (outValueMax - outValueMin) / (inValueMax - inValueMin) + outValueMin;
    }
    float distance() {
        Vector3 poswr = wr.transform.position;
        Vector3 poswl = wl.transform.position;

        return Vector3.Distance(poswr, poswl);
    }
    float heigh()
    {
        float poswr = wr.transform.position.y;
        float poswl = wl.transform.position.y;
        float mh = (poswl + poswr) / 2;
        Vector2 aux1 = new Vector2(0, mh);
        Vector2 aux2 = new Vector2(0, 100);
        return Vector2.Distance(aux1, aux2);
    }

    public void colision() {
        counter++;
    }

    public void update_numcolisions() {
        if (counter == 8)
        {
            CountText.text = "Count: Colection complete";
        }
        else {
            CountText.text = "Count: " + counter.ToString();
        }
        
    }
}
