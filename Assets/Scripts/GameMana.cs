using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMana : MonoBehaviour
{
    public int castlesDestroyed = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (castlesDestroyed == 3)
        {
            SceneManager.GoToYouWin();
        }
    }
}
