using UnityEngine;

static class ComponentsCheck
{
    //https://stackoverflow.com/questions/35166730/how-to-check-if-a-game-object-has-a-component-method-in-unity
    public static bool HasComponent<T>(this GameObject obj) => obj.GetComponent<T>() != null;
}