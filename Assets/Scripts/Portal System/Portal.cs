using System.Collections;
using UnityEngine;
using RogueLike.Chatacters_Movement;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(BoxCollider))]
public class Portal : MonoBehaviour
{
    [SerializeField] private int sceneID;


    private void OnTriggerEnter(Collider other)
    {
        CharacterMovement characterMovement;

        if (other.gameObject.TryGetComponent<CharacterMovement>(out characterMovement))
        {
            StartCoroutine(LoadAsyncScene());
        }
    }


    IEnumerator LoadAsyncScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneID);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
