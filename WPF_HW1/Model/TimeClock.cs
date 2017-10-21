using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_HW1.Model
{
    public class TimeClock : IComparable<TimeClock>
    {
        public int _offset { get; set; }
        public string _name { get; set; }
        public TimeClock() { }
        public TimeClock(int offset, string name)
        {
            _offset = offset;
            _name = name;
        }
        public int CompareTo(TimeClock obj)
        {
            return this._offset.CompareTo(obj._offset);
        }

        public override string ToString()
        {
            if (_offset < 0)
            {
                return "UTC" + _offset + " " + _name;
            }
            else
            {
                return "UTC+" + _offset + " " + _name;
            }
        }
    }

    
}
