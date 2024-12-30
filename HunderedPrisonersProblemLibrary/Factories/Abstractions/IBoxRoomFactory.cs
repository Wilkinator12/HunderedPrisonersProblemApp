using HunderedPrisonersProblemLibrary.Models;

namespace HunderedPrisonersProblemLibrary.Factories.Abstractions
{
    public interface IBoxRoomFactory
    {
        BoxRoom CreateBoxRoom(int numberOfBoxes);
    }
}
