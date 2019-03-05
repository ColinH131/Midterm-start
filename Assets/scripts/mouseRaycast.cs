using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseRaycast : MonoBehaviour
{
    public float cameraRayDistance = 40f;

    public Transform paintcube;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(mouseRay.origin, (mouseRay.direction * cameraRayDistance), Color.red);
        RaycastHit myHit;
        if (Physics.Raycast(mouseRay.origin, mouseRay.direction, out myHit, cameraRayDistance))
        {
            paintcube.transform.position = myHit.point
        }
       
    }
}
