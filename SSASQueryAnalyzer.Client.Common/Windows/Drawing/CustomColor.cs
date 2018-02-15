//----------------------------------------------------------------------------
// MIT License
// 
// Copyright (c) 2017 SSASQueryAnalyzer
// 
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
// 
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.
//----------------------------------------------------------------------------
namespace SSASQueryAnalyzer.Client.Common.Windows.Drawing
{
    using System.Drawing;

    public struct CustomColor
    {
        /* *******************************************************************************                                  
         *                                  WARNING 
         * *******************************************************************************                                
         * The total number of CustomColor MUST not exceed the value set for the constant 
         * "MAXIMUM_CUSTOM_COLORS" in the "ASQAHelperAddinControl.cs" file
         * Possibly increase that value if needed!
         * *******************************************************************************/

        #region Generic

        public static Color WarmColor = Color.FromArgb(200, 0, 0);
        public static Color WarmColorLight = Color.FromArgb(255, 192, 192);
        public static Color ColdColor = Color.FromArgb(0, 90, 255);
        public static Color ColdColorLight = Color.FromArgb(167, 198, 255);
        public static Color SelectedObjectColor = Color.Firebrick;
        public static Color ObjectsBorderColor = Color.Black;

        public static Color ASQAOrange = Color.FromArgb(236, 105, 82);
        public static Color HighlightColor = ASQAOrange;
        #endregion

        #region Timeline

        public static Color ProfilerEventsColor = Color.FromArgb(50, 150, 0);
        public static Color PerformanceCountersColor = Color.FromArgb(255, 100, 0);
        public static Color CachesColor = Color.FromArgb(0, 168, 168);
        public static Color AggregationsColor = Color.FromArgb(255, 175, 0);
        public static Color PartitionsColor = Color.FromArgb(159, 194, 211);
        public static Color CachedDimensionsColor = Color.FromArgb(0, 0, 255);
        public static Color NonCachedDimensionsColor = Color.FromArgb(64, 200, 255);             
        public static Color RegularMeasuresColor = Color.FromArgb(200, 255, 64);
        public static Color CalculatedMeasuresColor = Color.FromArgb(0, 128, 0);
        public static Color NonEmptyActivitiesColor = Color.FromArgb(128, 0, 64);
        public static Color SerializationActivitiesColor = Color.FromArgb(128, 128, 128);
        
        #endregion

        #region Progress 

        public static Color InProgressColor = Color.DarkOrange;
        public static Color CompletedColor = Color.DarkGreen;
        public static Color StoppedColor = Color.DarkRed;
        public static Color InactiveColor = SystemColors.InactiveCaptionText;
        public static Color ActiveColor = SystemColors.ControlText;
        
        #endregion
    }
}
