using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compass : MonoBehaviour
{
    public GameObject objTestArea;
    public GameObject objBackground;
    public GameObject objJoystick;
    public Vector3 v3JoystickDirection;
    public float JoystickMaxDeltaDistance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        JoystickFollowingInput();
        if (Input.GetMouseButtonUp(0))
        {
            if (Tools.IfInNamedUI("JoystickImg"))
            {
                objJoystick.transform.localPosition = Vector3.zero;
                objTestArea.SetActive(true);
                gameObject.SetActive(false);
            }
        }
    }

    private void JoystickFollowingInput()
    {
        objJoystick.transform.position = Input.mousePosition;
        v3JoystickDirection = Vector3.Normalize(objJoystick.transform.position - objBackground.transform.position);
        if (Vector2.Distance(objBackground.transform.position, objJoystick.transform.position) > JoystickMaxDeltaDistance)
        {
            objJoystick.transform.position = objBackground.transform.position + v3JoystickDirection * JoystickMaxDeltaDistance;
        }
    }
}
