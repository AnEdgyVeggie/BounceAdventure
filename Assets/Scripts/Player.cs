using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float _playerSpeed = 8.5f;
    int _lives = 5, _coins = 0;
    int _tutorialCounter = 0;

    private Vector3 _velocity;
    private Vector3 _startPosition = new Vector3(-5, 0, 0);

    private bool _canMove = true;
    private bool _isGameOver = false;
    private bool _canBounce = true;
    private bool _tutorialLevel = false;
    private bool _doneOutOfBoundsTutorial = true;
    
    private float _gravity = -1.4f;
    private float _initialBounceVelocity = 0.4f;

    private UIManager _uiManager;
    private CharacterController _char;
    private MeshRenderer _meshRend;

    // Start is called before the first frame update
    void Start()
    {
        _char = GetComponent<CharacterController>();
        if (_char == null)
        { Debug.LogError("CHARACTER CONTROLLER is NULL in player script"); }

        _meshRend = GetComponent<MeshRenderer>();

        _uiManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        if (_uiManager == null)
        { Debug.LogError("UIMANAGER is NULL in Player script"); }
        
        SetStartingPoint(_startPosition);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CalculateMovement();
        HandleGravity();
        if (_tutorialLevel)
        {
            _canMove = false;
        }
    }

    void HandleGravity()
    {
        _velocity.y += _gravity * Time.deltaTime;
    }

    void CalculateMovement()
    {
        if (!_isGameOver && _canMove)
        {


            float horizontalMove = Input.GetAxis("Horizontal");
            float direction = horizontalMove * _playerSpeed * Time.deltaTime;
            _velocity.x = direction;

            if (_char.isGrounded && _canBounce)
            {
                _velocity.y = _initialBounceVelocity;
            }

            if (transform.position.x <= -16)
            {
                if (horizontalMove < 0)
                {
                    _velocity.x = 0;
                }
            }
            _char.Move(_velocity);
        }
    }

   public void OutOfBounds()
    {
        StartCoroutine(RespawnCoroutine());
        DecrementLives();
    }

    IEnumerator RespawnCoroutine()
    {
        _canMove = false;
        transform.position = _startPosition;
        yield return new WaitForSeconds(0.1f);
        _canMove = true;
    }

    void DecrementLives()
    {
        _lives--;
        _uiManager.ManageLives(_lives);
        if (_lives == 0)
            TriggerGameOver();
    }

    void IncrementLives()
    {
        _lives++;
        _uiManager.ManageLives(_lives);
    }

    public void AddCoin()
    {
        _coins++;
        _uiManager.ManageCoins(_coins);
        if (_coins == 3)
        {
            IncrementLives();
        }
    }

    public void SetStartingPoint(Vector3 checkpoint)
    {
        _startPosition = checkpoint;
    }

    void TriggerGameOver()
    {
        _uiManager.GameOver();
        _meshRend.enabled = false;
        _isGameOver = true;
    } 

    public void GroundPlayer(bool grounded)
    {
        if (grounded == true) 
        {
            _canBounce = false;
        }
        else if (grounded == false)
        {
            _canBounce = true;
        }
    }

    public void Teleport(Vector3 location)
    {
        StartCoroutine(TeleportRoutine(location));
    }
    IEnumerator TeleportRoutine(Vector3 location)
    {
        _canMove = false;
        transform.position = location;
        yield return new WaitForSeconds(0.1f);
        _canMove = true;
    }

    public void SetCanMove(bool move) { _canMove = move; }
    public void SetCanBounce(bool bounce) { _canBounce = bounce; }
    public void IncrementTutorialCounter() { _tutorialCounter++; }
    public int GetTutorialCounter() { return _tutorialCounter; }
    public void SetTutorialLevel(bool setLevel) { _tutorialLevel = setLevel; }
    public bool GetTutorialLevel() { return _tutorialLevel; }
    public bool GetGameOver() { return _isGameOver; }
    public void SetOutOfBoundsTutorial(bool set) { _doneOutOfBoundsTutorial = set; }
    public bool GetOutOfBoundsTutorial() { return _doneOutOfBoundsTutorial; }
}
