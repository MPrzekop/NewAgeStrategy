using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Formations
{
    class FullSquareFormation:Formation
    {
        private int _width, _height;
        public FullSquareFormation(int unitCount) : base(unitCount)
        {
            _width = (int)Mathf.Sqrt(unitCount);
            Spacing = 3f;
        }

        public override Vector3 UnitRelativePosition(int unitIndex)
        {
            return new Vector3(unitIndex % _width, 0, -(float)_height / 2+unitIndex/_width) * Spacing;
            return base.UnitRelativePosition(unitIndex);
        }
    }
}
