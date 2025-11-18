using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VGP133_A2_Karlsson_Vincent
{
    internal class Motorway
    {
        private string _motorwayName;
        private char _direction;
        private int _lanesCount;
        private bool _isToll;

        static private string s_maintainerName = string.Empty;

        public string MotorwayName { get { return _motorwayName; } }
        public char Direction { get { return _direction; } set { _direction = value; } }
        public int LanesCount
        {
            get { return _lanesCount; }
            set
            {
                if (value <= 0)
                {
                    _lanesCount = 1;
                }
                else
                {
                    _lanesCount = value;
                }
            }
        }
        public bool IsToll { get { return _isToll; } set { _isToll = value; } }
        public string MaintainerName { get { return s_maintainerName; } set { s_maintainerName = value; } }

        public Motorway(string motorwayName)
        {
            _motorwayName = motorwayName;
            LanesCount = 2;
            _isToll = false;

            s_maintainerName = "The Family";
        }

        public Motorway(string motorwayName, char direction, int lanesCount, bool isToll, string maintainerName)
        {
            _motorwayName = motorwayName;
            _direction = direction;
            LanesCount = lanesCount;
            _isToll = isToll;
            s_maintainerName = maintainerName;
        }

        public string GetDirectionName()
        {
            string direction = "";

            switch (_direction)
            {
                case 'n':
                    direction = "North ";
                    break;
                case 's':
                    direction = "South ";
                    break;
                case 'e':
                    direction = "East ";
                    break;
                case 'w':
                    direction = "West ";
                    break;
                default:
                    break;
            }

            return direction + _motorwayName;
        }

        public string IsTollRoad()
        {
            if (_isToll == true)
            {
                return "Toll Road";
            }
            else
            {
                return "Toll Free";
            }

        }
    }
}
