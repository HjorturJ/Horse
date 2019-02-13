using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseMovement : MonoBehaviour {

    public float buttonPower = -300f;

    public Rigidbody2D FrontFrontLeg;
    public Rigidbody2D FrontBackLeg;
    public Rigidbody2D BackFrontLeg;
    public Rigidbody2D BackBackLeg;

    public Rigidbody2D FrontFrontLegLower;
    public Rigidbody2D FrontBackLegLower;
    public Rigidbody2D BackFrontLegLower;
    public Rigidbody2D BackBackLegLower;

    private Rigidbody2D body;

    private float firstTimer;
    private float secondTimer;
    private float thirdTimer;
    private float fourthTimer;
    private float fifthTimer;
    private float sixthTimer;

    private bool isFirstRunning;
    private bool isSecondRunning;
    private bool isThirdRunning;
    private bool isFourthRunning;
    private bool isFifthRunning;
    private bool isSixthRunning;

    private bool rhythm;

    void Start() {
        body = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {
        if (firstTimer > 0.2f || secondTimer > 0.2f || thirdTimer > 0.2f ||
            fourthTimer > 0.2f || fifthTimer > 0.2f || sixthTimer > 0.2f) {

            resetTimers();
        }

        if (isFirstRunning) firstTimer += Time.deltaTime;
        if (isSecondRunning) secondTimer += Time.deltaTime;
        if (isThirdRunning) thirdTimer += Time.deltaTime;

        if (isFourthRunning) fourthTimer += Time.deltaTime;
        if (isFifthRunning) fifthTimer += Time.deltaTime;
        if (isSixthRunning) sixthTimer += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.L)) isFirstRunning = true;

        if (Input.GetKeyDown(KeyCode.A)) isFourthRunning = true;

        if (Input.GetKeyDown(KeyCode.K) && isFirstRunning)  isSecondRunning = true;

        if (Input.GetKeyDown(KeyCode.S) && isFourthRunning) isFifthRunning = true;

        if (Input.GetKeyDown(KeyCode.J) && isSecondRunning) isThirdRunning = true;

        if (Input.GetKeyDown(KeyCode.D) && isFifthRunning)  isSixthRunning = true;

        if (isFirstRunning && isThirdRunning && !isSecondRunning) resetTimers();
        if (isFourthRunning && isSixthRunning && !isFifthRunning) resetTimers();

        //If you press the buttons on the same frame you are spamming
        if (Input.GetKeyDown(KeyCode.L) && (Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))) resetTimers();

        if (Input.GetKeyDown(KeyCode.A) && (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.J))) resetTimers();


        if (isThirdRunning && isSixthRunning) {
            //Probbly want to test having a timer here that keeps the rythm bool active for a tiny amount of time and keeps it going for some player wiggle room
            //maybe not, depends on what you make rythm do

            rhythm = true;
            StartCoroutine(RhythmFalloff());

            Debug.Log("Rythm!");
            
        }

        if(rhythm) {
            body.constraints = RigidbodyConstraints2D.FreezeRotation;
            body.AddForce(new Vector2(5f, 0.2f) * 100, ForceMode2D.Force);
            FrontFrontLeg.AddTorque(buttonPower, ForceMode2D.Force);
            FrontBackLeg.AddTorque(buttonPower, ForceMode2D.Force);
            BackFrontLeg.AddTorque(buttonPower, ForceMode2D.Force);
            BackBackLeg.AddTorque(buttonPower, ForceMode2D.Force);
        }
        else {
            if (Input.GetKeyDown(KeyCode.L))
                FrontFrontLeg.AddTorque(buttonPower * 0.1f, ForceMode2D.Impulse);

            if (Input.GetKeyDown(KeyCode.K))
                FrontBackLeg.AddTorque(buttonPower *0.1f, ForceMode2D.Impulse);

            if (Input.GetKeyDown(KeyCode.J)) {
                FrontFrontLegLower.AddTorque(100f, ForceMode2D.Impulse);
                FrontBackLegLower.AddTorque(100f, ForceMode2D.Impulse);
            }
                

            if (Input.GetKeyDown(KeyCode.A))
                BackFrontLeg.AddTorque(buttonPower * 0.1f, ForceMode2D.Impulse);

            if (Input.GetKeyDown(KeyCode.S))
                BackBackLeg.AddTorque(buttonPower * 0.1f, ForceMode2D.Impulse);

            if (Input.GetKeyDown(KeyCode.D)) {
                BackFrontLegLower.AddTorque(100f, ForceMode2D.Impulse);
                BackBackLegLower.AddTorque(100f, ForceMode2D.Impulse);
            }

        }




        //Tests
        //If you are in rythm, freeze rotation Z on the body rigidbody and add v2 right force and slight upward force and spin legs a lot
        //Otherwise, apply standard force to each leg sepratly and let the horse flop around
        if (Input.GetKey(KeyCode.H)) {
            body.AddForce(new Vector2(1f, 0.2f) * 100, ForceMode2D.Force);
            //rb.AddForce(Vector2.right * 500, ForceMode2D.Force);
            FrontFrontLeg.AddTorque(buttonPower, ForceMode2D.Force);
            FrontBackLeg.AddTorque(buttonPower, ForceMode2D.Force);

            BackFrontLeg.AddTorque(buttonPower, ForceMode2D.Force);
            BackBackLeg.AddTorque(buttonPower, ForceMode2D.Force);
        }
    }

    private void resetTimers() {
        firstTimer = secondTimer = thirdTimer = fourthTimer = fifthTimer = sixthTimer = 0f;
        isFirstRunning = isSecondRunning = isThirdRunning = isFourthRunning = isFifthRunning = isSixthRunning = false;
    }

    private IEnumerator RhythmFalloff() {

        yield return new WaitForSeconds(0.2f);
        if(!isThirdRunning && !isSixthRunning)
            rhythm = false;
    }
}
