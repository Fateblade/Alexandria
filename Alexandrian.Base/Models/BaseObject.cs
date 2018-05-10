using Alexandrian.Base.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Alexandrian.Base.Models
{
    public abstract class BaseObject : Prism.Mvvm.BindableBase, IAttachable<Note>, IAttachable<Tag>, IAttachable<Link>
    {
        protected Guid _ID;
        protected List<Note> _notes;
        protected List<Tag> _tags;
        protected List<Link> _links;

        public BaseObject(): base()
        {
            _notes = new List<Note>();
            _tags = new List<Tag>();
            _links = new List<Link>();
            _ID = Guid.NewGuid();
        }

        void IAttachable<Note>.Add(Note note)
        {
            if(note==null) { throw new ArgumentNullException(); }
            _notes.Add(note);
        }

        void IAttachable<Tag>.Add(Tag tag)
        {
            if (tag == null) { throw new ArgumentNullException(); }
            _tags.Add(tag);
        }

        void IAttachable<Link>.Add(Link element)
        {
            if (element == null) { throw new ArgumentNullException(); }
            _links.Add(element);
        }

        IEnumerable<Note> IAttachable<Note>.GetList()
        {
            return _notes.ToList();
        }

        IEnumerable<Tag> IAttachable<Tag>.GetList()
        {
            return _tags.ToList();
        }

        IEnumerable<Link> IAttachable<Link>.GetList()
        {
            return _links.ToList();
        }

        void IAttachable<Note>.Remove(Note note)
        {
            if (note == null) { throw new ArgumentNullException(); }
            _notes.Remove(note);
        }

        void IAttachable<Tag>.Remove(Tag tag)
        {
            if (tag == null) { throw new ArgumentNullException(); }
            _tags.Remove(tag); 
        }

        void IAttachable<Link>.Remove(Link element)
        {
            if (element == null) { throw new ArgumentNullException(); }
            _links.Remove(element);
        }
    }
}
