using System.Collections.Generic;
using cse210_RH2_csharp.Casting;
using cse210_RH2_csharp.Services;


namespace cse210_RH2_csharp.Scripting
{
    /// <summary>
    /// An action to draw all of the actors in the game.
    /// </summary>
    public class HandleCollisionAction : Action
    {
        private PhysicsService _physicsService;
        private AudioService _audioService;
        public HandleCollisionAction(PhysicsService physicsService, AudioService audioService)
        {
            _physicsService = physicsService;
            _audioService = audioService; 
        }
        public override void Execute(Dictionary<string, List<Actor>> cast)
        {
            
            
            foreach (List<Actor> group in cast.Values)
            {
                foreach (Actor acting in group)
                {       
                    if (acting.isRobinhood())
                    {
                        foreach (List<Actor> regroup in cast.Values)
                        {
                            foreach (Actor reacting in regroup)
                            {
                                if (reacting.isBrick())
                                {
                                    bool t = _physicsService.IsCollision(reacting, acting);
                                    if (t)
                                    {
                                        _audioService.PlaySound(Constants.SOUND_BOUNCE);
                                        //if (reacting.GetImage() = "./Assets/WallTall.png" ||)
                                        //{
                                            acting.SetVelocity(new Point(0,0));
                                        //}
                                        
                                    }
                                }
                            }
                        }
                    }
                    else if (acting.isArrow())
                    {
                        foreach (List<Actor> regroup in cast.Values)
                        {
                            foreach (Actor reacting in regroup)
                            {
                                if (!reacting.isArrow() && !reacting.isRobinhood())
                                {
                                    if (_physicsService.IsCollision(acting, reacting) && (acting.GetImage()!= "000000"))
                                        {
                                            _audioService.PlaySound(Constants.SOUND_BOUNCE);
                                        
                                            acting.SetImage("000000");
                                        }
                                }
                                    
                            }
                        }
                    }
                    else if (acting.isRichguy())
                    {
                        foreach (List<Actor> regroup in cast.Values)
                        {
                            foreach (Actor reacting in regroup)
                            {
                                if (reacting.isBrick())
                                {
                                    if (_physicsService.IsCollision(acting,reacting))
                                    {
                                        acting.HitsWall();
                                    }
                                }
                                else if (reacting.isArrow())
                                {

                                    if (_physicsService.IsCollision(acting, reacting) && (acting.GetImage()!= "000000"))
                                    {
                                        _audioService.PlaySound(Constants.SOUND_BOUNCE);
                                    
                                        acting.SetImage("000000");
                                    }
                                }
                                else if (reacting.isRobinhood())
                                {
                                    if (_physicsService.IsCollision(acting, reacting) && (acting.GetImage()!= "000000"))
                                    {
                                        _audioService.PlaySound(Constants.SOUND_BOUNCE);
                                    }
                                }
                                
                            }
                        }
                    }
                }
            }
            
        }
    }
}