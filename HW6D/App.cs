using System;
using System.Collections.Generic;
using System.Text;

namespace HW6D
{
    class App
    {
        public int x;
        private int y;

        public App()
        {

        }
        public App(int a, int b)
        {
            x = a;
            y = b;
        }


        public void Deconstruct(out int x, out int y)
        {
            x = this.x;
            y = this.y;
        }
    }
}
