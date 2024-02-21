using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cue : MonoBehaviour
{
    public Hole hole;


    [SerializeField] private Transform orbitAround;
    [SerializeField] private BallsState ballsState;
    [SerializeField] private float defaultOrbitDistance = 0.4f;
    [SerializeField] private float ballContactDistance = 0.2f;
    [SerializeField] private float cueElevation = 1;
    [SerializeField] private float cueXRotation = -90;
    [SerializeField] private float cueReleaseAnimationTime = 0.1f;
    [SerializeField] private float hitForce = 8;

    private SpriteRenderer _sprite;
   
    private Vector3 _mouseWorldPosition;
    private Vector3 _mouse2DWorldPosition;
    private Vector3 _cueOffset;
    private Vector3 _orbitAround2DPosition;
    private Vector3 _cueRotation;
    private Vector3 _inputOffset;
    private Camera _cam;
    private float _startChargeDistnce;
    private float _chargeDistance;
    private float _cueDistance;
    private float _ReleaseDistnce;
    private IEnumerator _cueRelease;
    private bool _isCueReleaseFinished;
    public bool heGolpeadoBola = false;
    void Start()
    {
        _cam = Camera.main;
        _sprite = GetComponent<SpriteRenderer>();
       
    }

    void Update()
    {
        ApplyForceToBallAfterHitPerformed();
        if (orbitAround == null)
        {
            CueVisibile(false);
            return;
        }

        if(ballsState.BolasEstanParadas())
        {
            CueVisibile(true);
          
            
        }
        else
        {
            CueVisibile(false);
         
            return;
        }

        CalculateMouseInput();
        HandleChargeInput();
        UpdateCuePosition();
        UpdateCueRotation();
      
    }

    private void CueVisibile(bool visiblity)
    {
        _sprite.enabled = visiblity;
    }

    private void CalculateMouseInput()
    {
        _mouseWorldPosition = _cam.ScreenToWorldPoint(Input.mousePosition);
        _orbitAround2DPosition = new Vector3(orbitAround.position.x, 0, orbitAround.position.z);
        _mouse2DWorldPosition = new Vector3(_mouseWorldPosition.x, 0, _mouseWorldPosition.z);
        _inputOffset = _mouse2DWorldPosition - _orbitAround2DPosition;
    }

    private void HandleChargeInput()
    {
        if(Input.GetMouseButton(0))
        {
            if(Input.GetMouseButtonDown(0))
            {
                _startChargeDistnce = Vector3.Magnitude(_inputOffset);
            }
            _chargeDistance = Vector3.Magnitude(_inputOffset) - _startChargeDistnce;
        }
        else if(Input.GetMouseButtonUp(0))
        {
            _cueRelease = CueRelease();
            StopCoroutine(_cueRelease);
            StartCoroutine(_cueRelease);
        }
    }
   
    private void UpdateCuePosition()
    {
        _cueDistance = Mathf.Clamp(defaultOrbitDistance + _chargeDistance, ballContactDistance, Mathf.Infinity);
        _cueOffset = _inputOffset.normalized * _cueDistance + Vector3.up * cueElevation;
        transform.position = orbitAround.position + _cueOffset;
    }

    private void UpdateCueRotation()
    {
        _cueRotation = new Vector3(cueXRotation, 0, Mathf.Rad2Deg * Mathf.Atan2(_cueOffset.x, _cueOffset.z) + 180);
        transform.localEulerAngles = _cueRotation;
    }

    private void ApplyForceToBallAfterHitPerformed()
    {
        if(_isCueReleaseFinished == true)
        {
            _chargeDistance = 0;
           
            orbitAround.GetComponent<Rigidbody>().AddForce(_inputOffset.normalized * -_ReleaseDistnce * hitForce, ForceMode.Impulse);
            Debug.Log("me toco taco");
            heGolpeadoBola = true;
            Debug.Log("taco golpea bola blanca");
            SoundManager.instance.PlayCueBallCollisionSound();
            _isCueReleaseFinished = false;
            
        }
    }
    


    private IEnumerator CueRelease()
    {
        float time = cueReleaseAnimationTime;
        _ReleaseDistnce = _chargeDistance;
        _isCueReleaseFinished = false;
        while(time > 0)
        {
            time -= Time.deltaTime;
            _chargeDistance = Mathf.Lerp(ballContactDistance - defaultOrbitDistance, _ReleaseDistnce, time / cueReleaseAnimationTime);
            yield return null;
        }
        _isCueReleaseFinished = true;
    }
}
