using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Formations
{
    public class SquareFormation:Formation
    {
        private int _width, _height;
        
        public SquareFormation(int unitCount) : base(unitCount)
        {
            _width = (unitCount-4 )/ 4+2;
            _height = (unitCount - _width*2-4)/2;
           
            Spacing = 3f;
        }

        public override Vector3 UnitRelativePosition(int unitIndex)
        {
            if (unitIndex < _width)
            {
                return new Vector3(unitIndex % _width, 0, -(float) _height / 2) * Spacing;
            }
            else if (unitIndex >= UnitCount - _width)
            {
                return new Vector3(unitIndex % _width, 0, +(float) _height / 2 + 3) * Spacing;
            }
            else
            {
                return new Vector3( (unitIndex - _width+1) % 2 *( _width-1)
                    , 0
                    , -(float)_height / 2+(float)(unitIndex-_width)/2+1) * Spacing;
            }
            return new Vector3(-100, 0, 0) * Spacing;
        }
    }
}
