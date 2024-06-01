using System;
using System.Collections;
using Result;
using UnityEngine;
using UnityEngine.UI;

public class Baseball : MonoBehaviour
{
    // Déclarez une variable publique pour stocker le délai du lancer de balle
    public float ballThrowDelay = 2f; // Valeur par défaut, peut être ajustée depuis l'inspecteur

    private Rigidbody _rigidbody;
    public Slider _slider;
    public float baseballSpeed;
    public distanceTracker distanceTrackerScript;
    public GameObject terrainPrefab;
    public Animator _animator;
    private bool flag = true;
    private Vector3 right_hand_pos;
    [SerializeField] private double throw_time = 0.36;
    private Vector3 offset = new Vector3(-0.115f, -0.183f, 0.0f);
    public bool isFoul = false;
    
    public Result.ResultState m_ResultState = Result.ResultState.Foul;

    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.transform.position = GameObject.Find("mixamorig5:RightHand").transform.position + offset;
        _animator = GameObject.Find("Baseball Pitching").GetComponent<Animator>();

        // Lancez l'animation dès le début avec le délai spécifié
        // StartCoroutine(RestartAnimationAfterDelay(ballThrowDelay));
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("HomeRunBound"))
        {
            // Debug.Log("Home Run!!!");
            m_ResultState = ResultState.HR;
        }
        else if(other.collider.CompareTag("Ground"))
        {
            // Debug.Log("Ground Ball!!!");
            m_ResultState = ResultState.Ground;
        }
        else
        {
            // Debug.Log("Foul Ball!!!");
            m_ResultState = ResultState.Foul;
        }
    }

    int CheckBallPosition()
    {
        Vector3 ballPosition = transform.position;
        Vector3 terrainPosition = terrainPrefab.transform.position;
        Vector3 terrainSize = terrainPrefab.GetComponent<Collider>().bounds.size;

        // Debug.Log(terrainPrefab.GetComponent<Collider>().bounds.size);

        if (ballPosition.x >= terrainPosition.x - terrainSize.x / 2f &&
            ballPosition.x <= terrainPosition.x + terrainSize.x / 2f &&
            ballPosition.y >= terrainPosition.y - terrainSize.y / 2f &&
            ballPosition.y <= terrainPosition.y + terrainSize.y / 2f &&
            ballPosition.z >= terrainPosition.z - terrainSize.z / 2f &&
            ballPosition.z <= terrainPosition.z + terrainSize.z / 2f)
        {
            return 0;
        }
        else
        {
            return 1;
        }
    }

    void Update()
    {
        right_hand_pos = GameObject.Find("mixamorig5:RightHand").transform.position + offset;

        AnimatorStateInfo stateInfo = _animator.GetCurrentAnimatorStateInfo(0);

        if (stateInfo.normalizedTime > throw_time && flag && stateInfo.IsName("Pitched"))
        {
            distanceTrackerScript.ResetDistance();
            distanceTrackerScript.StopFollowingBall();
            distanceTrackerScript.disableTrail();
            ThrowFastball(right_hand_pos);
            flag = false;
            // Démarrez la coroutine avec le délai spécifié
            // StartCoroutine(RestartAnimationAfterDelay(ballThrowDelay));
        }
        else if (stateInfo.IsName("Pitched") && flag && stateInfo.normalizedTime <= throw_time)
        {
            _rigidbody.transform.position = right_hand_pos;
        }

        if (stateInfo.IsName("Stand"))
        {
            distanceTrackerScript.StopFollowingBall();
            distanceTrackerScript.disableTrail();
            // _rigidbody.transform.position = right_hand_pos;
            flag = true;
        }
    }

    Vector3 GetRandomThrowPoint()
    {
        System.Random random = new System.Random();
        double x = random.NextDouble() * 1.6 - 0.8;  
        double y = random.NextDouble() * 0.4 + 2.2;  
        // Debug.Log("出手点随机x:" + x + " y:" + y);
        return new Vector3((float)x, (float)y, -30);
    }

    void ThrowFastball(Vector3 pos)
    {
        System.Random random = new System.Random();  
        double x = random.NextDouble();  
        double y = random.NextDouble() + 2;  
        int z = random.Next(45, 75); 
        transform.position = GetRandomThrowPoint();
        _rigidbody.velocity = new Vector3((float)x, (float)y, z);
        _rigidbody.angularVelocity = new Vector3(-50, 0, 0);
    }

    void ThrowSliderball()
    {
        // Implementation pour ThrowSliderball
    }
}
