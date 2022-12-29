using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject HeatlhBar;
    public GameObject HeatlhBarFiller;
    [SerializeField]
    private float maximum = 50f;
    [SerializeField]
    private float current = 50f;

    private float baseFillerScale;
    public bool ShowText;

    private void Start()
    {
        baseFillerScale=HeatlhBarFiller.transform.localScale.x;
    }
    public float Maximum
    {
        set 
        { 
            maximum = value;
            fillerResize();
        }
        get { return maximum; }
    }
    public float Current
    {
        set 
        { 
            current = value;
            fillerResize();
        }
        get { return current; }
    }
    private void fillerResize()
    {
        float scale = current / maximum;
        HeatlhBarFiller.transform.localScale = new Vector3(baseFillerScale * scale, HeatlhBarFiller.transform.localScale.y, HeatlhBarFiller.transform.localScale.z);
    }
}
