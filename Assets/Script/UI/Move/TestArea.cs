using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TestArea : MonoBehaviour
{
    public GameObject objCompass;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Tools.IfInNamedUI("TestArea"))
            {
                objCompass.transform.position = Input.mousePosition;
                objCompass.SetActive(true);
                gameObject.SetActive(false);
            }
        }
    }
}
