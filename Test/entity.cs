using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test
{
    public class entity
    {
        private string _name;
        private string _home;
        private string _gender;
        private int _age;
        private int _grade;
        private int _class;
        public entity(string name, string home, string gender, int age, int grade, int cls)
        {
            _name = name;
            _home = home;
            _gender = gender;
            _age = age;
            _grade = grade;
            _class = cls;
        }
        public string Name { get { return _name; } }
        public string Home { get { return _home; } }
        public string Gender { get { return _gender; } }
        public int Grade { get { return _grade; } }
        public int Age { get { return _age; } }
        public int Cls { get { return _class; } }

    }
}
