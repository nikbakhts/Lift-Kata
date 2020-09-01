using System.Collections.Generic;
using ApprovalTests;
using ApprovalTests.Reporters;
using Xunit;

namespace Lift
{
    public class LiftSystemTest
    {
        // TODO: enable this test and finish writing it
        [Fact]
        [UseReporter(typeof(DiffReporter))]
        public void IfNoCallsNoRequest_DoNothing()
        {
            var liftA = new Lift("A", 0);
            var lifts = new LiftSystem(new List<int>() { 0, 1 }, new List<Lift> { liftA }, new List<Call>());
            lifts.Tick();
            Approvals.Verify(new LiftSystemPrinter().Print(lifts));
        }

        [Fact]
        [UseReporter(typeof(DiffReporter))]
        public void IfCallFromSameFloor_AndDoorsClosed_OpenDoors()
        {
            var liftA = new Lift("A", 0);
            var newCall = new Call(0, Direction.Up);
            var callList = new List<Call>();
            callList.Add(newCall);

            var lifts = new LiftSystem(new List<int>() { 0, 1 }, new List<Lift> { liftA }, callList);
            lifts.Tick();
            Approvals.Verify(new LiftSystemPrinter().Print(lifts));
        }

        [Fact]
        [UseReporter(typeof(DiffReporter))]
        public void IfCallFromLowerFloor_AndDoorsClosed_MoveDown()
        {
            var liftA = new Lift("A", 1);
            var newCall = new Call(0, Direction.Up);
            var callList = new List<Call>();
            callList.Add(newCall);

            var lifts = new LiftSystem(new List<int>() { 0, 1 }, new List<Lift> { liftA }, callList);
            lifts.Tick();
            Approvals.Verify(new LiftSystemPrinter().Print(lifts));
        }
    }
}