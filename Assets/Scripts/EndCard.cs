using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCard : MonoBehaviour
{
    private string text =
@"Great job on the flag cleanup! Your skill for cleaning up behind space-miscreants is unparalleled.
The only problem is that the last flag you found turned out to be a really old historical piece or something. 
Supposedly it's 'priceless'. So yeah. You're fired.";

    void Start()
    {
        GameManager.Instance.ShowMenuText(text);
        GameManager.Instance.EndScreen();
    }
}
