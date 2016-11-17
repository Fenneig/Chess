using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    class Position
    {
        int _i;
        int _j;

        public Position(int i, int j)
        {
            _i = i;
            _j = j;
        }

        public Position()
        {
            _i = 0;
            _j = 0;
        }

        public int I
        {
            get { return _i; }
            set { _i = value; }
        }
        public int J
        {
            get { return _j; }
            set { _j = value; }
        }
    }
}
