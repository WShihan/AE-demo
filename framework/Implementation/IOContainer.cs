using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using framework.Interface;

namespace framework.Implementation
{
    public class IOContainer:IIOContainer
    {
        private static  IOContainer IOC;
        private Hashtable IocTable;
        private IOContainer()
        {
            IocTable =  new Hashtable();
        }
        public static IOContainer InStance
        {
            get
            {
                if (IOC == null)
                {
                    IOC = new IOContainer();
                }
                return IOC;
            }
        }
        public void Register<T, U>()
        {
            IocTable.Add(typeof(T), typeof(U));
        }
        public T Create<T>()
        {
            var typeOfImpl = (Type)IocTable[typeof(T)];
            if (typeOfImpl == null)
            {
                throw new ApplicationException($"Failed to resolve {typeof(T).Name}");
            }
            return (T)Activator.CreateInstance(typeOfImpl);
        }
        public T Resolve<T>()
        {
            var ctor = ((Type)IocTable[typeof(T)]).GetConstructors()[0];
            //var ctor = ((Type)IocTable[typeof(T)]).GetProperty("Instance");
            var dep = ctor.GetParameters()[0].ParameterType;
            var mi = typeof(IOContainer).GetMethod("Create");
            var gm = mi.MakeGenericMethod(dep);
            return (T)ctor.Invoke(new object[] { gm.Invoke(this, null) });
        }

    }
}
