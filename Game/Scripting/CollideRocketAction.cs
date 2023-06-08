using Unit06.Game.Casting;
using Unit06.Game.Services;
using System.Collections.Generic;


namespace Unit06.Game.Scripting
{
    public class CollideRocketAction : Action
    {
        private AudioService _audioService;
        private PhysicsService _physicsService;
        
        public CollideRocketAction(PhysicsService physicsService, AudioService audioService)
        {
            this._physicsService = physicsService;
            this._audioService = audioService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            List<Actor> rockets_list = cast.GetActors(Constants.ROCKET_GROUP);
            Rocket rocket1 = (Rocket)rockets_list[0];
            Rocket rocket2 = (Rocket)rockets_list[1];
            Body rocketBody1 = rocket1.GetBody();
            Body rocketBody2 = rocket2.GetBody();

        }
    }
}