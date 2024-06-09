using System;
using System.Collections;
using System.Collections.Generic;
using Result;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class IsHit : MonoBehaviour
{
    private Animator _animator;
    private Transform ballTransform;
    private float stand_time = 0.0f;
    private float wait_time = 0.0f;
    private bool isHitBall = false;
    private Collider baseballCollider;
    private Baseball _baseball;
    public float ballThrowDelay = 1f; // Valeur par défaut, peut être ajustée depuis l'inspecteur
    private bool isDisplayMenu = false;
    public GameObject Menu;
    
    private ResultText _resultText;

    private int _score = 0;
    private int throw_times = 0;
    
    public AudioSource homerunSound;
    public AudioSource groundballSound;

    public XRGrabInteractable grabInteractable;
    public Rigidbody bat;
    private bool isGrabbed = false;
    
    // Start is called before the first frame update
    void Start()
    {
        _animator = GameObject.Find("Baseball Pitching").GetComponent<Animator>();
        ballTransform = GameObject.Find("Baseball").GetComponent<Transform>();
        baseballCollider = GameObject.Find("Baseball").GetComponent<Collider>();
        _baseball = GameObject.Find("Baseball").GetComponent<Baseball>();
        _resultText = GameObject.Find("ResultText").GetComponent<ResultText>();
        
        // StartCoroutine(RestartAnimationAfterDelay(ballThrowDelay));
        
        grabInteractable.selectEntered.AddListener(OnGrabStarted);
        grabInteractable.selectExited.AddListener(OnGrabEnded);
    }

    private void OnGrabStarted(SelectEnterEventArgs args)
    {
        isGrabbed = true;
    }
    
    private void OnGrabEnded(SelectExitEventArgs args)
    {
        isGrabbed = false;
    }
    
    IEnumerator RestartAnimationAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        _animator.Play("Pitched", 0, 0f);
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            Debug.Log("Hit the ball");
            isHitBall = true;
            
        }
    }

    public int getScore()
    {
        return _score;
    }
    
    public int getThrowTimes()
    {
        return throw_times;
    }
    
    private bool isFoul()
    {
        return _baseball.isFoul;
    }

    public void ResetScore()
    {
        _score = 0;
        throw_times = 0;
        Debug.Log("分数清零：" + _score);
    }
    
    // Update is called once per frame
    void Update()
    {
        // if (!isGrabbed)
        // {
        //     return;
        // }
        Debug.Log(isGrabbed);
        if (!Menu.activeSelf)
        {
            if (isHitBall)
            {
                wait_time += Time.deltaTime;
                if (wait_time > 8.0f)
                {
                    wait_time = 0;
                    isHitBall = false;
                    _resultText.DisplayResult(_baseball.m_ResultState);
                    // Debug.Log("打出了" + _baseball.m_ResultState);
                    if(_baseball.m_ResultState == ResultState.HR)
                    {
                        _score += 6;
                        homerunSound.Play();
                        //Debug.Log("当前分数：" + _score);
                    } else if (_baseball.m_ResultState == ResultState.Ground)
                    {
                        _score += 2;
                        groundballSound.Play();
                        //Debug.Log("当前分数：" + _score);
                    }
                }
            }
            else
            {
                stand_time += Time.deltaTime;
                if (stand_time > 6.0f)
                {
                    stand_time = 0;
                    if (throw_times < 15)
                    {
                        if (isGrabbed)
                        {
                            throw_times += 1;
                            StartCoroutine(RestartAnimationAfterDelay(ballThrowDelay));
                        }
                    }
                    else
                    {
                        throw_times = 0;
                        Menu.SetActive(true);
                    }
                }
            }
        }
        else
        {
            Debug.Log("游戏暂停，提交成绩，关闭菜单后开始");
        }
        
        
    }
}
