using System.Collections.Generic;
using MarsApplication;
using Xunit;

public class TestClass
{   
    [Fact]
    public void PassingFirstTest(){
        List<int> maxSize = new List<int>();
            maxSize.Add(5); 
            maxSize.Add(5);
            Rover firstRover = new Rover(maxSize);
            firstRover.setRoversPosition(1, 2, 1);
            firstRover.actionCommands("LMLMLMLMM");
            string firstPosition = firstRover.getRoversPosition();
            Assert.Equal("1 3 N", firstPosition);

            Rover secondRover = new Rover(maxSize);
            secondRover. setRoversPosition(3, 3, 2);
            secondRover.actionCommands("MMRMMRMRRM");
            string secondPosition = secondRover.getRoversPosition();
            Assert.Equal("5 1 E", secondPosition);

    }
}