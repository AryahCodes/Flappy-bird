using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    
    public int score;
    public Text scoreText;
    public GameObject gameOverScreen;

    public bool isGameOver = false; 


    //Make it public so other classes can use this method;
    public void addScore(int scoreToadd){
        score += scoreToadd;
        scoreText.text = score.ToString();
    }

    public void restart(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver(){
        gameOverScreen.SetActive(true);
        isGameOver = true;
    }

}
