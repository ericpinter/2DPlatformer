using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    private string controls =
@"Use A to move left, D to move right, and the space bar to jump.";

    void Start()
    {
        GameManager.Instance.ShowMenuText(controls);
    }
}
