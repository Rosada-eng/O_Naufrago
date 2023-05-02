using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightcontroller : MonoBehaviour {

    private UnityEngine.Rendering.Universal.Light2D light2D;
       public float cycleDuration = 40f; // duration of the day/night cycle in seconds
    public float dayDurationRatio = 0.375f; // ratio of the cycle duration that is full day
    public float sunriseDurationRatio = 0.125f; // ratio of the cycle duration that is sunrise transition
    public float sunsetDurationRatio = 0.125f; // ratio of the cycle duration that is sunset transition
    public float nightDurationRatio = 0.375f; // ratio of the cycle duration that is full night

    private float currentIntensity; // current intensity of the lights
    private float timeSinceCycleStart; // time elapsed since the start of the current cycle
    public bool isDay = true;
    private void Start() {
        light2D = GetComponent<UnityEngine.Rendering.Universal.Light2D>();
        currentIntensity = 1f; // initialize current intensity to 1.0f
        timeSinceCycleStart = 0f; // initialize time elapsed to 0f
    }

    private void Update() {
        // increment the time elapsed since the start of the current cycle
        timeSinceCycleStart += Time.deltaTime;

        // calculate the current time of day (in decimal form)
        float timeOfDay = timeSinceCycleStart / cycleDuration;
        timeOfDay %= 1f;

        // calculate the duration of each phase of the day/night cycle
        float dayDuration = cycleDuration * dayDurationRatio;
        float sunriseDuration = cycleDuration * sunriseDurationRatio;
        float sunsetDuration = cycleDuration * sunsetDurationRatio;
        float nightDuration = cycleDuration * nightDurationRatio;

        // calculate the target intensity for the lights based on the time of day
        float targetIntensity;
        if (timeOfDay < sunriseDuration / cycleDuration || timeOfDay >= (1f - sunsetDuration / cycleDuration)) {
            // full day
            isDay = true;
            float dayProgress = (timeOfDay < sunriseDuration / cycleDuration) ? (timeOfDay / (sunriseDuration / cycleDuration)) : ((timeOfDay - (1f - sunsetDuration / cycleDuration)) / (sunsetDuration / cycleDuration));
            targetIntensity = Mathf.Lerp(0.25f, 1f, dayProgress);
        } else if (timeOfDay >= sunriseDuration / cycleDuration && timeOfDay < (sunriseDuration + sunsetDuration) / cycleDuration) {
            // sunrise transition
            isDay = true;
            float transitionProgress = (timeOfDay - sunriseDuration / cycleDuration) / (sunsetDuration / cycleDuration);
            targetIntensity = Mathf.Lerp(0.25f, 1f, transitionProgress);
        } else if (timeOfDay >= (1f - sunsetDuration / cycleDuration) && timeOfDay < 1f) {
            // sunset transition
            isDay = false;
            float transitionProgress = (timeOfDay - (1f - sunsetDuration / cycleDuration)) / (sunsetDuration / cycleDuration);
            targetIntensity = Mathf.Lerp(1f, 0.25f, transitionProgress);
        } else {
            // full night
            isDay = false;
            float nightProgress = ((timeOfDay - (sunriseDuration + sunsetDuration) / cycleDuration) / (nightDuration / cycleDuration));
            targetIntensity = Mathf.Lerp(1f, 0.25f, nightProgress);
        }

        // smoothly transition the intensity of the lights
        currentIntensity = Mathf.MoveTowards(currentIntensity, targetIntensity, (1f / cycleDuration) * Time.deltaTime);


        // set the intensity of the lights
        light2D.color =  new Color(currentIntensity, currentIntensity, 0.6f) ;
    }
}