using System;

namespace Limyla.Wpf.Models
{
    /// <summary>
    /// Model for a PageX
    /// </summary>
    public class PageX
    {
        /// <summary>Ratio between L and l: l = (1/3) * L</summary>
        private readonly double r1 = 3;

        /// <summary>Ratio between L and d: d = (1/10) * L</summary>
        private readonly double r2 = 10;

        /// <summary>Ratio between L and h: h = (2/9) * L</summary>
        private readonly double r3 = (9.0 / 2.0);

        /// <summary>
        /// Changing value indicator.<para />
        /// Avoid infinite loop where a field change another field that change another field...
        /// </summary>
        public bool ChangeHappening { get; set; }

        private uint _length;
        /// <summary>Page length</summary>
        public uint Length
        {
            get { return this._length; }
            set
            {
                // Changing value indicator for the length: allow avoiding the update
                // of the other fields if the value is the same; moreover, with non-exact conversion
                // from double to int, values would change all the time at every field switch
                bool hasChanged = !Equals(this._length, value);

                this._length = value;

                if (!ChangeHappening && hasChanged)
                {
                    // A change is happening
                    ChangeHappening = true;

                    if (value == 0)
                    {
                        Width = 0;
                        Distance = 0;
                        EstimatedHeight = 0;
                    }
                    else
                    {
                        Width = Convert.ToUInt32(value / r1);
                        Distance = Convert.ToUInt32(value / r2);
                        EstimatedHeight = Convert.ToUInt32(value / r3);
                    }

                    // The change has been made
                    ChangeHappening = false;
                }
            }
        }

        private uint _width;
        /// <summary>Page width</summary>
        public uint Width
        {
            get { return this._width; }
            set
            {
                // Changing value indicator for the width: allow avoiding the update
                // of the other fields if the value is the same; moreover, with non-exact conversion
                // from double to int, values would change all the time at every field switch
                bool hasChanged = !Equals(this._width, value);

                this._width = value;

                if (!ChangeHappening && hasChanged)
                {
                    // A change is happening
                    ChangeHappening = true;

                    if (value == 0)
                    {
                        Length = 0;
                        Distance = 0;
                        EstimatedHeight = 0;
                    }
                    else
                    {
                        Length = Convert.ToUInt32(value * r1);
                        Distance = Convert.ToUInt32((value * r1) / r2);
                        EstimatedHeight = Convert.ToUInt32((value * r1) / r3);
                    }

                    // The change has been made
                    ChangeHappening = false;
                }
            }
        }

        private uint _distance;
        /// <summary>Distance between 2 folds</summary>
        public uint Distance
        {
            get { return this._distance; }
            set
            {
                // Changing value indicator for the distance: allow avoiding the update
                // of the other fields if the value is the same; moreover, with non-exact conversion
                // from double to int, values would change all the time at every field switch
                bool hasChanged = !Equals(this._distance, value);

                this._distance = value;

                if (!ChangeHappening && hasChanged)
                {
                    // A change is happening
                    ChangeHappening = true;

                    if (value == 0)
                    {
                        Length = 0;
                        Width = 0;
                        EstimatedHeight = 0;
                    }
                    else
                    {
                        Length = Convert.ToUInt32(value * r2);
                        Width = Convert.ToUInt32((value * r2) / r1);
                        EstimatedHeight = Convert.ToUInt32((value * r2) / r3);
                    }

                    // The change has been made
                    ChangeHappening = false;
                }
            }
        }

        private uint _estimatedHeight;
        /// <summary>Lamp estimated heigth</summary>
        public uint EstimatedHeight
        {
            get { return this._estimatedHeight; }
            set
            {
                // Changing value indicator for the estimated height: allow avoiding the update
                // of the other fields if the value is the same; moreover, with non-exact conversion
                // from double to int, values would change all the time at every field switch
                bool hasChanged = !Equals(this._estimatedHeight, value);

                this._estimatedHeight = value;

                if (!ChangeHappening && hasChanged)
                {
                    // A change is happening
                    ChangeHappening = true;

                    if (value == 0)
                    {
                        Length = 0;
                        Width = 0;
                        Distance = 0;
                    }
                    else
                    {
                        Length = Convert.ToUInt32(value * r3);
                        Width = Convert.ToUInt32((value * r3) / r1);
                        Distance = Convert.ToUInt32((value * r3) / r2);
                    }

                    // The change has been made
                    ChangeHappening = false;
                }
            }
        }
    }
}
