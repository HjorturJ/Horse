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

    private float maxTime = 0.3f;

    void Start() {
        body = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {
        if (firstTimer > maxTime || secondTimer > maxTime || thirdTimer > maxTime ||
            fourthTimer > maxTime || fifthTimer > maxTime || sixthTimer > maxTime) {

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

        if (Input.GetKeyDown(KeyCode.L) && (Input.GetKeyDown(KeyCode.J) || Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))) resetTimers();

        if (Input.GetKeyDown(KeyCode.A) && (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.K) || Input.GetKeyDown(KeyCode.J))) resetTimers();


        if (isThirdRunning && isSixthRunning) {
            rhythm = true;
            StartCoroutine(RhythmFalloff());
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
                FrontFrontLegLower.AddTorque(-50f, ForceMode2D.Impulse);
                FrontBackLegLower.AddTorque(-50f, ForceMode2D.Impulse);
            }
                

            if (Input.GetKeyDown(KeyCode.A))
                BackFrontLeg.AddTorque(buttonPower * 0.1f, ForceMode2D.Impulse);

            if (Input.GetKeyDown(KeyCode.S))
                BackBackLeg.AddTorque(buttonPower * 0.1f, ForceMode2D.Impulse);

            if (Input.GetKeyDown(KeyCode.D)) {
                BackFrontLegLower.AddTorque(-50f, ForceMode2D.Impulse);
                BackBackLegLower.AddTorque(-50f, ForceMode2D.Impulse);
            }

        }
    }

    private void resetTimers() {
        firstTimer = secondTimer = thirdTimer = fourthTimer = fifthTimer = sixthTimer = 0f;
        isFirstRunning = isSecondRunning = isThirdRunning = isFourthRunning = isFifthRunning = isSixthRunning = false;
        body.constraints = RigidbodyConstraints2D.None;
    }

    private IEnumerator RhythmFalloff() {
        yield return new WaitForSeconds(0.5f);
        if (!isThirdRunning && !isSixthRunning)
            rhythm = false;
    }
}
