[![Build Status](https://mews.visualstudio.com/Mews/_apis/build/status/MewsSystems.fiscalization-italy?branchName=master)](https://mews.visualstudio.com/Mews/_build/latest?definitionId=2&branchName=master)

## This library is a work in progress

# SDI
A client library for reporting invoices through SDI (Sistema di interscambio). Here are the main parts of the library:
- **SDI Client** that handles communication with the SDI.
- **DTOs** that can be serialized into XML conforming to the FatturaPA format (the official format in which all invoices need to be reported).
- **DTOs** for handling messages sent by the SDI.
