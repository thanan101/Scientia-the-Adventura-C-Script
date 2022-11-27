using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MediaDocControl : MonoBehaviour
{
    //[SerializeField]GameObject[] bigPicture;
    Animator anim;
    [SerializeField] GameObject[] MediaLearningPic;
    [SerializeField] Text detailText;
    [SerializeField] string textMenuDetail;
    bool bigPic = false;
    private void Start()
    {
        anim = GetComponent<Animator>();
        
    }
    public void ClickBigPicture()
    {
        if(bigPic == false)
        {
            anim.SetBool("watchLarge", true);
            
        }
        //bigPicture[id].SetActive(true);
        
    }
    public void ClickSmallPicture()
    {
        /*for(int i = 0; i < bigPicture.Length; i++)
        {
            bigPicture[i].SetActive(false);
        }*/
        if (bigPic == true)
        {
            anim.SetBool("watchLarge", false);
            

        }        
    }
    public void ResetMediaLeatnPic()
    {
        for (int i = 0; i < MediaLearningPic.Length; i++)
        {
            MediaLearningPic[i].SetActive(false);
        }
        detailText.text = textMenuDetail;
    }
    public void ClickListResetMediaLeatnPic(int id)
    {
        ResetMediaLeatnPic();
        detailText.text = "¤ÅÔê¡·ÕèÀÒ¾à¾×èÍ´ÙÀÒ¾¢¹Ò´ãË­è";
        MediaLearningPic[id].SetActive(true);
    }
    public void SetIsBignow()
    {
        bigPic = true;
    }
    public void SetIsSmallnow()
    {
        bigPic = false;
    }
}
