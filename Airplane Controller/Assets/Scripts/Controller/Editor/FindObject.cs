using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;

[CustomEditor(typeof(AirplaneController))]

public class FindObject : Editor
{
    private AirplaneController targetcontroller;
    private void OnEnable()
    {
        targetcontroller = (AirplaneController)target;
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Submit", GUILayout.Height(35)))
        {
            targetcontroller.engines.Clear();
            targetcontroller.engines = FindAllEngines().ToList<AirplaneEngine>();

            targetcontroller.wheels.Clear();
            targetcontroller.wheels = FindAllWheel().ToList<AirplaneWheel>();

            targetcontroller.cSurfaces.Clear();
            //targetcontroller.cSurfaces = FindAllCsurface().ToList<Controlsurfaces>().ToList<Controlsurfaces>();
            targetcontroller.cSurfaces = FindAllCsurface().ToList<Controlsurfaces>();
        }

        if (GUILayout.Button("Create Airplane Preset", GUILayout.Height(35)))
        {
            string filePath = EditorUtility.SaveFilePanel("Save Airplane Preset", "Assets", "New_Airplane Preset", "asset");
            SaveAirplanePreset(filePath);
        }

        #region Custom Methods
        AirplaneEngine[] FindAllEngines()
        {
            AirplaneEngine[] engines = new AirplaneEngine[0];
            if (targetcontroller)
            {
                engines = targetcontroller.transform.GetComponentsInChildren<AirplaneEngine>(true);
            }

            return engines;
        }

        AirplaneWheel[] FindAllWheel()
        {
            AirplaneWheel[] wheel = new AirplaneWheel[0];
            if (targetcontroller)
            {
                wheel = targetcontroller.transform.GetComponentsInChildren<AirplaneWheel>(true);
            }

            return wheel;
        }

        Controlsurfaces[] FindAllCsurface()
        {
            Controlsurfaces[] csurface = new Controlsurfaces[0];
            if (targetcontroller)
            {
                csurface = targetcontroller.transform.GetComponentsInChildren<Controlsurfaces>(true);
            }

            return csurface;
        }

        void SaveAirplanePreset(string apath)
        {
            if( targetcontroller  && !string.IsNullOrEmpty(apath))
            {
                string apppath = Application.dataPath;
                string FinalPath = "Assets" + apath.Substring(apppath.Length);
                Debug.Log(FinalPath);
                AirplanePreset Preset = ScriptableObject.CreateInstance<AirplanePreset>();
                Preset.AirplaneWeight = targetcontroller.AirPlaneweight;
                Preset.Cogposition = targetcontroller.centerofgravity.localPosition;
                Preset.DragFactor = targetcontroller.characteristics.DragFactor;
                Preset.FlapDragFactor = targetcontroller.characteristics.FlapDragFactor;
                Preset.maxkph = targetcontroller.characteristics.maxkph;
                Preset.LerpSpeed = targetcontroller.characteristics.LerpSpeed;
                Preset.Pitchspeed = targetcontroller.characteristics.Pitchspeed;
                Preset.RollSpeed = targetcontroller.characteristics.RollSpeed;
                Preset.YawSpeed = targetcontroller.characteristics.YawSpeed;
                Preset.BankingSpeed = targetcontroller.characteristics.BankingSpeed;
                Preset.Liftmaxpower = targetcontroller.characteristics.Liftmaxpower;
                Preset.liftcurve = targetcontroller.characteristics.liftcurve;
                AssetDatabase.CreateAsset(Preset, FinalPath);
            }
            
        }
        #endregion

    }
}
