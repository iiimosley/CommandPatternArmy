using System;

namespace CommandPatternArmy
{
    public interface ICommand
    {
        void Execute();
    }

    public class ForwardCommand : ICommand
    {
        HomeArmy _source;
        public ForwardCommand(HomeArmy source)
        {
            _source = source;
        }
        public void Execute()
        {
            _source.MoveForward();
        }
    }
    public class AttackCommand : ICommand
    {
        Army _source;
        Army _target;

        public AttackCommand(Army source, Army target)
        {
            _source = source;
            _target = target;

        }
        public void Execute()
        {
            _source.Attack(_target);
        }
    }
}
