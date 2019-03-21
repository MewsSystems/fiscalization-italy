using System;
using System.Xml.Serialization;

namespace Mews.Fiscalization.Italy.Dto.Invoice
{
    [Serializable, XmlType(Namespace = "http://ivaservizi.agenziaentrate.gov.it/docs/xsd/fatture/v1.2")]
    public enum PaymentReason
    {
        A,
        B,
        C,
        D,
        E,
        G,
        H,
        I,
        L,
        M,
        N,
        O,
        P,
        Q,
        R,
        S,
        T,
        U,
        V,
        W,
        X,
        Y,
        Z,
        L1,
        M1,
        O1,
        V1,
    }
}