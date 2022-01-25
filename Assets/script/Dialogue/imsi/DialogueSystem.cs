using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueSystem : MonoBehaviour
{
    public GameObject Seller;
    public GameObject Buyer;

    public TextMeshProUGUI BuyerDialogue;
    public TextMeshProUGUI SellerDialogue;

    Queue<string> Buyersentences = new Queue<string>();//������ ���������� ���;� �ϹǷ� ť ���

    public void Begin(Dialogue info)
    {
        Buyer.gameObject.SetActive(true);

        Buyersentences.Clear();
     
        foreach (var BuyerSentence in info.BuyerSentences)
        {
            Buyersentences.Enqueue(BuyerSentence.dialogue);
        }
        BuyerNext();
    }

    public void BuyerNext()
    {
        if (Buyersentences.Count == 0)
        {
            BuyerEnd();
            return;
        }

        BuyerDialogue.text = Buyersentences.Dequeue();
    }

    private void BuyerEnd()
    {
        Buyer.gameObject.SetActive(false);
        BuyerDialogue.text = string.Empty;
    }
}
