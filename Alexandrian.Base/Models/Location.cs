using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Alexandrian.Base.Interfaces;

namespace Alexandrian.Base.Models
{
    public class Location : BaseObject, IConnectable, IAttachable<Connection>
    {
        private ObservableCollection<Connection> _ConnectedPlaces;
        //public ObservableCollection<Connections> ConnectedPlaces
        //{
        //    get { return _ConnectedPlaces; }
        //    set { SetProperty(ref _ConnectedPlaces, value); }
        //}

        private string _Summary;
        public string Summary
        {
            get { return _Summary; }
            set { SetProperty(ref _Summary, value); }
        }

        private string _Features;
        public string Features
        {
            get { return _Features; }
            set { SetProperty(ref _Features, value); }
        }

        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { SetProperty(ref _Name, value); }
        }

        private string _Description;
        public string Description
        {
            get { return _Description; }
            set { SetProperty(ref _Description, value); }
        }

        public Location()
        {
            _ConnectedPlaces = new ObservableCollection<Connection>();
        }


        public void Add(Connection element)
        {
            if(element == null) { throw new ArgumentException("May not be null", "element"); }
            _ConnectedPlaces.Add(element);
        }

        public void Remove(Connection element)
        {
            if (element == null) { throw new ArgumentException("May not be null", "element"); }
            _ConnectedPlaces.Remove(element);
        }

        public IEnumerable<Connection> GetList()
        {
            return new ObservableCollection<Connection>(_ConnectedPlaces);
        }
    }
}
-