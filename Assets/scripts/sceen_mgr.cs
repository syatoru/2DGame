using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sceen_mgr : MonoBehaviour
{
    private bool firstPush = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PressStart()
    {
        Debug.Log("Press Start!");
        if (!firstPush)
        {
            Debug.Log("Go Next Scene!");
            //‚±‚±‚ÉŸ‚ÌƒV[ƒ“‚Ö‚¢‚­–½—ß‚ğ‘‚­

            //
            firstPush = true;
        }
    }
}
