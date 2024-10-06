using Game.PlayerSystem;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "LoadScene", menuName = "Events/LoadScene")]
public class LoadSceneEvent : Event
{
    public string nameOfScene;
    public int idOfScene = -1;
    public override void Main(EventTrigger eventTrigger, Player player)
    {
        if (nameOfScene.Length > 0) SceneManager.LoadScene(nameOfScene);
        if (idOfScene != -1) SceneManager.LoadScene(idOfScene);
        Debug.Log("No scene loaded due to lack of parameters");
    }
}