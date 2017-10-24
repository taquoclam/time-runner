using UnityEngine;

namespace Items
{
    // an item that you can pick up
    public abstract class Item : MonoBehaviour
    {
        // item type
        public enum Type
        {
            Weapon
        }
        
        public abstract Type GetType();
    }


}