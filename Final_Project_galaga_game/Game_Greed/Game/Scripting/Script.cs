using System.Collections.Generic;


namespace FINAL_Project_galaga_game.Game.Scripting
{
    /// <summary>
    /// <para>A collection of actions.</para>
    /// <para>
    /// The responsibility of a cast is to keep track of a collection of actions. It has methods for 
    /// adding, removing and getting them by a group name.
    /// </para>
    /// </summary>
    public class Script
    {
        private Dictionary<string, List<Operation>> actions = new Dictionary<string, List<Operation>>();

        /// <summary>
        /// Constructs a new instance of Script.
        /// </summary>
        public Script()
        {
        }

        /// <summary>
        /// Adds the given action to the given group.
        /// </summary>
        /// <param name="group">The group name.</param>
        /// <param name="action">The action to add.</param>
        public void AddAction(string group, Operation action)
        {
            if (!actions.ContainsKey(group))
            {
                actions[group] = new List<Operation>();
            }

            if (!actions[group].Contains(action))
            {
                actions[group].Add(action);
            }
        }

        /// <summary>
        /// Gets the actions in the given group. Returns an empty list if there aren't any.
        /// </summary>
        /// <param name="group">The group name.</param>
        /// <returns>The list of actions.</returns>
        public List<Operation> GetActions(string group)
        {
            List<Operation> results = new List<Operation>();
            if (actions.ContainsKey(group))
            {
                results.AddRange(actions[group]);
            }
            return results;
        }

        /// <summary>
        /// Removes the given action from the given group.
        /// </summary>
        /// <param name="group">The group name.</param>
        /// <param name="action">The action to remove.</param>
        public void RemoveActor(string group, Operation action)
        {
            if (actions.ContainsKey(group))
            {
                actions[group].Remove(action);
            }
        }

    }
}