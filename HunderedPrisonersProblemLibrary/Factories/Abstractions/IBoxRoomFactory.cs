using HunderedPrisonersProblemLibrary.Models;

namespace HunderedPrisonersProblemLibrary.Factories.Abstractions
{
    public interface IBoxRoomFactory
    {
        BoxRoomModel CreateBoxRoom(int numberOfBoxes);
    }
}
