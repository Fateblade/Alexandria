﻿namespace Alexandrian.Base.Models
{
    public class Plane : BaseObject
    {
        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { SetProperty(ref _Name, value); }
        }

        private string _Features;
        public string Features
        {
            get { return _Features; }
            set { SetProperty(ref _Features, value); }
        }

        private string _Description;
        public string Description
        {
            get { return _Description; }
            set { SetProperty(ref _Description, value); }
        }
    }
}