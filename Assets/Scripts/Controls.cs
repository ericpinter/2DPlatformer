using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controls : MonoBehaviour
{
    private string controls =
@"You're a part of the cleanup crew designated to remove all of the space trash on the path up to the moon.
Use A to move left, D to move right. Press the space bar to jump and hold it to use your jetpack.";

    void Start()
    {
        GameManager.Instance.ShowMenuText(controls);
    }
}
