using System.Collections.Generic;
using System.Linq;

namespace Lift
{
    public class LiftSystem
    {
        public List<int> Floors { get; }
        public List<Lift> Lifts { get; }
        public List<Call> Calls { get; }

        public LiftSystem(List<int> floors, List<Lift> lifts, List<Call> calls)
        {
            Floors = floors;
            Lifts = lifts;
            Calls = calls;
        }

        public List<int> FloorsInDescendingOrder()
        {
            var copy = new List<int>(Floors);
            copy.Reverse();
            return copy;
        }

        public IEnumerable<Call> CallsForFloor(int floor)
        {
            return Calls.Where(c => c.Floor == floor);
        }

        public void Tick()
        {
            if (((Calls == null) || Calls.Count < 1))
            {
                return;
            }
            Lift elevator = new Lift(Lifts[0].Id, Lifts[0].Floor, doorsOpen: true);
            Lifts.Remove(Lifts[0]);
            Lifts.Add(elevator);
            Calls.Remove(Calls[0]);
        }
    }
}