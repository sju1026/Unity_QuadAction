using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    public RectTransform uiGroup;
    public Animator anim;

    public GameObject[] itemObj;
    public int[] itemPrice;
    public Transform[] itemPos;
    public string[] talkData;
    public Text talkTaxt;

    Player enterplayer;

    public void Enter(Player player)
    {
        enterplayer = player;
        uiGroup.anchoredPosition = Vector3.zero;
    }

    public void Exit()
    {
        anim.SetTrigger("doHello");
        uiGroup.anchoredPosition = Vector3.down * 1000;
    }

    public void Buy(int idx)
    {
        int price = itemPrice[idx];
        if(price > enterplayer.coin)
        {
            StopCoroutine(Talk());
            StartCoroutine(Talk());
            return;
        }
        enterplayer.coin -= price;
        Vector3 ranVec = Vector3.right * Random.Range(-3, 3)
                            + Vector3.forward * Random.Range(-3, 3);
        Instantiate(itemObj[idx], itemPos[idx].position + ranVec, itemPos[idx].rotation);
    }

    IEnumerator Talk()
    {
        talkTaxt.text = talkData[1];
        yield return new WaitForSeconds(2f);
        talkTaxt.text = talkData[0];
    }
}
