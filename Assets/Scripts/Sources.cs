using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sources : MonoBehaviour
{
    private string sources =
@"Starry Background: https://opengameart.org/content/starfield-background
Second layer of background: https://opengameart.org/content/3-layer-parallax-star-and-nebula-field
Tile Set: https://opengameart.org/content/platformer-art-deluxe
Astronaut sprite: https://opengameart.org/content/astronaut-2
Font : https://www.dafont.com/nasalization.font";

    void Start()
    {
        GameManager.Instance.ShowMenuText(sources);
    }
}
