using System.ComponentModel;
using System.Runtime.CompilerServices;
using Limyla.Wpf.Models;

namespace Limyla.Wpf.ViewModels
{
    /// <summary>
    /// ViewModel for the MainPage
    /// </summary>
    public class PageXViewModel : INotifyPropertyChanged
    {
        /// <summary>Model to associate to the ViewModel</summary>
        public PageX PageX { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public PageXViewModel()
        {
            // Model initialisation
            this.PageX = new PageX()
            {
                Distance = 0
            };

            this.Length = this.PageX.Length.ToString();
            this.Width = this.PageX.Width.ToString();
            this.Distance = this.PageX.Distance.ToString();
            this.EstimatedHeight = this.PageX.EstimatedHeight.ToString();
        }

        private bool changeHappening;

        private string _ErrorMessage;
        public string ErrorMessage
        {
            get { return this._ErrorMessage; }
            set
            {
                SetProperty(ref this._ErrorMessage, value);
            }
        }

        private string _Length;
        public string Length
        {
            get { return this._Length; }
            set
            {
                SetProperty(ref this._Length, value);

                uint lengthAsUint = 0;
                if (uint.TryParse(this._Length, out lengthAsUint))
                {
                    this.PageX.Length = lengthAsUint;

                    if (!this.changeHappening)
                    {
                        this.changeHappening = true;

                        this.Width = this.PageX.Width.ToString();
                        this.Distance = this.PageX.Distance.ToString();
                        this.EstimatedHeight = this.PageX.EstimatedHeight.ToString();

                        this.ErrorMessage = null;

                        this.changeHappening = false;
                    }
                }
                else
                {
                    this.ErrorMessage = "La saisie doit être un nombre";
                }
            }
        }

        private string _Width;
        public string Width
        {
            get { return this._Width; }
            set
            {
                SetProperty(ref this._Width, value);

                uint widthAsUint = 0;
                if (uint.TryParse(this._Width, out widthAsUint))
                {
                    this.PageX.Width = widthAsUint;

                    if (!this.changeHappening)
                    {
                        this.changeHappening = true;

                        this.Length = this.PageX.Length.ToString();
                        this.Distance = this.PageX.Distance.ToString();
                        this.EstimatedHeight = this.PageX.EstimatedHeight.ToString();

                        this.ErrorMessage = null;

                        this.changeHappening = false;
                    }
                }
                else
                {
                    this.ErrorMessage = "La saisie doit être un nombre";
                }
            }
        }

        private string _Distance;
        public string Distance
        {
            get { return this._Distance; }
            set
            {
                SetProperty(ref this._Distance, value);

                uint distanceAsUint = 0;
                if (uint.TryParse(this._Distance, out distanceAsUint))
                {
                    this.PageX.Distance = distanceAsUint;

                    if (!this.changeHappening)
                    {
                        this.changeHappening = true;

                        this.Length = this.PageX.Length.ToString();
                        this.Width = this.PageX.Width.ToString();
                        this.EstimatedHeight = this.PageX.EstimatedHeight.ToString();

                        this.ErrorMessage = null;

                        this.changeHappening = false;
                    }
                }
                else
                {
                    this.ErrorMessage = "La saisie doit être un nombre";
                }
            }
        }

        private string _EstimatedHeight;
        public string EstimatedHeight
        {
            get { return this._EstimatedHeight; }
            set
            {
                SetProperty(ref this._EstimatedHeight, value);

                uint estimatedHeightAsUint = 0;
                if (uint.TryParse(this._EstimatedHeight, out estimatedHeightAsUint))
                {
                    this.PageX.EstimatedHeight = estimatedHeightAsUint;

                    if (!this.changeHappening)
                    {
                        this.changeHappening = true;

                        this.Length = this.PageX.Length.ToString();
                        this.Width = this.PageX.Width.ToString();
                        this.Distance = this.PageX.Distance.ToString();

                        this.ErrorMessage = null;

                        this.changeHappening = false;
                    }
                }
                else
                {
                    this.ErrorMessage = "La saisie doit être un nombre";
                }
            }
        }

        #region event handling
        /// <summary>Event fired when a property is changed in the UI</summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Changing property event
        /// </summary>
        /// <param name="propertyName">Changing property</param>
        protected void RaisedPropertyChanged([CallerMemberName]string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Field change notification only if the field has really changed
        /// </summary>
        /// <typeparam name="T">Field type</typeparam>
        /// <param name="storage">Initial value</param>
        /// <param name="value">Updated value</param>
        /// <param name="propertyName">Property name</param>
        /// <returns>true if the field value changed, false otherwise</returns>
        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName]string propertyName = null)
        {
            if (Equals(storage, value))
            {
                return false;
            }
            else
            {
                storage = value;
                this.RaisedPropertyChanged(propertyName);
                return true;
            }
        }
        #endregion event handling
    }
}
