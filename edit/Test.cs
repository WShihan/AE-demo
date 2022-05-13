using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace app.Test
{
    public class TestMan
    {
        private string _name;
        private string _id;
        private static string _home;
        private int _age;
        public TestMan(string name, int age, string home, string id)
        {
            _age = age;
            _home = home;
            _id = id;
            _name = name;
        }

        public string Name { get { return _name; } }
        public static  string Home { get { return _home; } }
        public string ID { get { return _id; } }
        public int Age { get { return _age; } }
    }
}
