Implement your own plugin using C# {#implementcsharp}
==================================================

\section implementcsharp_introduction Introduction

Creating your own plugin is a relatively easy process. You only neeed to build a new class library, implement the IDirectPlugin interface(s) and decorate the class with  [Export(typeof(IDirectPlugin))] to get rolling.

The following sections are explaing plugin creation in more detail.

\section implementcsharp_prerequisites Prerequisites

- To create a plugin you need some development environement for C#. The best IDE for C# is Microsofts Visual Studio. The Express Version of Visual Studio is available for free from Microsofts website.
- Since plugins have to implement specific interfaces, yull have to aquire a copy of the B2SServerPluginInterface.dll. This dll is part of the B2S.Server deployment package and can also be downloaded separately from the project page on the B2S.Server Plugin Interface.
- To run your plugin you will need the B2S.Server as well as Visual Pinball and a Visual Pinball Table clling the B2S.Server.

\section implementcsharp_implement Implementation Step by Step

This step by step guide will teach you how to implement your own plugin.

Sorry, all screenshots are from a german version of Visual Studio.

\subsection implementcsharp_step1 Step 1: Create the project

Start Visual Studio and create a new class library project. Dont forget to give a nice name to your plugin.

\image html ImplementCSharp001.jpg "Creating a new project"

\subsection implementcsharp_step2 Step 2: Add References

Add references to B2SServerPluginInterface and System.ComponentModel.Composition.

\image html ImplementCSharp002.jpg 
 
Browse for the B2SServerPluginInterface.dll and click OK.

\image html ImplementCSharp003.jpg "Adding a reference the B2SServerPluginInterface.dll"

Add another reference to System.ComponentModel.Composition by selection the .NET tab in the dialog and selecting the mentioned component.

\image html ImplementCSharp004.jpg "Adding a reference to the System.ComponentModel.Composition component"

\subsection implementcsharp_step3 Step 3: Rename the class

Now it would be a good idea to rename the class (class1.cs) which was during project creation to something meaningfull. If the system asks you to rename all references to the old class name, click yes.

\image html ImplementCSharp005.jpg "Rename the class"

\subsection implementcsharp_step4 Step 4: Add using statements

Add using statements for B2SServerPluginInterface and e System.ComponentModel.Composition namespaces to your class.

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~(.cs)
using System.ComponentModel.Composition;
using B2SServerPluginInterface;
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

\subsection implementcsharp_step5 Step 5: Export the class 

Add the Export attribute to the top of your class, to allow the export of the class for the use by the MEF framework (that is whats inside the System.ComponentModel.Composition namespace).
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~(.cs)
[Export(typeof(IDirectPlugin))]
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

Your plugin class should now look like this:

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~(.cs)
using System;

using System.ComponentModel.Composition;
using B2SServerPluginInterface;

namespace MyOwnPlugin
{
    [Export(typeof(IDirectPlugin))]
    public class MyPlugin 
    {
    }
}
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

\subsection implementcsharp_step6 Step 6: Implement IDirectPlugin interface(s)

Next you have to implement the necessary interfaces. It is mandatory to implement IDirectPlugin, the other interfaces in the B2SServerPluginInterface namespace are optional.

First tell your plugin class to inherit the IDirectPlugin interface.

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~(.cs)
public class MyPlugin : IDirectPlugin
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

If you plan to have a configuration frontend for your plugin or to get updates on important PinMame events, inherit IDirectPluginFrontEnd and/or IDirectPluginPinmame.

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~(.cs)
public class MyPlugin : IDirectPlugin, IDirectPluginFrontend, IDirectPluginPinMame
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

Now you have to implement the methods of the inherited plugins. The easiest way to get a rough structure for the plugin member implementation is to click the name of a interface in the class definition with the right mouse button and select "Implement interface" (depending on your version of Visual Studio this function might not be available).

\image html ImplementCSharp006.jpg "Implement a interface"

This will result in the following code for the IDirectPlugin interface;

~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~(.cs)
using System;

using System.ComponentModel.Composition;
using B2SServerPluginInterface;


namespace MyOwnPlugin
{
    [Export(typeof(IDirectPlugin))]
    public class MyPlugin : IDirectPlugin, IDirectPluginFrontend, IDirectPluginPinMame
    {

        #region IDirectPlugin Members

        public void DataReceive(char TableElementTypeChar, int Number, int Value)
        {
            throw new NotImplementedException();
        }

        public string Name
        {
            get { throw new NotImplementedException(); }
        }

        public void PluginFinish()
        {
            throw new NotImplementedException();
        }

        public void PluginInit(string TableFilename, string RomName = "")
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

Get a implementation for the other interfaces the same way.

Alternatively you can also implement the interface member by hand.

\subsection implementcsharp_step7 Step 7: Be creative!

Now it is your turn to be creative and add some functionality to your plugin.

Remove the throw new NotImplementedException(); statements from the default plugin implementation and add your own code.

See the guidelines section for some general hints how to implement your own fuctionality.

\subsection implementcsharp_step8 Step 8: Build and Install

Once you have completed the code for your plugin build the code in Visual Studio. This will result in a dll file having the same name as your plugin project.

Copy this dll to a appropriatley named sub folder of the plugin directory of your B2S.Server installation. If your B2S.Server is located in the Tables directory of Visual Pinball your directory structre might looks as follows:

\image html ImplementCSharp007.jpg "Directory structure"

Alternatively you can also put your plugin into any other directory on your system and add a windows shortcut pointing to this directory to the plugin directory of your B2S.Server installation.

\subsection implementcsharp_step9 Step 9: Test the Plugin

After you have installed your plugin as advised above, it is time for some action.

Start Visual Pinball, load a table which is using the B2S.Server and start the table. 

If everything is correct in your plugin implementation, the B2S.Server will load and execute your plugin automatically when the table is started.

Open the config window of the B2S.Server (click the backglass and push s on your keyboard) and click the plugin window button to open up a window showing all loaded plugins. If your plugin implements a frontend you can double click the name of the plugin in the B2S.Server plugin window to open up the frontend of the plugin.


