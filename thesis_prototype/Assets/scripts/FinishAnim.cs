using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class FinishAnim : MonoBehaviour {

    public string animName = "end";
    public string levelName = "main";
    private GameObject thing = GameObject.Find("sprite_166");
    public Animation anim;

    //void Start() {
        //anim = thing.GetComponent<Animation>();
    //}

    public void Play() {
        anim.Play(animName);
        StartCoroutine(LoadAfterAnim());
    }

    public IEnumerator LoadAfterAnim() {
        yield return new WaitForSeconds(anim.clip.length);
        //Application.LoadLevelAsync(levelName);
        SceneManager.LoadSceneAsync(levelName);
    }
}
