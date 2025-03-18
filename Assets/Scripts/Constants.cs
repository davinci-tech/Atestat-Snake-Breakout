using UnityEngine;

static public class Constants
{
  static public class Snake
  {
    /// <summary>
    /// This two delimit the area where power-ups and other items can spawn
    /// </summary>
    static public Vector2 bottomLeftLimit = new(-23, -12);
    static public Vector2 upperRightLimit = new(23, 12);

    /// <summary>
    ///   The minimum score the player has to achieve in order to unlock energizers
    /// </summary>
    static public float initialEnergizerRequirement = 7;

    /// <summary>
    ///   The timelimit (in seconds) after which the game ends
    /// </summary>
    static public float timelimit = 60;

    /// <summary>
    ///   Specifies the time trashold in seconds below which a dagger will spawn.
    ///   Usually is half the value of `timelimit`
    /// </summary>
    static public float daggerSpawnTreshold = 30;
  }
}
