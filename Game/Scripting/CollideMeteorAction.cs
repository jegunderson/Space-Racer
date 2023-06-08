using System.Collections.Generic;
using Unit06.Game.Casting;
using Unit06.Game.Services;


namespace Unit06.Game.Scripting
{
    public class CollideMeteorAction : Action
    {
        private AudioService _audioService;
        private PhysicsService _physicsService;
        
        public CollideMeteorAction(PhysicsService physicsService, AudioService audioService)
        {
            this._physicsService = physicsService;
            this._audioService = audioService;
        }

        public void Execute(Cast cast, Script script, ActionCallback callback)
        {
            List<Actor> rockets = cast.GetActors(Constants.ROCKET_GROUP);
            List<Actor> meteor_list = cast.GetActors(Constants.METEOR_GROUP);
            Stats stats = (Stats)cast.GetFirstActor(Constants.STATS_GROUP);

            Rocket rocket1 = (Rocket)rockets[0];
            Rocket rocket2 = (Rocket)rockets[1];
            
            foreach (Actor actor in meteor_list)
            {
                Meteor meteor = (Meteor)actor;
                Body meteorBody = meteor.GetBody();
                Body rocket1Body = rocket1.GetBody();
                Body rocket2Body = rocket2.GetBody();

                if (_physicsService.HasCollided(meteorBody, rocket1Body))
                {
                    rocket1Body.SetPosition(new Point(Constants.ROCKET1_STARTX, Constants.SCREEN_HEIGHT - Constants.ROCKET_HEIGHT));
                    // rocket1.BounceY();
                    Sound sound = new Sound(Constants.BOUNCE_SOUND);
                    _audioService.PlaySound(sound);
                    // int points = brick.GetPoints();
                    // stats.AddPoints(points);
                    // cast.RemoveActor(Constants.BRICK_GROUP, brick);
                }

                if (_physicsService.HasCollided(meteorBody, rocket2Body))
                {
                    rocket2Body.SetPosition(new Point(Constants.ROCKET2_STARTX, Constants.SCREEN_HEIGHT - Constants.ROCKET_HEIGHT));
                    // ball.BounceY();
                    Sound sound = new Sound(Constants.BOUNCE_SOUND);
                    _audioService.PlaySound(sound);
                    // int points = brick.GetPoints();
                    // stats.AddPoints(points);
                    // cast.RemoveActor(Constants.BRICK_GROUP, brick);
                    //Random comment
                }
            }
        }
    }
}