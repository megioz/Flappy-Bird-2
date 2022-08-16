using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField]
    WallType wallType = WallType.None;

    internal WallType WallType { get => wallType; private set => wallType = value; }

    // Update is called once per frame
    void Update()
    {
        if ((0f <= gameObject.transform.eulerAngles.z && gameObject.transform.eulerAngles.z < 45) ||
            gameObject.transform.eulerAngles.z >= 315f)
            WallType = WallType.Right;
        else if (45f <= gameObject.transform.eulerAngles.z && gameObject.transform.eulerAngles.z < 135)
            WallType = WallType.Top;
        else if (135f <= gameObject.transform.eulerAngles.z && gameObject.transform.eulerAngles.z < 225)
            WallType = WallType.Left;
        else if (225f <= gameObject.transform.eulerAngles.z && gameObject.transform.eulerAngles.z < 315f)
            WallType = WallType.Bottom;
    }
}

enum WallType
{
    Top,
    Bottom,
    Left,
    Right,
    None
}
