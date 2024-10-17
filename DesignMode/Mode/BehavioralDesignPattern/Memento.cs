using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignMode.Mode.BehavioralDesignPattern
{
    public class Memento
    {
        private string state;
        public Memento(string state)
        {
            this.state = state;
        }
        public string GetStae()
        {
            return state;
        }
    }
    public class Originator
    {
        private string state;
        public void SetState(string state)
        {
            this.state = state;
        }
        public string GetState()
        {
            return state;
        }

        public Memento SaveStateToMemento()
        {
            return new Memento(state);
        }
        
        public void GetStateFromMemento(Memento memento)
        {
            state = memento.GetStae();
        }
    }
    public class Caretaker
    {
        private readonly List<Memento> list = new List<Memento>();

        public void Add(Memento memento)
        {
            list.Add(memento);
        }
        public Memento Get(int index)
        {
            return list[index];
        }
    }
    public class MementoMode
    {
        public void Create()
        {
            Originator originator = new Originator();
            Caretaker caretaker = new Caretaker();

            originator.SetState("State 1");
            caretaker.Add(originator.SaveStateToMemento());

            originator.SetState("State 2");
            caretaker.Add(originator.SaveStateToMemento());

            originator.SetState("State 3");
            Console.WriteLine("Current State: " + originator.GetState());

            originator.GetStateFromMemento(caretaker.Get(1));
            Console.WriteLine("Restored State: " + originator.GetState());
        }
    }
}
