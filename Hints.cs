using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dofsor {
    public class Hints : IComparable {
        public int n = 0;
        public int x = 0;
        public int y = 0;
        public int d = 0;

        public int CompareTo(object obj) {
            if (obj == null) return 1;
            Hints myHints = obj as Hints;
            if (myHints != null) return n.CompareTo(myHints.n); else throw new ArgumentException("Object is not a hint");
        }
    }

}
