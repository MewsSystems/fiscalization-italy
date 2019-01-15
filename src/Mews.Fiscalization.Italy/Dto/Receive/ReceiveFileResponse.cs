using System;
using System.Collections.Generic;
using System.Text;

namespace Mews.Fiscalization.Italy.Dto.Receive
{
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlRoot("rispostaSdIRiceviFile", Namespace = "http://www.fatturapa.gov.it/sdi/ws/trasmissione/v1.0/types")]
    public partial class ReceiveFileResponse : object, System.ComponentModel.INotifyPropertyChanged
    {

        private string identificativoSdIField;

        private System.DateTime dataOraRicezioneField;

        private erroreInvio_Type erroreField;

        private bool erroreFieldSpecified;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, DataType = "integer", Order = 0)]
        public string IdentificativoSdI
        {
            get
            {
                return this.identificativoSdIField;
            }
            set
            {
                this.identificativoSdIField = value;
                this.RaisePropertyChanged("IdentificativoSdI");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 1)]
        public System.DateTime DataOraRicezione
        {
            get
            {
                return this.dataOraRicezioneField;
            }
            set
            {
                this.dataOraRicezioneField = value;
                this.RaisePropertyChanged("DataOraRicezione");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified, Order = 2)]
        public erroreInvio_Type Errore
        {
            get
            {
                return this.erroreField;
            }
            set
            {
                this.erroreField = value;
                this.RaisePropertyChanged("Errore");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ErroreSpecified
        {
            get
            {
                return this.erroreFieldSpecified;
            }
            set
            {
                this.erroreFieldSpecified = value;
                this.RaisePropertyChanged("ErroreSpecified");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.fatturapa.gov.it/sdi/ws/trasmissione/v1.0/types")]
    public enum erroreInvio_Type
    {

        /// <remarks/>
        EI01,

        /// <remarks/>
        EI02,

        /// <remarks/>
        EI03,
    }

}
