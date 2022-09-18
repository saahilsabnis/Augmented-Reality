using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlip : MonoBehaviour
{
    float xVal;
    float yVal;
    float zVal;
    bool flipped;
    bool reset;
    int mode;
    public GameObject MergeCube;
    public Light BaseLight;
    public Light AlternateLight;
    int upsideDown;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Update",0f,10f);
        zVal = 0f;
        mode = 1;
        AlternateLight.enabled = false;
        if (Vector3.Dot(MergeCube.transform.up, Vector3.down) > 0) {
            upsideDown = 1;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
        zVal = MergeCube.transform.localEulerAngles.z;
        //Debug.Log("X: "+MergeCube.transform.localEulerAngles.x+"Y: "+MergeCube.transform.localEulerAngles.y+"Z: "+MergeCube.transform.localEulerAngles.z);
        //Debug.Log("X: "+MergeCube.transform.localEulerAngles.x);
        if (Vector3.Dot(MergeCube.transform.up, Vector3.down) > 0) {
            //updateText();
            upsideDown = 1;
        }
        
        if ((Vector3.Dot(MergeCube.transform.up, Vector3.down) < 0) & upsideDown == 1){
            //updateText();
            upsideDown = 0;
            Debug.Log("Flipped");
            mode = mode*-1;
        }
        if (mode == 1)
        {
            BaseLight.enabled = true;
            AlternateLight.enabled = false;
        }
        else if (mode == -1)
        {
            BaseLight.enabled = false;
            AlternateLight.enabled = true;
        }

    }
}
