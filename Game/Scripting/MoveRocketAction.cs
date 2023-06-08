using Unit06.Game.Casting;
using System.Collections.Generic;

namespace Unit06.Game.Scripting
{
    public class MoveRocketAction : Action
    {
        public MoveRocketAction()
        {
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            List<Actor> rockets_list = cast.GetActors(Constants.ROCKET_GROUP);
            foreach (Rocket rocket in rockets_list)
            {
                Body body = rocket.GetBody();
                Point position = body.GetPosition();
                Point velocity = body.GetVelocity();
                int x = position.GetX();

                position = position.Add(velocity);
                if (x < 0)
                {
                    position = new Point(0, position.GetY());
                }
                else if (x > Constants.SCREEN_WIDTH - Constants.ROCKET_WIDTH)
                {
                    position = new Point(Constants.SCREEN_WIDTH - Constants.ROCKET_WIDTH,
                        position.GetY());
                }

                body.SetPosition(position);
            }

        }
    }
}