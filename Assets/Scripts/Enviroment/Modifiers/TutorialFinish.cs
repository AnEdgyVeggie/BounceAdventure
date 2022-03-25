using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialFinish : Finish
{
    private TutorialManager _tutorialManager;

    // Start is called before the first frame update
    void Start()
    {
        _tutorialManager = GameObject.Find("UIManager").GetComponent<TutorialManager>();
        if (_tutorialManager == null)
        {
            Debug.Log("TutorialManager is NULL in TutorialFinish Script");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            player.SetCanMove(false);
            _tutorialManager.TutorialComplete();
        }
    }


}
