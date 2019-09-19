using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowPortal : MonoBehaviour
{
    public GameObject leftPortal;
    public GameObject rightPortal;
    Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("Left Click");
            throwPortal(leftPortal);
        }

        if (Input.GetButtonDown("Fire2"))
        {
            Debug.Log("Right Click");
            throwPortal(rightPortal);
        }
    }

    void throwPortal(GameObject portal)
    {
        int x = Screen.width / 2;
        int y = Screen.height / 2;
        Ray ray = cam.ScreenPointToRay(new Vector3 (x, y));
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit))
        {
            Quaternion hitObjectRotation = Quaternion.LookRotation(hit.normal);
            portal.transform.position = hit.point;
            portal.transform.rotation = hitObjectRotation;
        }
        

    }
}
