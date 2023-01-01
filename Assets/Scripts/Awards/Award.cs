using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;



public class Award : MonoBehaviour
{

    public enum AwardType { Add, Multiply }

    public AwardType type;
    public int amount;
    public int multiply;
    [SerializeField] private TextMeshProUGUI awardTextField;
    public string awardText;
    private GameObject player;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        awardTextField.SetText(awardText);
    }

    public void DetectAward()
    {
        switch (type)
        {
            case AwardType.Add:
                PlayerController.instance.MakePlayerClone(PlayerController.instance.numberOfPlayerClones + amount);
                break;
            case AwardType.Multiply:
            PlayerController.instance.MakePlayerClone(PlayerController.instance.numberOfPlayerClones * amount);
                Debug.Log("Your Clones Multiplied!");
                break;
        }

        return;
    }
}




