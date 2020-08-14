using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class SM4TweeningTests : MonoBehaviour
{
    public GameObject red;
    public GameObject blue;
    public GameObject green;
    public GameObject black;
    public GameObject pink;
    
    public float frames = 1000;
    public float elapsedFrames = 0;
    public float stepSize = 0.01f;
    public float speed;
    

    private void Awake()
    {
        
    }

    private void Start()
    {
        speed = 100;
        speedMeterPerSecond = 100;
        MoveTo(pink, new Vector3(200, 0),
            ()=>MoveTo(pink, new Vector3(200, 200),
                ()=>MoveTo(pink, new Vector3(-200, 200),
                    ()=>MoveTo(pink, new Vector3(-200, -200),
                        ()=>MoveTo(pink, new Vector3(200, -200),
                            ()=>MoveTo(pink, new Vector3(200, 0),
                                ()=>MoveTo(pink, new Vector3(0, 0),
                                    ()=>print("end")
                                )))))));
    }

    private void Update()
    {

        MoveTests();
        MoveToUpdate();
    }
    
    
    




    public void MoveTests()
    {
        float percentalNormalized1 = 1 / frames; // this never reaches the target
        float percentalNormalized2 = elapsedFrames / frames; // this has a constant speed
        elapsedFrames++;
        MoveAround(red.transform,new Vector3(0,0,0),percentalNormalized1);
        MoveAround(blue.transform,new Vector3(0,0,0),percentalNormalized2);
        MoveAround2(green.transform,new Vector3(0,0,0),speed);
        MoveAround3(black.transform,new Vector3(0,0,0),stepSize);
    }

    public void MoveAround(Transform transform,Vector3 newPosition, float percentalNormalized)
    {
        transform.localPosition = Vector3.Lerp(transform.position, newPosition, percentalNormalized);
    }
    public void MoveAround2(Transform transform,Vector3 newPosition, float moveSpeed)
    {
        var step = moveSpeed * Time.deltaTime;
        //print($"{step} = {moveSpeed}*{Time.deltaTime}");
        transform.position = Vector3.MoveTowards(transform.position, newPosition, step);
    }
    public void MoveAround3(Transform transform,Vector3 newPosition, float step)
    {
        transform.position = Vector3.MoveTowards(transform.position, newPosition, step);
    }
    
    public float speedMeterPerSecond;
    public float totalLerpDuration;
    public float elapsedLerpDuration = 0f;
    public Vector3? _destination;
    public Vector3 _startPosition;
    public Action _onCompleteCallback;
    public Transform targetTransform;
    public void MoveTo(GameObject thing, Vector3 destination, [CanBeNull] Action onComplete = null)
    {
        var distantceToNextWaypoint = Vector3.Distance(thing.transform.position, destination);
        totalLerpDuration = distantceToNextWaypoint / speedMeterPerSecond;
        _startPosition = thing.transform.position;
        _destination = destination;
        elapsedLerpDuration = 0f;
        _onCompleteCallback = onComplete;
        targetTransform = thing.transform;
    }

    public void MoveToUpdate()
    {
        if(!_destination.HasValue)
            return;
        if (elapsedLerpDuration >= totalLerpDuration && totalLerpDuration > 0)
            return;
        elapsedLerpDuration += Time.deltaTime;
        float percent = elapsedLerpDuration / totalLerpDuration;
        targetTransform.position = Vector3.Lerp(_startPosition, _destination.Value, percent);
        if(elapsedLerpDuration>=totalLerpDuration)
            _onCompleteCallback?.Invoke();
    }
    
}
