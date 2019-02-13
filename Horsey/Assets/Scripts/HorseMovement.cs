using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorseMovement : MonoBehaviour {
    public Rigidbody2D FrontFrontLeg;
    public Rigidbody2D FrontBackLeg;
    public Rigidbody2D BackFrontLeg;
    public Rigidbody2D BackBackLeg;

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

    void Start() {
    }

    void Update() {
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
            Debug.Log("Rythm!");
        }


        //Tests
        if (Input.GetKey(KeyCode.R)) {
            var power = -300f;
            //rb.AddForce(Vector2.right * 500, ForceMode2D.Force);
            FrontFrontLeg.AddTorque(power, ForceMode2D.Force);
            FrontBackLeg.AddTorque(power, ForceMode2D.Force);
            BackFrontLeg.AddTorque(power, ForceMode2D.Force);
            BackBackLeg.AddTorque(power, ForceMode2D.Force);
        }
    }

    private void resetTimers() {
        firstTimer = secondTimer = thirdTimer = fourthTimer = fifthTimer = sixthTimer = 0f;
        isFirstRunning = isSecondRunning = isThirdRunning = isFourthRunning = isFifthRunning = isSixthRunning = false;
    }
}
