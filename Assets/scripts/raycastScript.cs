using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycastScript : MonoBehaviour
{
    public float rayDistance = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray _myRay = new Ray(this.transform.position, Vector3.down);
        
        Debug.DrawRay(_myRay.origin, new Vector3(0,-rayDistance,0), Color.red);

        RaycastHit myHit;

        if (Physics.Raycast(_myRay.origin, _myRay.direction, out myHit, rayDistance))
        {
            print("raycast hit");
            transform.Rotate(0,1,0);
        }
        else
        {
            transform.Rotate(0,0,0);
        }
    }
}
