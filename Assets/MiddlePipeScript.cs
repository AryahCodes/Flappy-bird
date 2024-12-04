using UnityEngine;

public class MiddlePipeScript : MonoBehaviour
{

    public LogicScript logic;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collide){
        
        if(collide.gameObject.layer == 3){
        logic.addScore(1);
        }
    }

}
