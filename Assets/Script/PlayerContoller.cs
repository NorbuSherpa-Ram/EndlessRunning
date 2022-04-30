using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerContoller : MonoBehaviour
{
    [SerializeField]
    private int yMove = 5;
    [SerializeField]
    private int speed = 50;
    [SerializeField]
    private int maxY = 5;
    [SerializeField]
    private int minY = -5;
    private Vector2 targetPosition;

    [SerializeField]
    private int playerHealth = 3;

    [SerializeField]
    private GameObject effect;
    [SerializeField]
    private GameObject soundEffect;
    [SerializeField]
    private Animator cameraShake;

    [SerializeField] private Text healthCount;

    [SerializeField] UiManager uiManager;


    // for moblile input 
    [SerializeField] bool itIsMoblie;
    [SerializeField] GameObject buttonPanel;
    [SerializeField] GameObject pauseButton;
    [SerializeField] GameObject exitButton;

    private void Start()
    {
        if (itIsMoblie)
        {
            uiManager.exitText.text = "Tap here to Exit ";
            uiManager.continueText.text = "Tap here to Resume ";
            uiManager.restartText .text = "Tap here to restart ";
            uiManager.tapToPlayText  .text = "Tap To Play ";
            buttonPanel.SetActive(true);
            pauseButton.SetActive(true);
        }
        healthCount.text = "Life:" + playerHealth.ToString();
    }
    void Update()
    {
        if (itIsMoblie)
        {
            if (uiManager.isPause || uiManager.isOver)
            {
                buttonPanel.SetActive(false );
                pauseButton.SetActive(false );
            }
            else
            {
                buttonPanel.SetActive(true);
                pauseButton.SetActive(true);
            }
        }
        // if game is not pause 
        if (!uiManager.isPause)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) && transform.position.y < maxY)
            {
                Effect();
                targetPosition = new Vector2(transform.position.x, transform.position.y + yMove);
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow) && transform.position.y > minY)
            {
                Effect();
                targetPosition = new Vector2(transform.position.x, transform.position.y - yMove);
            }
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
    }
    // on upButton click 
    public void UpButton()
    {
        if (transform.position.y < maxY)
        {
            Effect();
            targetPosition = new Vector2(transform.position.x, transform.position.y + yMove);
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
    }
    // on downButton click
    public void DownButton()
    {
        if (transform.position.y > minY)
        {
            Effect();
            targetPosition = new Vector2(transform.position.x, transform.position.y - yMove);
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        }
    }
    public void Effect()
    {
        cameraShake.SetTrigger("Shake");
        Instantiate(effect, transform.position, Quaternion.identity);
        Instantiate(soundEffect, transform.position, Quaternion.identity);
    }
    public void HealthContoller(int damage)
    {
        playerHealth -= damage;
        healthCount.text = "Life:" + playerHealth.ToString();

        if (playerHealth == 0)
        {
            // game Over function from UiManagerUiManager
            uiManager.GameOver();
            Destroy(gameObject,0.5f);
        }
        //   Debug.Log(playerHealth);
    }
}
