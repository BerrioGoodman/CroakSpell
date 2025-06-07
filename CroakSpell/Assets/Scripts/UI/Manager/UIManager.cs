using System.Collections.Generic;
using UnityEngine;
using System;

//Controla los tipos de UI que existen en el juego.
public enum UIType
{
    Screen, //Menus
    Popup,  //Ventanas modales
    Overlay //HUDs 
}

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }


    //registro de pantallas desde el editor
    [Serializable]
    public class UIEntry
    {
        public UIType type;
        public UIModel model;
    }

    [Header("UI Prefabs")] 
    [SerializeField] private List<UIEntry> uiPrefabs;

    private Dictionary<Type, UIModel> uiInstances = new(); //Instancias
    private Dictionary<UIType, UIModel> activeByType = new(); //UI activa actual

    private void Awake()
    {
        //Singleton
        if (Instance != null) 
        {
            Destroy(this);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);// Mantener el UIManager entre escenas

        //Instanciar todas las pantllas
        foreach (var entry in uiPrefabs)
        {
            var model = Instantiate(entry.model, transform);
            // Guardar la instancia en el diccionario obtenido del tipo de modelo como su llave
            uiInstances[model.GetType()] = model;
            model.gameObject.SetActive(false); // Desactivar el modelo al inicio
        }
    }

    public T ShowUI<T>(UIType type = UIType.Screen) where T : UIModel
    {
        var modelType = typeof(T);

        if (!uiInstances.TryGetValue(modelType, out var model))
        {
            Debug.Log($"UI Manager: No se encontró UI del tipo {modelType}");
            return null;
        }

        // Si no es Overlay oculta la ui anterior del mismo tipo
        if (type != UIType.Overlay)
        {
            if (activeByType.TryGetValue(type, out var active)) 
            {
                active.gameObject.SetActive(false);
            }

            activeByType[type] = model;
        }

        model.gameObject.SetActive(true); // Activar el modelo
        return model as T; // Retornar el modelo como tipo T
    }

    public void HideUI<T>() where T : UIModel
    {
        Type modelType = typeof(T);

        if (uiInstances.TryGetValue(modelType, out var model)) //intenta obtener el modelo y guardarlo en model
        {
            model.gameObject.SetActive(false);

            foreach (var kvp in activeByType) 
            {
                if (kvp.Value == model) 
                {
                    activeByType.Remove(kvp.Key); // Elimina la UI del diccionario de UI activas
                    break; // Salir del bucle una vez que se ha eliminado
                }
            }
        }
    }

    public void HideAllOfType(UIType type) 
    {
        if (activeByType.TryGetValue(type, out var model)) 
        {
            model.gameObject.SetActive(false);
            activeByType.Remove(type); // Elimina la UI del diccionario de UI activas
        }
    }

    public void HideAll() 
    {
        foreach (var model in uiInstances.Values)
        {
            model.gameObject.SetActive(false);
        }
        activeByType.Clear(); // Limpiar el diccionario de UI activas
    }
}
