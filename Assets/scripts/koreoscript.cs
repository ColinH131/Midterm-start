using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SonicBloom.Koreo;

public class koreoscript : MonoBehaviour
{
  
    public Koreographer Koreographer;

    public KoreographyTrack KoreographyTrack;

    public bool _Change = false;
    public Light light;
    public float lightIntensity;
    
    // Start is called before the first frame update
    void Start()
    {
        Koreographer = GetComponent<Koreographer>();
        Koreographer.Instance.RegisterForEvents("NewKoreographyTrack", lightChange);
        light = this.gameObject.GetComponent<Light>();
    }

    public void lightChange(KoreographyEvent koreographyEvent)
    {
        _Change = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (_Change)
        {
            if (lightIntensity >= 5)
            {
                lightIntensity = .03f;
            }
            else
            {
                lightIntensity = 5;
            }
        }
    }
}
