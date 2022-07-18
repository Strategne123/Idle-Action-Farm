using System.Collections;
using UnityEngine;

public class WheatHandler : MonoBehaviour
{
    //высота полностью заполненного шейдера
    private const float MAX_HEIGHT = 8;
    //максимальное число срезов для пшеницы
    private const float CUT_NUM = 3;
    private float _currentHeight;
    private Material _material;
    private bool _canMow=true;

    [SerializeField] GameObject _hay;
    [SerializeField] Transform _hayStart;

    private void Start()
    {
        _currentHeight = 0;
        _material=GetComponent<MeshRenderer>().material;
        StartCoroutine(Grouth());
    }

    private IEnumerator Grouth()
    {
        while(true)
        {
            if(_currentHeight < MAX_HEIGHT)
            {
                _currentHeight+=MAX_HEIGHT/100;
                _material.SetFloat("edge", _currentHeight);
            }
            yield return new WaitForSeconds(0.1f);
        }
    }

    private void Cut()
    {
        if(_canMow && _currentHeight>MAX_HEIGHT/CUT_NUM)
        {
            StartCoroutine(Recharge());
        }
    }

    private void CreateHay()
    {
        var hay = Instantiate(_hay);
        var delta = new Vector3(Random.value - 0.5f, Random.value - 0.5f, Random.value - 0.5f);
        hay.transform.position = _hayStart.position + delta;
    }

    private IEnumerator Recharge()
    {
        _canMow = false;
        yield return new WaitForSeconds(0.7f);
        _currentHeight -= MAX_HEIGHT / CUT_NUM;
        CreateHay();
        _canMow = true;
    }
    
    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag=="Scythe")
        {
            Cut();
        }
    }
}
