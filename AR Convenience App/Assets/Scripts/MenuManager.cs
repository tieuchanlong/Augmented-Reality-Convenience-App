using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    private bool openmenu = false;
    public GameObject Menu;

    public Animator anim;
    public Button button;
    private AnimatorStateInfo currentState;     // 現在のステート状態を保存する参照
    private AnimatorStateInfo previousState;

    // Start is called before the first frame update
    void Start()
    {
        currentState = anim.GetCurrentAnimatorStateInfo(0);
        previousState = currentState;
    }

    // Update is called once per frame
    void Update()
    {
        Menu.SetActive(openmenu);

        if (anim.GetBool("Next"))
        {
            // 現在のステートをチェックし、ステート名が違っていたらブーリアンをfalseに戻す
            currentState = anim.GetCurrentAnimatorStateInfo(0);
            if (previousState.nameHash != currentState.nameHash)
            {
                anim.SetBool("Next", false);
                previousState = currentState;
            }
        }

        // "Back"フラグがtrueの時の処理
        if (anim.GetBool("Back"))
        {
            // 現在のステートをチェックし、ステート名が違っていたらブーリアンをfalseに戻す
            currentState = anim.GetCurrentAnimatorStateInfo(0);
            if (previousState.nameHash != currentState.nameHash)
            {
                anim.SetBool("Back", false);
                previousState = currentState;
            }
        }
    }

    public void OpenMenu()
    {
        openmenu = !openmenu;
    }

    public void NextModel()
    {
        anim.SetBool("Next", true);
    }

    public void BackModel()
    {
        anim.SetBool("Back", true);
    }

    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(0.00f);
    }

    public void StartApp()
    {
        SceneManager.LoadScene(1);
    }
}
