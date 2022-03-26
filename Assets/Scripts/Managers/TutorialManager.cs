using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    private Animator _anim;
    private Player _player;
    private GameManager _gm;
    private bool _tuturialPassed = true;

    // Start is called before the first frame update
    void Start()
    {
        _anim = GameObject.Find("Tutorial").GetComponent<Animator>();
        _gm = GameObject.Find("GameManager").GetComponent<GameManager>();

        _player = GameObject.Find("Player").GetComponent<Player>();
        if (_player == null) { Debug.LogError("PLAYER is NULL in TUTORIAL MANAGER script"); }
    }

    // Update is called once per frame
    void Update()
    {
        if (_player.GetTutorialCounter() == 0 && _player.GetTutorialLevel() == false)
        { 
            _player.SetTutorialLevel(true);
            TutorialInitializers();
        }
    }

    public void TutorialInitializers()
    {
        switch (_player.GetTutorialCounter())
        {
            case 0:
                StartCoroutine(FirstTutorialRoutine());
                break;
            case 1:
                StartCoroutine(GroundedTutorialRoutine());
                break;
            case 2:
                StartCoroutine(ExplorationTutorialRoutine());
                break;
            case 3:
                StartCoroutine(TeleCollectableTutorialRoutine());
                break;


            default:
                Debug.LogError("TutorialCounter beyond scope or not assigned correctly to tutorials in TUTORIAL MANAGER SCRIPT");
                break;
        }
    }

    public void TutorialComplete()
    {
        if (_tuturialPassed)
        {
            StartCoroutine(TutorialPassedRoutine());
        }
        else
        {
            StartCoroutine(TutorialCompleteRoutine());
        }
    }

    public void InitializeOutOfBoundsTutorial()
    {
        StartCoroutine(OutOfBoundsTutorialRoutine());
    }

    IEnumerator OutOfBoundsTutorialRoutine()
    {
        _anim.SetBool("FadeLives", true);
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));
        _anim.SetBool("FadeLives", false);
        yield return new WaitForSeconds(0.9f);
        _player.SetOutOfBoundsTutorial(true);
        _player.SetTutorialLevel(false);
        _player.SetCanMove(true);
        _tuturialPassed = false;
    }

    IEnumerator FirstTutorialRoutine()
    {
        _anim.SetBool("Fade", true);
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));
        _anim.SetBool("Fade", false);
        yield return new WaitForSeconds(0.8f);
        _player.SetOutOfBoundsTutorial(false);
        _player.IncrementTutorialCounter();
        _player.SetTutorialLevel(false);
        _player.SetCanMove(true);

    }
    IEnumerator GroundedTutorialRoutine()
    {
        _anim.SetBool("FadeGround1", true);
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));
        _anim.SetBool("FadeGround1", false);
        yield return new WaitForSeconds(1);
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));
        _anim.SetBool("FadeGround2", true);
        yield return new WaitForSeconds(1f);
        _anim.SetBool("FadeGround2", false);
        _player.IncrementTutorialCounter();
        _player.SetTutorialLevel(false);
        _player.SetCanMove(true);
    }
    IEnumerator ExplorationTutorialRoutine()
    {
        _anim.SetBool("FadeExploration", true);
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));
        _anim.SetBool("FadeExploration", false);
        yield return new WaitForSeconds(0.8f);
        _player.IncrementTutorialCounter();
        _player.SetTutorialLevel(false);
        _player.SetCanMove(true);
    }
    IEnumerator TeleCollectableTutorialRoutine()
    {
        _anim.SetBool("FadeTele", true);
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));
        _anim.SetBool("FadeTele", false);
        yield return new WaitForSeconds(2);
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));
        _anim.SetBool("FadeCollect", true);
        yield return new WaitForSeconds(0.9f);
        _player.IncrementTutorialCounter();
        _player.SetTutorialLevel(false);
        _player.SetCanMove(true);
    }

    IEnumerator TutorialCompleteRoutine()
    {

        _anim.SetBool("FadeFinish1", true);
        yield return new WaitForSeconds(5);
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));
        _anim.SetBool("FadeFinish1", false);
        yield return new WaitForSeconds(2.5f);
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));
        _anim.SetBool("FadeFinish2", true);
        yield return new WaitForSeconds(2.5f);
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));
        _anim.SetBool("FadeFinish2", false);
        yield return new WaitForSeconds(1);
        _anim.SetBool("FadeReturn", true);
        yield return new WaitForSeconds(2.5f);
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));
        _anim.SetBool("FadeReturn", false);
        yield return new WaitForSeconds(2);
        _gm.ReturnToMainMenu();
    }

    IEnumerator TutorialPassedRoutine()
    {
        _anim.SetBool("FadeFinish1", true);
        yield return new WaitForSeconds(5);
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));
        _anim.SetBool("FadeFinish1", false);
        yield return new WaitForSeconds(2.5f);
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));
        _anim.SetBool("FadeFinish2", true);
        yield return new WaitForSeconds(2.5f);
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));
        _anim.SetBool("FadeFinish2", false);
        yield return new WaitForSeconds(1);
        _anim.SetBool("OptionalPass", true);
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));
        _anim.SetBool("OptionalPass", false);
        _player.IncrementLives();
        yield return new WaitForSeconds(1f);
        _anim.SetBool("FadeReturn", true);
        yield return new WaitForSeconds(2.5f);
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return));
        _anim.SetBool("FadeReturn", false);
        yield return new WaitForSeconds(2);
        _gm.ReturnToMainMenu();
    }
}
