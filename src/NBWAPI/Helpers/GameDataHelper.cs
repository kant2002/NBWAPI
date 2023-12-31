using System;

namespace NBWAPI
{
    /// <summary>
    /// Static functions for modifying GameData.
    /// These functions live outside GameData because GameData is auto-generated.
    /// </summary>
    public static class GameDataHelper
    {
        public const int MaxCount = 19999;

        private const int MaxStringLength = 1024;

        public static int AddString(ClientData.GameData_ gameData, string str)
        {
            var stringCount = gameData.GetStringCount();
            if (stringCount >= MaxCount)
            {
                throw new InvalidOperationException("Too many strings!");
            }

            // Truncate string if its size equals or exceeds 1024
            var stringTruncated = str.Length >= MaxStringLength ? str[..(MaxStringLength - 1)] : str;
            gameData.SetStringCount(stringCount + 1);
            gameData.SetStrings(stringCount, stringTruncated);
            return stringCount;
        }

        public static ClientData.Shape AddShape(ClientData.GameData_ gameData)
        {
            var shapeCount = gameData.GetShapeCount();
            if (shapeCount >= MaxCount)
            {
                throw new InvalidOperationException("Too many shapes!");
            }

            gameData.SetShapeCount(shapeCount + 1);
            return gameData.GetShapes(shapeCount);
        }

        public static ClientData.Command AddCommand(ClientData.GameData_ gameData)
        {
            var commandCount = gameData.GetCommandCount();
            if (commandCount >= MaxCount)
            {
                throw new InvalidOperationException("Too many commands!");
            }

            gameData.SetCommandCount(commandCount + 1);
            return gameData.GetCommands(commandCount);
        }

        public static ClientData.UnitCommand AddUnitCommand(ClientData.GameData_ gameData)
        {
            var unitCommandCount = gameData.GetUnitCommandCount();
            if (unitCommandCount >= MaxCount)
            {
                throw new InvalidOperationException("Too many unit commands!");
            }

            gameData.SetUnitCommandCount(unitCommandCount + 1);
            return gameData.GetUnitCommands(unitCommandCount);
        }
    }
}