using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUps : MonoBehaviour
{
    [SerializeField]
    private GameObject food;
    [SerializeField]
    private string foodName;
    [SerializeField]
    private int healPoints;

    [SerializeField]
    private GameObject dialogBox;
    private DialogBox dialog;

    [SerializeField]
    private GameObject HP;
    private HP playerHP;

    private string healDialog;

    void Awake() {
        dialog = dialogBox.GetComponent<DialogBox>();
        playerHP = HP.GetComponent<HP>();
    }

    void Start() {
        healDialog = foodName + " heals you for " + healPoints.ToString() + " points!";
    }

    void OnTriggerEnter2D(Collider2D collider) {
        if (collider.name == "Player") {
            Destroy(food.GetComponent<BoxCollider2D>());
            food.GetComponent<SpriteRenderer>().color = new Color(0,0,0,0);
            playerHP.healHP(healPoints);
            dialog.addDialog(healDialog);
        }
    }

}
