using UnityEngine;

namespace Assets.Scripts.Formations
{
    public class Formation
    {
        public int UnitCount { get; private set; }

        public float Spacing { get; set; }

        
        public Formation(int unitCount)
        {
            UnitCount = unitCount;
        }
        /// <summary>
        /// Get destination for unit at given index
        /// </summary>
        /// <param name="unitIndex">index of unit in selected units</param>
        /// <returns></returns>
        public virtual Vector3 UnitRelativePosition(int unitIndex)
        {
            return new Vector3();
        }
    }
}
