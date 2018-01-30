﻿using System.Collections.Generic;

namespace DMLibrary
{
    public class Helper
    {
        /// <summary>
        /// Разрешенный диапозон отклонения в размерах файла
        /// </summary>
        public const int Range = 15;

        /// <summary>
        /// Стандартный размер площади стандартного формата
        /// </summary>
        public const double StandartArea = 62370;

        /// <summary>
        /// Общий список всех форматов с наименованием и их размерами
        /// </summary>
        public static Dictionary<string, int[]> Formats = new Dictionary<string, int[]>()
        {
            // Name, array [ width, height, area, min area, max area ]
            // Base formats name
            {"a6", new []{ 105, 148,  15540,  14300,  16830 } },
            {"a5", new []{ 148, 210,  31080,  29315,  32895 } },
            {"a4", new []{ 210, 297,  62370,  59860,  64930 } },
            {"a3", new []{ 297, 420,  124740, 121180, 128350 } },
            {"a2", new []{ 420, 594,  249480, 244435, 254575 } },
            {"a1", new []{ 594, 841,  499554, 492404, 506754 } },
            {"a0", new []{ 841, 1188, 999108, 988152, 1009278 } },
            // GOST formats name
            // {X} x 630
            {"297x630", new []{ 297, 630, 187110, 182500, 191770 } },
            {"420x630", new []{ 420, 630, 264600, 259375, 269875 } },
            {"594x630", new []{ 594, 630, 374220, 368125, 380365 } },
            // {X} x 1050
            {"297x1050", new []{ 297, 1050, 311850, 305140, 318610 } },
            {"420x1050", new []{ 420, 1050, 441000, 433675, 448375 } },
            {"594x1050", new []{ 594, 1050, 623700, 615505, 631945 } },
            // {X} x 1260
            {"297x1260", new []{ 297, 1260, 374220, 366460, 382030 } },
            {"420x1260", new []{ 420, 1260, 529200, 520825, 537625 } },
            {"594x1260", new []{ 594, 1260, 748440, 739195, 757735 } },
            // Others
            {"297x841", new []{ 594, 1260, 249777, 244112, 255492 } },
            {"420x841", new []{ 594, 1260, 353220, 346940, 359550 } },
            {"420x891", new []{ 594, 1260, 374220, 367690, 380800 } },
        };
    }
}
