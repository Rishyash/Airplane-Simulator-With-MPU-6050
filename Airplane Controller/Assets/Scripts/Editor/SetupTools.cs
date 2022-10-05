 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor; 

public static class SetupTools 
{   
    public static void CreateDefaultPlane(string Aname,Object DefaultPlane)
    {
        //Create Plane
        GameObject rootGO = new GameObject(Aname, typeof(AirplaneController), typeof(AirplaneInputs));
        GameObject Cog = new GameObject("COG");
        Cog.transform.SetParent(rootGO.transform, false);

        //SetupComponent
        AirplaneInputs inputs = rootGO.GetComponent<AirplaneInputs>();
        AirplaneController controller = rootGO.GetComponent<AirplaneController>();
        AirplaneCharacteristics characteristics = rootGO.GetComponent<AirplaneCharacteristics>();

        if(controller)
        {
            controller.inputs = inputs;
            controller.characteristics = characteristics;
            controller.centerofgravity = Cog.transform;

            //createSurfaces
            GameObject GraphicsGRP = new GameObject("Graphics");
            GameObject CollisionGRP = new GameObject("CollisionGRP");
            GameObject ControlSurfaceGrp = new GameObject("ControlSurfaceGrp");
            GraphicsGRP.transform.SetParent(rootGO.transform, false);
            CollisionGRP.transform.SetParent(rootGO.transform, false);
            ControlSurfaceGrp.transform.SetParent(rootGO.transform, false);

            //CreateEngine
            GameObject EngineGO = new GameObject("Engine",typeof(AirplaneEngine));
            AirplaneEngine engine = EngineGO.GetComponent<AirplaneEngine>();
            controller.engines.Add(engine);
            EngineGO.transform.SetParent  (rootGO.transform, false);

            //CreatePlaneBody

            

            if(DefaultPlane)
            {
                GameObject.Instantiate(DefaultPlane,GraphicsGRP.transform);
            }
            else
            {
                DefaultPlane = (GameObject)AssetDatabase.LoadAssetAtPath("Assets/IndiePixel_Airplanes/Prefabs/IndiePixel_Airplane.prefab", typeof(GameObject));
                GameObject.Instantiate(DefaultPlane, GraphicsGRP.transform);
            }
            

        }
        Selection.activeObject = rootGO;


        /*GameObject CurrentSelected = Selection.activeGameObject;
        if (CurrentSelected)
        {
            AirplaneController curController = CurrentSelected.AddComponent<AirplaneController>();
            GameObject curCOG = new GameObject("COG");
            curCOG.transform.SetParent(CurrentSelected.transform);
            curController.centerofgravity = curCOG.transform;
        }*/
    }
    
}
