﻿using System;

namespace WormNat2
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 10)
                return;
            WormNat prg = new WormNat(args[0], args[1], args[2], args[3], args[4], args[5], args[6], args[7], args[8], args[9]);
            prg.Start();
        }
    }
}
