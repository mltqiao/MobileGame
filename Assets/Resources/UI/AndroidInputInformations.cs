using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndroidInputInformations : MonoBehaviour
{
    public static List<LastFrameInputInformation> LastFrameInputInformations = new List<LastFrameInputInformation>();
    public bool haveChanged;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateAndroidInputInformations();
    }

    public struct LastFrameInputInformation
    {
        public int Num;
    }

    private void UpdateAndroidInputInformations()
    {
        switch (Input.touchCount)
        {
            // 零个手指
            case 0:
                if (!haveChanged)
                {
                    if (LastFrameInputInformations.Count == 2)
                    {
                        LastFrameInputInformations.RemoveAt(1);
                        LastFrameInputInformations.RemoveAt(0);
                    }
                    else if (LastFrameInputInformations.Count == 1)
                    {
                        LastFrameInputInformations.RemoveAt(0);
                    }
                    haveChanged = !haveChanged;
                }
                break;
            // 一个手指
            case 1:
                if (!haveChanged)
                {
                    if (LastFrameInputInformations.Count == 0)
                    {
                        LastFrameInputInformations.Add(0);
                    }
                    else if (LastFrameInputInformations.Count == 2)
                    {
                        LastFrameInputInformations.RemoveAt(0);
                    }
                    haveChanged = !haveChanged;
                }
                break;
            // 两个手指
            case 2:
                if (!haveChanged)
                {
                    haveChanged = !haveChanged;
                }
                break;
        }
    }
}
