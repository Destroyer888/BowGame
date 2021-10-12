using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private BowController bowController;

    public AppleController[] managementApples; //settingsApple, playApple, shopApple, returnApple

    private void Awake() => instance = this;
    void Start()
    {
        bowController = BowController.instance;
        managementApples[0].onDeadEvent += Settings;
        managementApples[1].onDeadEvent += Play;
        managementApples[2].onDeadEvent += Shop;
        managementApples[3].onDeadEvent += BackToMainScreen;
    }

    //private void EnableBow(bool enable) => bowController.enabled = enable;

    public void Settings()
    {
        EnableApples(false, 3);
    }

    public void Shop()
    {
        EnableApples(false, 3);
    }
    
    public void Play()
    {
        EnableApples(false);
        LevelController.instance.SwitchLevel();
    }
    public void BackToMainScreen()
    {
        EnableApples(true);
    }

    private void EnableApples(bool enabled, int exeption = -1)
    {
        for (int i = 0; i < managementApples.Length; i++)
        {
            if(i == exeption) managementApples[i].gameObject.SetActive(!enabled);
            managementApples[i].gameObject.SetActive(enabled);
        }

    }
}
