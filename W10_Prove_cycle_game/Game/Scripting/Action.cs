using W10_Prove_cycle_game.Game.Casting;


namespace W10_Prove_cycle_game.Game.Scripting 
{
    /// <summary>
    /// <para>A thing that is done.</para>
    /// <para>
    /// The responsibility of action is to do something that is integral or important in the game. 
    /// Thus, it has one method, Execute(...), which should be overridden by derived classes.
    /// </para>
    /// </summary>
    public interface Actions
    {
        /// <summary>
        /// Executes something that is important in the game. This method should be overriden by 
        /// derived classes.
        /// </summary>
        /// <param name="cast">The cast of actors.</param>
        /// <param name="script">The script of actions.</param>
        void Execute(Cast cast, Script script);
    }
}