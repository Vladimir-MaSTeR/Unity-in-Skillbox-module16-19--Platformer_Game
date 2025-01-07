using UnityEngine;
public class ElevatorPlatform : MonoBehaviour {

    [SerializeField] private SliderJoint2D slider;

    private void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log("Лифт задел тригер");

        if(slider.motor.motorSpeed == 2) {
            var newMotor = slider.motor;
            newMotor.motorSpeed = -2;

            slider.motor = newMotor;
        } else {
            var newMotor = slider.motor;
            newMotor.motorSpeed = 2;

            slider.motor = newMotor;
        }
    }
}
