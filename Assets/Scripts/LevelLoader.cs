using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    [Header("UI's")]
    [SerializeField] GameObject inGameUI;
    [SerializeField] GameObject mainUI;
    [SerializeField] GameObject endLevelUI;
    [SerializeField] GameObject levelsUI;
    [SerializeField] GameObject deathUI;
    [SerializeField] GameObject pauseUI;
    [SerializeField] GameObject mainScene;
    [Header(" ")]


    public GameObject level1 = null;
    public GameObject level2 = null;
    public GameObject level3 = null;
    public GameObject level4 = null;
    public GameObject level5 = null;
    public GameObject level6 = null;

    [Header(" ")]
    public GameObject playerObject;
    public GameObject camera;
    public GameObject moveParticle;
    [Header(" ")]

    GameObject instantiatedLevel;
    

    public Transform playerTransform;
    public Transform cameraTransform;

    public Vector2 playerDefaultPos;
    public Vector3 cameraDefaultPos;

    public Animator transition;
    public float transitionTime = 1f;

    public void LoadLevel1()
    {
        playerObject.GetComponent<CapsuleCollider2D>().enabled = true;
        playerObject.GetComponent<Rigidbody2D>().gravityScale = 4f;
        playerObject.SetActive(true);
        moveParticle.SetActive(false);
        camera.SetActive(true);
        levelsUI.SetActive(false);
        inGameUI.SetActive(true);
        mainScene.SetActive(false);
        playerTransform.position = playerDefaultPos;
        cameraTransform.position = cameraDefaultPos;
        instantiatedLevel = Instantiate(level1, new Vector2(0, 0), Quaternion.identity);
        StartCoroutine(sceneTransition());
    }
    public void LoadLevel2()
    {
        playerObject.GetComponent<CapsuleCollider2D>().enabled = true;
        playerObject.GetComponent<Rigidbody2D>().gravityScale = 4f;
        playerObject.SetActive(true);
        moveParticle.SetActive(false);
        camera.SetActive(true);
        levelsUI.SetActive(false);
        inGameUI.SetActive(true);
        mainScene.SetActive(false);
        playerTransform.position = playerDefaultPos;
        cameraTransform.position = cameraDefaultPos;
        instantiatedLevel = Instantiate(level2, new Vector2(0, 0), Quaternion.identity);
        StartCoroutine(sceneTransition());
    }
    public void LoadLevel3()
    {
        playerObject.GetComponent<CapsuleCollider2D>().enabled = true;
        playerObject.GetComponent<Rigidbody2D>().gravityScale = 4f;
        playerObject.SetActive(true);
        moveParticle.SetActive(false);
        camera.SetActive(true);
        levelsUI.SetActive(false);
        inGameUI.SetActive(true);
        mainScene.SetActive(false);
        playerTransform.position = playerDefaultPos;
        cameraTransform.position = cameraDefaultPos;
        instantiatedLevel = Instantiate(level3, new Vector2(0, 0), Quaternion.identity);
        StartCoroutine(sceneTransition());
    }
    public void LoadLevel4()
    {
        playerObject.GetComponent<CapsuleCollider2D>().enabled = true;
        playerObject.GetComponent<Rigidbody2D>().gravityScale = 4f;
        playerObject.SetActive(true);
        moveParticle.SetActive(false);
        camera.SetActive(true);
        levelsUI.SetActive(false);
        inGameUI.SetActive(true);
        mainScene.SetActive(false);
        playerTransform.position = playerDefaultPos;
        cameraTransform.position = cameraDefaultPos;
        instantiatedLevel = Instantiate(level4, new Vector2(0, 0), Quaternion.identity);
        StartCoroutine(sceneTransition());
    }
    public void LoadLevel5()
    {
        playerObject.GetComponent<CapsuleCollider2D>().enabled = true;
        playerObject.GetComponent<Rigidbody2D>().gravityScale = 4f;
        playerObject.SetActive(true);
        moveParticle.SetActive(false);
        camera.SetActive(true);
        levelsUI.SetActive(false);
        inGameUI.SetActive(true);
        mainScene.SetActive(false);
        playerTransform.position = playerDefaultPos;
        cameraTransform.position = cameraDefaultPos;
        instantiatedLevel = Instantiate(level5, new Vector2(0, 0), Quaternion.identity);
        StartCoroutine(sceneTransition());
    }
    public void LoadLevel6()
    {
        playerObject.GetComponent<CapsuleCollider2D>().enabled = true;
        playerObject.GetComponent<Rigidbody2D>().gravityScale = 4f;
        playerObject.SetActive(true);
        moveParticle.SetActive(false);
        camera.SetActive(true);
        levelsUI.SetActive(false);
        inGameUI.SetActive(true);
        mainScene.SetActive(false);
        playerTransform.position = playerDefaultPos;
        cameraTransform.position = cameraDefaultPos;
        instantiatedLevel = Instantiate(level6, new Vector2(0, 0), Quaternion.identity);
        StartCoroutine(sceneTransition());
    }

    public void OpenLevels()
    {
        transition.SetTrigger("Returned");
        Time.timeScale = 1;
        playerObject.SetActive(false);
        camera.SetActive(false);
        playerTransform.position = playerDefaultPos;
        cameraTransform.position = cameraDefaultPos;
        endLevelUI.SetActive(false);
        levelsUI.SetActive(true);
        mainScene.SetActive(true);
        Destroy(instantiatedLevel);

    }
    public void goToMain()
    {
        transition.SetTrigger("Returned");
        playerObject.SetActive(false);
        camera.SetActive(false);
        Time.timeScale = 1;
        playerTransform.position = playerDefaultPos;
        cameraTransform.position = cameraDefaultPos;
        mainUI.SetActive(true);
        mainScene.SetActive(true);
        Destroy(instantiatedLevel);
    }
    IEnumerator sceneTransition()
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
    }
}
