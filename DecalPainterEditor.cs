using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

[CustomEditor(typeof(DecalPainter))]
public class DecalPainterEditor : Editor {
    private DecalPainter _target;
    public Color color;

    public GameObject go;
    public Material mat;

    private void OnEnable()
    {
        _target = (DecalPainter)target;
        color = new Color();

    }

    void OnSceneGUI()
    {
        //si se clikea el mouse 
        if (Event.current.type == EventType.MouseDown)
        {

            Debug.Log("sas");
            if (SceneView.lastActiveSceneView.camera != null)
            {
                RaycastHit hit;
                Ray ray = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);
                if (Physics.Raycast(ray, out hit, 1000))
                {
                    //sacamos la pocicion del raycast contra que choco 
                    _target.hitQ = Quaternion.FromToRotation(Vector3.forward, hit.normal);
                    _target.position = new Vector3(hit.point.x + 0.1f, hit.point.y + 0.1f, hit.point.z + 0.1f);
                    Debug.Log(_target.position);

                    //instanciamos el objeto en la posicion que qeremos mirando para las normales del obj
                    // contra el que choco el rayvast
                    var rd = _target.sprite.GetComponent<Renderer>();

                    if (_target.random == true)
                    {
                        _target.GetRandomValue();
                       // RotateBrush(Instantiate(_target.sprite, hit.point + (hit.normal * 0.001f), Quaternion.LookRotation(hit.normal)));
                    }
                    else
                    {
                        Instantiate(_target.sprite, hit.point + (hit.normal * 0.001f), Quaternion.LookRotation(hit.normal));
                    }
                   
                   
                    Repaint();

                }
            }
        }
    }
}
