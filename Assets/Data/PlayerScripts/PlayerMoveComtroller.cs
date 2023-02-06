using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GB;
using System.Collections.ObjectModel;
using static UnityEngine.Debug;
using TMPro;
using System;

//________________________________________
//public static delegate void TestDelegate();
public delegate void TestDelegate();
public delegate void TestDelegate2(float value);
public delegate void TestDelegate3(bool val, float value);
//________________________________________

public sealed class PlayerMoveComtroller : MonoBehaviour, IDisposable
{

    //________________________________________
    public static TestDelegate TestDelegate_1;
    public static TestDelegate TestDelegate_2;
    private TestDelegate2 test_2_Delegate;
    private TestDelegate3 test_ShowAbility_Delegate;
    //2  private TestDelegate2 abilityDelegate;
    //________________________________________

    #region Fields
    [SerializeField] private TextMeshProUGUI _playerVelocityLabel;
    [SerializeField] private TextMeshProUGUI _bostValueLabel;
    [Space(5)]
    [SerializeField] private float _jumpPower;
    [SerializeField] private int _boostValueTime = 2;
    [SerializeField] private static int _torqueBoostValue;
    [SerializeField] private AudioSource _speedBoostSFX;
    private Transform _cameraTransformPoint;
    private CoinsManager CoinsManager;
    private Rigidbody _rigidbody;
    private bool _isGrounded;
    private bool _abilityIsActive;

    private static float _torqueValue = 7;
    private float _inputDirVertical, _inputDirHorizontal;

    //private PlayerAbilities ability = new PlayerAbilities();
    #endregion

    #region Code execution
    void Start()
    {
        _cameraTransformPoint = FindObjectOfType<CameraFollowTo>().transform;
        CoinsManager = FindObjectOfType<CoinsManager>();
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.maxAngularVelocity = 100f;

        #region Part 1/2 ��������
        // TestDelegate_1 = ability.Heal;
        TestDelegate_1 = PlayerAbilities.Heal;
        TestDelegate_1 += PlayerAbilities.FreezeEnemy;
        TestDelegate_2 = PlayerAbilities.SpeedBoost_2;
        PlayerAbilities.TestDelegate_3 = PlayerAbilities.SpeedBoost_2;

        //_____________________________________________
        test_2_Delegate += ShowSpeedDelegate; // part 1/2 ��������
        test_ShowAbility_Delegate += ShowAbilityDelegate; // part 1/2 ��������
        _abilityIsActive = false;
        _bostValueLabel.gameObject.SetActive(_abilityIsActive);
        //  TODO
        // 3  abilityDelegate += PlayerAbilities.SpeedBoost(11);
        #endregion                           
        //List<EnemyHealth> enemies = new List<EnemyHealth>();
    }

    void Update()
    {
        InputValues(); //_torqueValueLabel.text = "Boost: " + _torqueValue.ToString();
                       // _torqueValueLabel.text = (1 / Time.deltaTime).ToString();
        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _rigidbody.AddForce(Vector3.up * _jumpPower, ForceMode.VelocityChange);
        }

        #region TEST
        //_____________________________________________
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log(" KeyCode.Alpha1 ");
            PlayerAbilities.SpeedBoost(3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log(" KeyCode.Alpha2 ");
            PlayerSpeedUp();
            Invoke("PlayerSpeedDown", _boostValueTime);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Debug.Log(" KeyCode.Alpha3 ");
            TestDelegate_1?.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Debug.Log(" KeyCode.Alpha4 ");
            TestDelegate_2?.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            Debug.Log(" KeyCode.Alpha5 ");
            PlayerAbilities.TestDelegate_3?.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            Destroy(gameObject); Log("Destroy(gameObject)");
        }

        //  TODO
        //4 abilityDelegate.Invoke();
        #endregion

        if (test_2_Delegate != null)
        {
            test_2_Delegate.Invoke(_rigidbody.velocity.magnitude);
        }
        else
        {
            LogWarning("Delegate is null");
        }

        try
        {
            test_ShowAbility_Delegate?.Invoke(true, _torqueValue);
        }
        catch (Exception e)
        {
            LogException(e);
            throw;
        }

        //try
        //{
        //    //...
        //}
        //catch (System.Exception e)
        //{
        //    LogException(e);
        //}
    }


    private void FixedUpdate()
    {
        RbMove();
    }
    #endregion

    #region methods

    private void InputValues()
    {
        _inputDirHorizontal = Input.GetAxis("Horizontal");
        _inputDirVertical = Input.GetAxis("Vertical");
    }
    private void RbMove()
    {
        _rigidbody.AddTorque(-_cameraTransformPoint.forward * _inputDirHorizontal * _torqueValue);
        _rigidbody.AddTorque(_cameraTransformPoint.right * _inputDirVertical * _torqueValue);
    }

    public void PlayerSpeedUp()  //  TODO  delegate
    {
        _abilityIsActive = true;
        _speedBoostSFX.Play();
        _bostValueLabel.gameObject.SetActive(_abilityIsActive);
        //test_ShowAbility_Delegate += ShowAbilityDelegate; // part 1/2 ��������
        _torqueValue *= 2;
    }
    public void PlayerSpeedDown() //  TODO delegate
    {
        _torqueValue /= 2;
        //float boostValue = _torqueValue;
        _abilityIsActive = false;
        ShowAbilityDelegate(_abilityIsActive, _torqueValue);
    }
    private void ShowSpeedDelegate(float speed)
    {
        float _playerSpeed = Mathf.RoundToInt(speed);
        _playerVelocityLabel.text = "Speed: " + _playerSpeed;
    }
    private void ShowAbilityDelegate(bool val, float torqueVal)
    {
        if (_abilityIsActive)
        {
            float boostValue = torqueVal;
            _bostValueLabel.text = "Boost: " + (boostValue / 7).ToString();
            _bostValueLabel.gameObject.SetActive(val);
        }
        else
        {
            _bostValueLabel.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Loot loot = other.GetComponent<Loot>();
        if (loot)
        {
            CoinsManager.CollectCoin(loot);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        float angle = Vector3.Angle(collision.contacts[0].normal, Vector3.up);

        if (angle < 45f)

        {
            _isGrounded = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        _isGrounded = false;
    }
    #endregion

    #region Part 2/2 �������
    private void OnDestroy()
    {
        TestDelegate_1 -= PlayerAbilities.Heal;
        TestDelegate_1 -= PlayerAbilities.FreezeEnemy;
        TestDelegate_2 -= PlayerAbilities.SpeedBoost_2;
        PlayerAbilities.TestDelegate_3 -= PlayerAbilities.SpeedBoost_2;
    }

    public void Dispose()
    {
        test_ShowAbility_Delegate -= ShowAbilityDelegate; // part 1/2 ��������

        //throw new NotImplementedException();
    }

    ~PlayerMoveComtroller()
    {
        test_2_Delegate -= ShowSpeedDelegate; Log(" ~ PlayerMoveComtroller() Destructor)"); // part 2/2 �������
    }
    #endregion
}
