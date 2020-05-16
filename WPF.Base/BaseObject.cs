using System;
using System.Collections.Generic;
using System.Linq;
using Fateblade.Alexandria.UI.WPF.Base.Interfaces;

namespace Fateblade.Alexandria.UI.WPF.Base
{
    public abstract class BaseObject : Prism.Mvvm.BindableBase, IAttachable<Note>, IAttachable<Tag>, IAttachable<Link>, IAttachable<Influence>, IAttachable<ToDo>, IDataEntity
    {
        protected Guid _Id;
        protected List<Note> _notes;
        protected List<Tag> _tags;
        protected List<Link> _links;
        protected List<Influence> _influences;
        protected List<ToDo> _todos;


        public Guid ID { get { return Id; } }

        List<Note> IAttachable<Note>.Attached { get { return ((IAttachable<Note>)this).GetList().ToList(); } }

        List<Tag> IAttachable<Tag>.Attached { get { return ((IAttachable<Tag>)this).GetList().ToList(); } }

        List<Influence> IAttachable<Influence>.Attached { get { return ((IAttachable<Influence>)this).GetList().ToList(); } }

        List<ToDo> IAttachable<ToDo>.Attached { get { return ((IAttachable<ToDo>)this).GetList().ToList(); } }

        List<Link> IAttachable<Link>.Attached { get { return ((IAttachable<Link>)this).GetList().ToList(); } }


        public BaseObject(Guid guid) : base()
        {
            _notes = new List<Note>();
            _tags = new List<Tag>();
            _links = new List<Link>();
            Id = guid;
        }
        public BaseObject() : this(Guid.NewGuid()) { }


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

        void IAttachable<Influence>.Add(Influence element)
        {
            if (element == null) { throw new ArgumentNullException(); }
            _influences.Remove(element);
        }

        void IAttachable<ToDo>.Add(ToDo element)
        {
            if (element == null) { throw new ArgumentNullException(); }
            _todos.Add(element);
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

        IEnumerable<Influence> IAttachable<Influence>.GetList()
        {
            return _influences.ToList();
        }

        IEnumerable<ToDo> IAttachable<ToDo>.GetList()
        {
            return _todos.ToList();
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

        void IAttachable<Influence>.Remove(Influence element)
        {
            if (element == null) { throw new ArgumentNullException(); }
            _influences.Remove(element);
        }
        
        void IAttachable<ToDo>.Remove(ToDo element)
        {
            if (element == null) { throw new ArgumentNullException(); }
            _todos.Remove(element);
        }
    }
}
