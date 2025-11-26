using System;
using TowerDefense.Entities;

namespace TowerDefense.Commands
{
    public class PlaceTowerCommand : ICommand
    {
        private GameField _field;
        private Tower _tower;
        private int _position;

        public PlaceTowerCommand(GameField field, Tower tower, int position)
        {
            _field = field;
            _tower = tower;
            _position = position;
        }

        public void Execute()
        {
            _field.PlaceTower(_tower, _position);
            Console.WriteLine($"The tower '{_tower.Name}' is sited at {_position}");
        }

        public void Undo()
        {
            _field.RemoveTower(_position);
            Console.WriteLine($"The tower is deleted from {_position}");
        }
    }
}