using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorials : MonoBehaviour
{
    int _tutorialCounter = 0;

    TutorialManager _tutorialManager;

    // Start is called before the first frame update
    void Start()
    {
        _tutorialManager = GameObject.Find("UIManager").GetComponent<TutorialManager>();
        if (_tutorialManager == null) { Debug.LogError("TutorialManager is NULL in Tutorial Script"); }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            if (player.ReturnTutorialCounter() == 1)
            {
                Debug.LogError("This is it");
            }
        }
    }

    public void DestroyTutorial()
    {
        Destroy(this.gameObject);
    }
}
