using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ActionHandler : MonoBehaviour
{
    [SerializeField] private GameObject _scythe;
    [SerializeField] private Transform _stackPos;
    private List<GameObject> _hayStacks = new List<GameObject>();
    public void Mow()
    {
        Invoke("MowStart", 0.3f);
        AnimationHandler.Mow();
        Invoke("MowEnd",1.5f);
    }

    private void MowStart()
    {
        _scythe.SetActive(true);
    }

    private void MowEnd()
    {
        _scythe.SetActive(false);
    }

    private void ToBascket(GameObject hay,int k)
    {
        var destination = new Vector3(0, k*0.5f, 0);
        hay.transform.DOLocalMove(destination, 1);
        hay.transform.DOLocalRotate(Vector3.zero, 1);
        hay.GetComponent<Collider>().enabled = false;
    }

    private void PickUp(GameObject hay)
    {
        var k = _hayStacks.Count;
        if(k < 40)
        {
            hay.transform.SetParent(_stackPos);
            _hayStacks.Add(hay);
            ToBascket(hay, ++k);
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag=="Hay")
        {
            PickUp(col.gameObject);
        }
    }
}
