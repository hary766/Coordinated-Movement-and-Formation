using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Unit : MonoBehaviour
{
    Vector3 desiredPostion;
    Vector3 currentPostion;

    [SerializeField]
    private Material unitColor;

    [SerializeField]
    private NavMeshAgent navMeshAgent;

    [SerializeField]
    private GameObject selected;

    bool currrentActive;
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }
    public void SetCurrentPostion(Vector3 pos)
    {
        currentPostion = pos;
    }
    public Vector3 GetCurrentPostion()
    {
        return currentPostion;
    }
    public void Moveunit()
    {
        navMeshAgent.destination = desiredPostion;
    }
   public void SetDesiredPostion(Vector3 postion)
    {
        desiredPostion = postion;
    }
    public void SetIsActive(bool isActive)
    {
        currrentActive = isActive;
        selected.SetActive(isActive);
    }
   public bool GetisAcitve()
    {
        return currrentActive;
    }
}
