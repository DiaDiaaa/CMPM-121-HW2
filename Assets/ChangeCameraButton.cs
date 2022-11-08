using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class ChangeCameraButton : MonoBehaviour
{
    // create camera list that can be updated in the inspector
    public List<Camera> Cameras;
    public List<GameObject> Lights;
    // create frame and button variables 
    private VisualElement frame;
    private Button button;
    private Button lightbutton;

    // This function is called when the object becomes enabled and active.
    void OnEnable()
    {
        // get the UIDocument component (make sure this name matches!)
        var uiDocument = GetComponent<UIDocument>();
        // get the rootVisualElement (the frame component)
        var rootVisualElement = uiDocument.rootVisualElement;
        frame = rootVisualElement.Q<VisualElement>("Frame");
        // get the button, which is nested in the frame
        button = frame.Q<Button>("Button");
        lightbutton = frame.Q<Button>("Button1");
        // create event listener that calls ChangeCamera() when pressed
        button.RegisterCallback<ClickEvent>(ev => ChangeCamera());
        lightbutton.RegisterCallback<ClickEvent>(ev => ChangeLight());
    }

    // initialize click count
    int click = 0;
    int lightclick = 0;
    private void ChangeCamera(){
        EnableCamera(click);
        click++;
        // reset counter so it is not out of bounds (only have 4 cameras)
        if(click > Cameras.Count-1){
            click = 0;
        }
    }

    private void EnableCamera(int n)
    {
        // disable each of the cameras
        Cameras.ForEach(cam => cam.enabled = false);
        // Cameras.ForEach(cam => cam.depth = 0);

        // enable the selected camera
        Cameras[n].enabled = true;
        // Cameras[n].depth = 1;

    }
    private void ChangeLight(){
        
        lightclick++;
        EnableLight(lightclick);
        // reset counter so it is not out of bounds (only have 4 cameras)
        if(lightclick > 2){
            lightclick = 0;
        }
    }

    private void EnableLight(int n)
    {
        if(n == 1){
            Lights.ForEach(lit => lit.SetActive(true));
        }else if(n == 2){
            Lights[0].SetActive(false);
        }else{
            Lights.ForEach(lit => lit.SetActive(false));
        }
        // // disable each of the cameras
        // Cameras.ForEach(cam => cam.enabled = false);
        // // Cameras.ForEach(cam => cam.depth = 0);

        // // enable the selected camera
        // Cameras[n].enabled = true;
        // // Cameras[n].depth = 1;

    }

    
    
}
