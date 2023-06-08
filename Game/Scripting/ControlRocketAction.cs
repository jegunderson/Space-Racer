using Unit06.Game.Casting;
using Unit06.Game.Services;
using System.Collections.Generic;


namespace Unit06.Game.Scripting
{
    public class ControlRocketAction : Action
    {
        private KeyboardService _keyboardService;

        public ControlRocketAction(KeyboardService keyboardService)
        {
            this._keyboardService = keyboardService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            List<Actor> rockets_list = cast.GetActors(Constants.ROCKET_GROUP);
            Rocket rocket1 = (Rocket)rockets_list[0];
            Rocket rocket2 = (Rocket)rockets_list[1];
            if (_keyboardService.IsKeyDown(Constants.LEFT))
            {
                rocket1.SwingLeft();
            }
            else if (_keyboardService.IsKeyDown(Constants.RIGHT))
            {
                rocket1.SwingRight();
            }
            else if (_keyboardService.IsKeyDown(Constants.UP))
            {
                rocket1.SwingUp();
            }
            else if (_keyboardService.IsKeyDown(Constants.DOWN))
            {
                rocket1.SwingDown();
            }
            else
            {
                rocket1.StopMoving();
            }

            // move second racket
            if (_keyboardService.IsKeyDown("a"))
            {
                rocket2.SwingLeft();
            }
            else if (_keyboardService.IsKeyDown("d"))
            {
                rocket2.SwingRight();
            }
            else if (_keyboardService.IsKeyDown("w"))
            {
                rocket2.SwingUp();
            }
            else if (_keyboardService.IsKeyDown("s"))
            {
                rocket2.SwingDown();
            }
            else
            {
                rocket2.StopMoving();
            }
        }
    }
}