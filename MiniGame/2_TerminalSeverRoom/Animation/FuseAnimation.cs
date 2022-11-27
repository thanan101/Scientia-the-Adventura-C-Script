using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuseAnimation : MonoBehaviour
{
    RectTransform _fuseRectTranform;
    [SerializeField]float speed=10;

    void Start()
    {
        _fuseRectTranform=GetComponent<RectTransform>();
    }
    void Update()
    {
        //  MoveAnim();
        
    }
    public void MoveAnim()
    {
        _fuseRectTranform.Translate(Vector3.right * speed * Time.deltaTime ) ;
    }
    
}
