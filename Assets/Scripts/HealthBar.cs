using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class HealthBar : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject HeatlhBar;
    public GameObject HeatlhBarFiller;
    public GameObject HeatlhBarText;

    private float maximum = 50f;
    private float current = 50f;
    private bool showText=true;

    private float baseFillerScale=1f;
    private TextMeshProUGUI  text;

 
    public float Maximum
    {
        set 
        {
            if ((int)maximum != (int)value)
            {
                maximum = value;
                fillerResize();
            }
        }
        get { return maximum; }
    }
    public float Current
    {
        set 
        {
            if ((int)current != (int)value)
            {
                current = value;
                fillerResize();
            }
        }
        get { return current; }
    }
    private bool ShowText
    {
        set { 
            showText = value;
            if (showText)
                HeatlhBarText.SetActive(true);
            else
                HeatlhBarText.SetActive(false);
        }
        get { return showText; }
    }


    private void Start()
    {
        text = HeatlhBarText.GetComponent<TextMeshProUGUI>();
        fillerResize();
    }
    private void fillerResize()
    {
        float scale = current / maximum;
        HeatlhBarFiller.transform.localScale = new Vector3(Mathf.Max(baseFillerScale * scale, 0f) , HeatlhBarFiller.transform.localScale.y, HeatlhBarFiller.transform.localScale.z);
        if (text!=null) 
            text.text = Mathf.Max ( (int)current, 0 ).ToString() + "/" + ((int)maximum).ToString();
    }
}
