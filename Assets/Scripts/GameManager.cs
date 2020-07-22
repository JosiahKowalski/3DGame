using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    private bool _gameHasEnded;

    public float collisionDelay = 1f;
    public float fallingDelay = 1f;

    [FormerlySerializedAs("completeLevelUI")] public GameObject completeLevelUi;

    public void CompleteLevel()
    {
        completeLevelUi.SetActive(true);
    }
    public void EndGame(string fall)
    {
        if (_gameHasEnded) return;
        Debug.Log("game over");
        _gameHasEnded = true;
        Invoke(nameof(Restart), fallingDelay);

    }
    public void EndGame()
    {
        if (_gameHasEnded == false)
        {
            Debug.Log("game over");
            _gameHasEnded = true;
            Invoke(nameof(Restart), collisionDelay);
        }
    }

    private void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
