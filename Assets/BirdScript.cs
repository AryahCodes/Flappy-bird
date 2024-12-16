using UnityEngine;

public class BirdScript : MonoBehaviour{


    private float deadsZone = -7;


    // This is a change to github. 
    
    //We need to create a rigidbody2d so we can talk to it in the inspecter.
    public Rigidbody2D myrigidbody2d;
    public LogicScript logic;
    public bool birdIsAlive = true;    
    //When we make this float variable we can see this in unity and change it from there so we don't have 
    //to come back here everytime.
    public float flapHeight;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();

    }
    // Update is called once per frame
    void Update(){
        //Now to create the bird going up we have to look at its velocity. 
        //Velocity is a vector (?,?) since its 2d.
        //Since we want it to just go up we should have the x as 0 and y as 1. Vector2 is builtin and does that.
        //Vector2.up represents a unit vector pointing upwards (0, 1) in 2D space.
        //Since this one line of code happens every frame the bird will just fly upwards. We want it every time a spacebar is hit.
        //myrigidbody2d.velocity = Vector2.up * 10;
        //Here getKeyDown is a fucntion builtin with input that checks if a key is pressed down. 
        //In the bracet it means the Spacebar key on the keyboard
        //KeyCode means every key on the board
        //KeyCode.Space means just looking for the spacebar. 
        //We don't need to multiply this by Time.deltaTime to make everyones game go at the same time since 
        //physics runs on its own clock. Otherwise we need it.
        if(Input.GetKeyDown(KeyCode.Space) && birdIsAlive){
            myrigidbody2d.linearVelocity = Vector2.up * flapHeight;
        }

        if(transform.position.y < deadsZone){

            //The Destroy lets us easily destroy the object thats running this.    
            Destroy(gameObject);
            logic.gameOver();
            birdIsAlive = false;
        }

    }
    private void OnCollisionEnter2D(Collision2D collision){
            GameObject pipeParent = collision.transform.parent.gameObject;
            PipeScriptMove pipeScript = pipeParent.GetComponent<PipeScriptMove>();
            Debug.Log("Collision detected with: " + collision.gameObject.name);

            if(pipeScript != null){
                pipeScript.StopMovement();
                Debug.Log("Pipe hit! Stopping movement.");
            }
            logic.gameOver();
            birdIsAlive = false;

    }
}
