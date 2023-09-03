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
#if UNITY_EDITOR
        if (Input.GetMouseButtonUp(0))
        {
            if (Tools.IfInNamedUI("JoystickImg"))
            {
                objJoystick.transform.localPosition = Vector3.zero;
                objTestArea.SetActive(true);
                gameObject.SetActive(false);
            }
        }
#elif UNITY_ANDROID
        {
            if (AndroidTouchesManager.touchesInformation.Count == 1)
            {
                if (Input.touches[0].phase == TouchPhase.Ended)
                {
                    objJoystick.transform.localPosition = Vector3.zero;
                    objTestArea.SetActive(true);
                    gameObject.SetActive(false);
                }
            }
            else if (AndroidTouchesManager.touchesInformation.Count == 2)
            {
                if (AndroidTouchesManager.touchesInformation[0].fingerId == Input.touches[0].fingerId)
                {
                    if (Input.touches[0].phase == TouchPhase.Ended)
                    {
                        objJoystick.transform.localPosition = Vector3.zero;
                        objTestArea.SetActive(true);
                        gameObject.SetActive(false);
                    }
                }
                else
                {
                    if (Input.touches[1].phase == TouchPhase.Ended)
                    {
                        objJoystick.transform.localPosition = Vector3.zero;
                        objTestArea.SetActive(true);
                        gameObject.SetActive(false);
                    }
                }
            }
        }
#endif
    }

    private void JoystickFollowingInput()
    {
        objJoystick.transform.position = Input.mousePosition;
        v3JoystickDirection = Vector3.Normalize(objJoystick.transform.position - objBackground.transform.position);
        if (Vector2.Distance(objBackground.transform.position, objJoystick.transform.position) > JoystickMaxDeltaDistance)
        {
            objJoystick.transform.position = objBackground.transform.position + v3JoystickDirection * JoystickMaxDeltaDistance;
        }
        
        MovemontController.V3TargetDirection = new Vector3(v3JoystickDirection.x, v3JoystickDirection.z, v3JoystickDirection.y);
    }
}
