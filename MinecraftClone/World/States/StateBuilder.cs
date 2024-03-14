using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftClone.World.States {

    internal class StateBuilder {
            
        public static int Serialize<T1>(T1 elem1) where T1: struct, Enum {
            int x1 = (int)(object)elem1; // why does this work?
            return x1;
        }

        public static int Serialize<T1, T2>(T1 elem1, T2 elem2) 
            where T1: struct, Enum 
            where T2: struct, Enum
        {
            int n1 = Enum.GetValues<T1>().Length;
            int x1 = (int)(object)elem1;
            int x2 = (int)(object)elem2;
            return x1 * n1 + x2;
        }

        public static int Serialize<T1, T2, T3>(T1 elem1, T2 elem2, T3 elem3)
            where T1 : struct, Enum
            where T2 : struct, Enum
            where T3 : struct, Enum 
        {
            int n1 = Enum.GetValues<T1>().Length;
            int n2 = Enum.GetValues<T2>().Length;
            int x1 = (int)(object)elem1;
            int x2 = (int)(object)elem2;
            int x3 = (int)(object)elem3;
            // TODO: this is probably wrong
            return x1 * n1 * n2 + x2 * n2 + x3;
        }

        public static State Deserialize<T1>(int serialized, Func<T1, State> builder)
            where T1: struct, Enum
        {
            return new EmptyState();
        }

    }
}
