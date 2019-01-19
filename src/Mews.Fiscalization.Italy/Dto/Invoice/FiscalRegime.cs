using System;
using System.Xml.Serialization;

namespace Mews.Fiscalization.Italy.Dto.Invoice
{
    [Serializable, XmlType(Namespace = "http://www.fatturapa.gov.it/sdi/fatturapa/v1.1")]
    public enum FiscalRegime
    {
        RF01,
        RF02,
        RF03,
        RF04,
        RF05,
        RF06,
        RF07,
        RF08,
        RF09,
        RF10,
        RF11,
        RF12,
        RF13,
        RF14,
        RF15,
        RF16,
        RF17,
        RF19,
        RF18,
    }
}