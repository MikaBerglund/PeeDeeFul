PeeDeeFul
=========

A solution to simplify PDF document creation. Builds on top of existing solutions and provides components
that are easily consumable in various different clients.

PeeDeeFul is built in .NET, but many of its components are written for 
[.NET Standard](https://blogs.msdn.microsoft.com/dotnet/2016/09/26/introducing-net-standard/), so you can 
use PeeDeeFul on many different platforms and on many different devices.

The solution consists of the following elements.

PeeDeeFul.DocumentModel
-----------------------

A class library targetting *.NET Standard*. You use this library to model your PDF documents much like you use
a HTML DOM to model a HTML document or an XML DOM to model an XML document.

The DOM can be serialized to [MDDDL (MigraDoc Document Description Language)](http://www.pdfsharp.net/wiki/MigraDocDDL.ashx), 
which is a text based representation of a PDF document. This DDL can then be parsed by *MigraDoc* and
rendered into an actual PDF document.


PeeDeeFul.Server
----------------

Takes care of rendering PDF DOMs to actual PDF documents. Built as an 
[Azure Functions](https://azure.microsoft.com/en-us/services/functions/) application that exposes HTTP 
triggered functions that do the heavy lifting.

The server application takes the serialized PDF DOM sent by *PeeDeeFul.Client* and deserializes it to
a similar DOM using [MigraDoc and PDFsharp](https://www.nuget.org/packages/PDFsharp-MigraDoc-gdi/) and 
turns the DOM into an actual PDF document. These libraries are only available for the full .NET Framework
and cannot be used in applications targetting *.NET Core* or *.NET Standard*.

Allthough you can communicate directly with the HTTP endpoints exposed by the application, it is easier
to do with the *PeeDeeFul.Client* library.


PeeDeeFul.Client
----------------

A class library targetting *.NET Standard*. This library is responsible for communicating with the
*PeeDeeFul.Server* application.

When creating a PDF document with the client library, you first build the PDF DOM with the help of
the *PeeDeeFul.DocumentModel* library. Then you pass the DOM on to the client library which then
serializes the DOM to *MDDDL* before sending it to the server. The server takes the serialized DOM
and renders it to a PDF document and returns it.


PeeDeeFul.js
------------

Enables PDF document creation directly in your JavaScript application. A JavaScript library written in
[TypeScript](https://www.typescriptlang.org) that exposes classes forbuilding a PDF DOM like the one in 
*PeeDeeFul.DocumentModel*. The library is also capable of communicating directly with *PeeDeeful.Server*.


How it works
------------

With PeeDeeFul, PDF document creation is just three steps away.

1. Create the PDF DOM with *PeeDeeFul.DocumentModel* or *PeeDeeFul.js*
2. Use the *PeeDeeFul.Client* to send the DOM to the *PeeDeeFul.Server*
3. Open the PDF document returned by *PeeDeeFul.Client*