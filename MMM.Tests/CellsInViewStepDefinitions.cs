using System;
using TechTalk.SpecFlow;

namespace MMM.Tests
{
    [Binding]
    public class CellsInViewStepDefinitions
    {
        [Given(@"the following board")]
        public void GivenTheFollowingBoard(Table table)
        {
            throw new PendingStepException();
        }

        [When(@"my ship is at \((.*)\) facing North")]
        public void WhenMyShipIsAtFacingNorth(Decimal p0)
        {
            throw new PendingStepException();
        }

        [Then(@"the visible cells are")]
        public void ThenTheVisibleCellsAre(Table table)
        {
            throw new PendingStepException();
        }
    }
}
