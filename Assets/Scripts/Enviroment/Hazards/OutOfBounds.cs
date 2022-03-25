using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBounds : MonoBehaviour
{
    TutorialManager _tutorialManager;
    private void Start()
    {
        _tutorialManager = GameObject.Find("UIManager").GetComponent<TutorialManager>();
        if (_tutorialManager == null) { Debug.LogError("TutorialManager is NULL in OUT OF BOUNDS SCRIPT"); }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            player.OutOfBounds();
            if (player.GetOutOfBoundsTutorial() == false)
            {
                player.SetTutorialLevel(true);
                _tutorialManager.InitializeOutOfBoundsTutorial();

            }
        }
    }



}
