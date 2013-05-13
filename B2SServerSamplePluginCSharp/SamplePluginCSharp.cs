/******************************************************
 * Sample C# Plugin implementation for the B2S.Server *
 *****************************************************/

using System;

//Makes the MEF functions available (dont forget the a reference to System.ComponentModel.Composition in your own projects)
using System.ComponentModel.Composition;

//Makes the interfaces in the B2SServerPluginInterface.dll available (dont forget to set the reference to the DLL in your own projects).
using B2SServerPluginInterface;

//Makes the forms namespace available. Used for the frontend call.
using System.Windows.Forms;

/// <summary>
/// Main namespace of the B2SServerSamplePlugin.<br/>
/// \remark Change the name of the namespace to match your own project, when reusing the code.
/// </summary> 
namespace B2SServerSamplePluginCSharp
{

    /// <summary>
    /// Main class of the B2S.Server plugin.<br/>
    /// This class must implement the IDirectPlugin interface provided by the B2SServerPluginInterface.dll.<br/>
    /// If a plugin provides a frontend the IDirectPluginFrontend interface has to be implemented as well.<br/>
    /// For plugins wanting to receive updates on important PinMame actions the IDirectPluginPinMame interface has to be implemented.<br/>
    /// <br/>
    /// In addition to the implementation of the necessary interfaces, the class has to be exported for the use with MEF using the following attribute  [Export(typeof(B2SServerPluginInterface.IDirectPlugin))] (for VB.net &lt;Export(GetType(B2SServerPluginInterface.IDirectPlugin))&gt; would be the same).
    /// \remark Remember to change the name of the class to something meaningful for your plugin project when reusing this code.
    /// </summary>
    [Export(typeof(IDirectPlugin))]
    public class SamplePluginCSharp : IDirectPlugin, IDirectPluginFrontend, IDirectPluginPinMame
    {

        #region IDirectPlugin Members

        /// <summary>
        /// Gets the name of the plugin.<br/>
        /// When implmenting this property it is recommended to add the version of the plugin to the name as well.<br/> 
        /// The IDirectPlugin interface requires the implementation of the property.<br/>
        /// \remark If the code of this implementation of the property is reused, be sure to set the versioning information in AssemblyInfo.cs to something like [assembly: AssemblyVersion("1.0.*")]. Otherwise the BuildDate will not be correct.<br/>
        /// </summary>
        /// <value>
        /// The name of the IDirectPlugin.
        /// </value>
        public string Name
        {
            get
            {
                //Get the version of the assembly
                Version V =System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
                //Calculate the BuildDate based in the build and revsion number of the project.
                DateTime BuildDate = new DateTime(2000, 1, 1).AddDays(V.Build).AddSeconds(V.Revision * 2);
                //Format and return the name string.
                return string.Format("Sample Plugin C# (V: {0} as of {1})",V.ToString(), BuildDate.ToString("yyyy.MM.dd hh:mm"));
            }
        }

        /// <summary>
        /// Initializes the Plugin.<br/>
        /// This is the first method, which is called after the plugin has been instanciated by the B2S.Server.<br/>
        /// The IDirectPlugin interface requires the implementation of this method.<br/>
        /// </summary>
        /// <param name="TableFilename">The table filename.</param>
        /// <param name="RomName">Name of the rom.</param>
        public void PluginInit(string TableFilename, string RomName)
        {
            //Initialize your plugin here
        }

        /// <summary>
        /// Finishes the plugin.<br />
        /// This is the last method called, before a plugin is discared. This method is also called, after a undhandled exception has occured in a plugin.<br/>
        /// PluginFinish must do all nessecary clean up work for the plugin (e.g. release resources).<br/>
        /// The IDirectPlugin interface requires the implementation of this method.<br/>
        /// </summary>
        public void PluginFinish()
        {
            //Do cleanup work here
        }

        /// <summary>
        /// This method is called, when new data from PinMame becomes available.<br/>
        /// The IDirectPlugin interface requires the implementation of this method.<br/>
        /// \remark The special care when implementing to keep this method very fast! Slow implementations will slow down Visual Pinball, Pinmame, the B2S.Server as well as all other plugins. 
        /// \remark The best solution is to put the data in a queue and process the data in a separate thread.
        /// </summary>
        /// <param name="TableElementTypeChar">Char representing the table element type (S=Solenoid, W=Switch, L=Lamp, M=Mech, G=GI, E=EMTable, ?=Unknown table element).</param>
        /// <param name="Number">The number of the table element.</param>
        /// <param name="Value">The value of the table element.</param>
        public void DataReceive(char TableElementTypeChar, int Number, int Value)
        {
            //Do something with the received data.
        }

        #endregion

        #region IDirectPluginPinMame Members

        /// <summary>
        /// This method is called by the B2S.Server, when the Run method of PinMame gets called.<br/>
        /// The IDirectPlugin interface requires the implementation of this method.<br/>
        /// </summary>
        public void PinMameRun() {
        }

        /// <summary>
        /// This method is called, when the property Pause of Pinmame gets set to true.<br/>
        /// The IDirectPlugin interface requires the implementation of this method.<br/>
        /// </summary>
        public void PinMamePause() { 
        }

        /// <summary>
        /// This method is called by the B2S.Server, when the property Pause of Pinmame gets set to false.<br/>
        /// The IDirectPlugin interface requires the implementation of this method.<br/>
        /// </summary>
        public void PinMameContinue() { }


        /// <summary>
        /// This method is called by the B2S.Server, when the Stop method of Pinmame is called.<br/>
        /// The IDirectPlugin interface requires the implementation of this method.<br/>
        /// </summary>
        public void PinMameStop() { } 

        #endregion

        #region IDirectPluginFrontend Members

        /// <summary>
        /// PluginShowFrontend is called by the B2S.Server if a plugin has to show its frontend.<br />
        /// The IDirectPluginFrontend interface requires the implementation of this method.
        /// </summary>
        /// <param name="Owner">(optional) The owner window of the frontend to be opend.<br/>Make sure that your plugin does also support null for this parameter.</param>
        public void PluginShowFrontend(Form Owner = null)
        {
            //Open the frontend in this method, e.g. as demonstrated below.

            //Check if the frontend window is already open
            //If yes, bring it to the front and set focus
            foreach (Form F in Application.OpenForms)
            {
                if (F.GetType() == typeof(Frontend))
                {
                    F.BringToFront();
                    F.Focus();
                    return;
                }
            }
    
            //If the frontend is not yet open, create a new instance and show it
            Frontend FE = new Frontend();
            if (Owner == null)
            {
                //Owner para is not set.
                FE.Show();
            }
            else
            {
                //Owner para set set. Show frontend and pass owner para.
                FE.Show(Owner);
            }
        }


        #endregion

        #region Constructor of the class
        /// <summary>
        /// Initializes a new instance of the <see cref="SamplePluginCSharp"/> class.<br/>
        /// The class exporting the plugin interface must have a constructor without parameters. If you dont want to do any work in the constructor, the constructor can be ommitted.
        /// </summary>
        public SamplePluginCSharp()
        {
        } 
        #endregion

    }
}
