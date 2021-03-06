﻿// This file is part of the Site Harvest library for LANDIS-II.

using Landis.Core;
using Landis.SpatialModeling;

namespace Landis.Library.SiteHarvest
{
    /// <summary>
    /// Main interface for initializing and configuring the library.
    /// </summary>
    public static class Main
    {
        private static bool libInitialized = false;

        /// <summary>
        /// Initialize the library for use by client code.
        /// </summary>
        /// <param name="modelCore">
        /// The model's core framework.
        /// </param>
        public static void InitializeLib(ICore modelCore)
        {
            // Only initialize the library once.  This method may be called
            // multiple times if harvest and land-use extensions are both
            // in a scenario.  The harvest extension initializes the Harvest
            // Management, which in turns initializes this library.  The Land
            // Use extension also initializes this library since it's a client
            // of this library.
            if (! libInitialized)
            {
                ResetLib(modelCore);
            }
        }

        // For InitilizePhase2() and CleanUp(), there may be cases in which the 
        // model core gets reset and everything needs to be reinitilized. Thus this 
        // should only be called in those 2 functions if necessary.
        public static void ResetLib(ICore modelCore)
        {
            Model.Core = modelCore;
            SiteVars.Initialize();
            AgeRangeParsing.InitializeClass();
            libInitialized = true;
        }
    }
}
