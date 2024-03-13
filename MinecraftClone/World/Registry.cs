using OpenTK.Graphics.ES11;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinecraftClone.World {
    internal class Registry<T> {

        List<T> objects = new List<T>();
        Dictionary<string, int> namesToIndices = new Dictionary<string, int>();

        public RegistryObject<SubT> Register<SubT>(string name, SubT obj) where SubT : T {
            // the index in which this object will be stored
            int index = objects.Count;
            objects.Add(obj);
            namesToIndices.Add(name, index);
            return new RegistryObject<SubT>() {
                id = index,
                obj = obj
            };
        }

        public SubT Register2<SubT>(string name, SubT obj) where SubT : T {
            int index = objects.Count;
            objects.Add(obj);
            namesToIndices.Add(name, index);
            return obj;
        }

        public T GetByName(string name) {
            // TODO: What if the name isn't found??
            int index = namesToIndices[name];
            return objects[index];
        }

    }
}
