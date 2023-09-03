using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndroidTouchesManager : MonoBehaviour
{
    private int _touchesCount;
    public static Touch touchLeft;
    public static Touch touchRight;
    public struct TouchesInformation
    {
        public int fingerId;
        public int leftOrRight;
    }
    public static List<TouchesInformation> touchesInformation = new List<TouchesInformation>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_ANDROID
        if (Input.touchCount != _touchesCount)
        {
            if (Input.touchCount == 0)
            {
                touchesInformation.RemoveAt(0);
                touchesInformation.RemoveAt(1);
                _touchesCount = 0;
            }
            if (Input.touchCount == 1)
            {
                touchLeft = Input.touches[0];
                TouchesInformation touchLeftInfo = new TouchesInformation();
                {
                    touchLeftInfo.fingerId = touchLeft.fingerId;
                    touchLeftInfo.leftOrRight = 0;
                }
                touchesInformation[0] = touchLeftInfo;
                touchesInformation.RemoveAt(1);
                _touchesCount = 1;
            }
            if (Input.touchCount == 2)
            {
                if (Input.touches[0].position.x <= Input.touches[1].position.x)
                {
                    touchLeft = Input.touches[0];
                    touchRight = Input.touches[1];
                }
                else
                {
                    touchLeft = Input.touches[1];
                    touchRight = Input.touches[0];
                }
            
                TouchesInformation touchLeftInfo = new TouchesInformation();
                {
                    touchLeftInfo.fingerId = touchLeft.fingerId;
                    touchLeftInfo.leftOrRight = 0;
                }
                TouchesInformation touchRightInfo = new TouchesInformation();
                {
                    touchRightInfo.fingerId = touchRight.fingerId;
                    touchRightInfo.leftOrRight = 0;
                }
                touchesInformation[0] = touchLeftInfo;
                touchesInformation[1] = touchRightInfo;
                _touchesCount = 2;
            }
        }
        Debug.Log(touchesInformation.Count);
#endif
    }
}
